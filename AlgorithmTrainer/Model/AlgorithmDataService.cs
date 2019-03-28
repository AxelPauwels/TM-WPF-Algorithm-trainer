using System;
using System.Linq;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Dapper;
using System.Collections.ObjectModel;
using AlgorithmTrainer.Extensions;

namespace AlgorithmTrainer.Model
{
    class AlgorithmDataService
    {
        // Ophalen ConnectionString uit App.config
        private static string connectionString =
        ConfigurationManager.ConnectionStrings["azure"].ConnectionString;

        // Stap 1 Dapper
        // Aanmaken van een object uit de IDbConnection class en 
        // instantiëren van een SqlConnection.
        // Dit betekent dat de connectie met de database automatisch geopend wordt.
        private static IDbConnection db = new SqlConnection(connectionString);

        public ObservableCollection<Algorithm> GetAlgorithms(int _sessie)
        {
            ObservableCollection<Algorithm> algorithms = db.Query<Algorithm>("GetAlgorithms", commandType: CommandType.StoredProcedure).ToObservableCollection();

            foreach (Algorithm algorithm in algorithms)
            {
                // inactieve algorithms een andere kleur geven
                algorithm.ActiefColor = "DarkRed";
                algorithm.ResultaatProgress = 50;

                // actieve algorithms verder opvullen met data
                if (algorithm.Actief)
                {
                    algorithm.ActiefColor = "DarkGreen";
                    int _algorithmid = algorithm.Id;
                    decimal _totaleTijdPerAlgorithm = 0;
                    // het beste resultaat opslaan in 'ResultaatBest'
                    try
                    {
                        algorithm.ResultaatBest = db.Query<decimal>("GetBestByAlgorithmIdByDate", new { AlgorithmId = _algorithmid, Sessie = _sessie }, commandType: CommandType.StoredProcedure).Single();
                    }
                    catch (Exception)
                    {
                        algorithm.ResultaatBest = 0;
                    }
                    // het slechtste resultaat opslaan in  'ResultaatWorst'
                    try
                    {
                        algorithm.ResultaatWorst = db.Query<decimal>("GetWorstByAlgorithmIdByDate", new { AlgorithmId = _algorithmid, Sessie = _sessie }, commandType: CommandType.StoredProcedure).Single();
                    }
                    catch (Exception)
                    {
                        algorithm.ResultaatWorst = 0;
                    }
                    // het gemiddelde berekenen
                    try
                    {  // alle resultaten die horen bij de gekozen sessie ophalen
                        ObservableCollection<Resultaat> resultaten = db.Query<Resultaat>("GetResultatenByAlgorithmId", new { AlgorithmId = _algorithmid, Sessie = _sessie }, commandType: CommandType.StoredProcedure).ToObservableCollection();
                        foreach (var resultaat in resultaten)
                        {
                            _totaleTijdPerAlgorithm += resultaat.Tijd;
                        }
                        // het gemiddelde berekenen en opslaan in 'ResultaatAverage'
                        algorithm.ResultaatAverage = Math.Round((_totaleTijdPerAlgorithm / resultaten.Count), 2);
                        algorithm.ResultaatProgress = (int)Math.Round(algorithm.ResultaatAverage * 10);
                    }
                    catch (Exception)
                    {
                        _totaleTijdPerAlgorithm = 0;
                    }
                }
            }
            return algorithms;
        }
        public Algorithm RefreshLastAlgorithm(int _sessie, Algorithm selectedAlgorithm)
        {
            Algorithm algorithm = db.Query<Algorithm>("GetAlgorithmById", new { Id = selectedAlgorithm.Id }, commandType: CommandType.StoredProcedure).Single();

            algorithm.ActiefColor = "DarkRed";
            algorithm.ResultaatProgress = 50;

            // actieve algorithms verder opvullen met data
            if (algorithm.Actief)
            {
                algorithm.ActiefColor = "DarkGreen";
                int _algorithmid = algorithm.Id;
                decimal _totaleTijdPerAlgorithm = 0;
                // het beste resultaat opslaan in 'ResultaatBest'
                try
                {
                    algorithm.ResultaatBest = db.Query<decimal>("GetBestByAlgorithmIdByDate", new { AlgorithmId = _algorithmid, Sessie = _sessie }, commandType: CommandType.StoredProcedure).Single();
                }
                catch (Exception)
                {
                    algorithm.ResultaatBest = 0;
                }
                // het slechtste resultaat opslaan in  'ResultaatWorst'
                try
                {
                    algorithm.ResultaatWorst = db.Query<decimal>("GetWorstByAlgorithmIdByDate", new { AlgorithmId = _algorithmid, Sessie = _sessie }, commandType: CommandType.StoredProcedure).Single();
                }
                catch (Exception)
                {
                    algorithm.ResultaatWorst = 0;
                }
                // het gemiddelde berekenen
                try
                {  // alle resultaten die horen bij de gekozen datum ophalen
                    ObservableCollection<Resultaat> resultaten = db.Query<Resultaat>("GetResultatenByAlgorithmId", new { AlgorithmId = _algorithmid, Sessie = _sessie }, commandType: CommandType.StoredProcedure).ToObservableCollection();
                    foreach (var resultaat in resultaten)
                    {
                        _totaleTijdPerAlgorithm += resultaat.Tijd;
                    }
                    // het gemiddelde berekenen en opslaan in  'ResultaatAverage'
                    algorithm.ResultaatAverage = Math.Round((_totaleTijdPerAlgorithm / resultaten.Count), 2);
                    algorithm.ResultaatProgress = (int)Math.Round(algorithm.ResultaatAverage * 10);
                }
                catch (Exception)
                {
                    _totaleTijdPerAlgorithm = 0;
                }
            }
            return algorithm;
        }
        public void SetAlgorithmActief(int algorithmId)
        {
            //actief-bool ophalen en omzetten naar het tegenovergestelde en terug updaten in de database
            bool _actief;
            var algorithm = db.Query<Algorithm>("GetAlgorithmById", new { Id = algorithmId }, commandType: CommandType.StoredProcedure).Single();
            _actief = !algorithm.Actief;
            db.Execute("UpdateAlgorithmActief", new { Actief = _actief, Id = algorithmId }, commandType: CommandType.StoredProcedure);
        }
        public ObservableCollection<Algorithm> GetAlgorithmsWithCategorie()
        {
            ObservableCollection<Algorithm> algorithms = db.Query<Algorithm>("GetAlgorithms", commandType: CommandType.StoredProcedure).ToObservableCollection();

            foreach (Algorithm algorithm in algorithms)
            {
                // de categorieNaam opslaan in 'CategorieNaam'
                try
                {
                    algorithm.CategorieNaam = db.Query<string>("GetCategorieById", new { Id = algorithm.CategorieId }, commandType: CommandType.StoredProcedure).Single();
                }
                catch (Exception)
                {
                    algorithm.CategorieNaam = "";
                }
            }
            return algorithms;
        }
        public ObservableCollection<Algorithm> GetAlgorithmsByCategorieId(int categorieId)
        {
            ObservableCollection<Algorithm> algorithms = db.Query<Algorithm>("GetAlgorithmsByCategorieId", new { Id = categorieId }, commandType: CommandType.StoredProcedure).ToObservableCollection();
            return algorithms;
        }
        public void UpdateAlgorithm(Algorithm algorithm)
        {
            db.Execute("UpdateAlgorithm", new { algorithm.CategorieId, algorithm.Nummer, algorithm.AlgorithmSolution, algorithm.Actief, algorithm.Id }, commandType: CommandType.StoredProcedure);
        }
        public void InsertAlgorithm(Algorithm algorithm)
        {
            // indien geen categorie gekozen , deze opslaan in "Unsorted".
            if (algorithm.CategorieNaam == null || algorithm.CategorieNaam == "")
            {
                algorithm.CategorieNaam = "Unsorted";
                try
                {
                    //categorie 'unsorted' ophalen
                    Categorie categorie = db.Query<Categorie>("GetCategorieUnsorted", new { Naam = algorithm.CategorieNaam }, commandType: CommandType.StoredProcedure).Single();
                    algorithm.CategorieId = categorie.Id;
                }
                catch (Exception)
                {
                    //indien categorie 'unsorted' niet bestaat, deze categorie aanmaken
                    int _id = db.Query<int>("InsertCategorieUnsorted", new { Naam = algorithm.CategorieNaam }, commandType: CommandType.StoredProcedure).Single();
                    algorithm.CategorieId = _id;
                }
            }
            db.Execute("InsertAlgorithm", new { CategorieId = algorithm.CategorieId, Nummer = algorithm.Nummer, Afbeelding = algorithm.Afbeelding, AlgorithmSolution = algorithm.AlgorithmSolution, Actief = algorithm.Actief }, commandType: CommandType.StoredProcedure);
        }
        public string ImageExists(string zoekAfbeelding)
        {
            string _databaseAfbeelding = "";
            _databaseAfbeelding = db.Query<string>("GetAfbeelding", new { Afbeelding = zoekAfbeelding }, commandType: CommandType.StoredProcedure).SingleOrDefault();
            return _databaseAfbeelding;
        }
        public string AlgorithmExist(string zoekAlgorithmSolution)
        {
            string _algorithmSolution = "";
            _algorithmSolution = db.Query<string>("GetAlgorithmSolution", new { AlgorithmSolution = zoekAlgorithmSolution }, commandType: CommandType.StoredProcedure).SingleOrDefault();
            return _algorithmSolution;
        }
        public int NummerExist(int zoekNummer)
        {
            int _nummer;
            _nummer = db.Query<int>("GetNummer", new { Nummer = zoekNummer }, commandType: CommandType.StoredProcedure).SingleOrDefault();
            return _nummer;
        }
        public string GetAllImages()
        {
            ObservableCollection<Algorithm> algorithms = db.Query<Algorithm>("GetAlgorithms", commandType: CommandType.StoredProcedure).ToObservableCollection();
            // een gestructureerde string maken van de bestaande afbeeldingen om te tonen in de messagebox
            string _allImages = null;
            int teller = 0;
            foreach (var algorithm in algorithms)
            {
                _allImages += algorithm.Afbeelding + "\t";
                teller++;
                if (teller == 6)
                {
                    _allImages += "\n";
                    teller = 0;
                }
            }
            return _allImages;
        }
        public int GetHoogsteGuideNummer()
        {
            int _nummer;
            _nummer = db.Query<int>("GetHoogsteGuideNummer", commandType: CommandType.StoredProcedure).SingleOrDefault();
            return _nummer;
        }
        public string GetAllGuideNummers()
        {
            ObservableCollection<Algorithm> algorithms = db.Query<Algorithm>("GetAlgorithms", commandType: CommandType.StoredProcedure).ToObservableCollection();
            // sorteer op nummer
            var testen = algorithms.OrderBy(c => c.Nummer);
            // een gestructureerde string maken van de bestaande om nummers te tonen in de messagebox

            string _allNumbers = null;
            int teller = 0;
            foreach (var test in testen)
            {
                _allNumbers += test.Nummer + "\t";
                teller++;
                if (teller == 6)
                {
                    _allNumbers += "\n";
                    teller = 0;
                }
            }
            return _allNumbers;
        }
        public void DeleteAlgorithm(Algorithm algorithm)
        {
            //delete eerst resultaten die bij deze algorithm horen
            db.Execute("DeleteResultaatByAlgorithmId", new { Id = algorithm.Id }, commandType: CommandType.StoredProcedure);
            db.Execute("DeleteAlgorithm", new { Id = algorithm.Id }, commandType: CommandType.StoredProcedure);
        }

    }
}
