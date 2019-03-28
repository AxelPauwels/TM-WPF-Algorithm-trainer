using System;
using System.Linq;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Dapper;
using System.Collections.ObjectModel;
using AlgorithmTrainer.Extensions;
using System.Globalization;

namespace AlgorithmTrainer.Model
{
    class ResultaatDataService
    {
        // Ophalen ConnectionString uit App.config
        private static string connectionString =
        ConfigurationManager.ConnectionStrings["azure"].ConnectionString;

        // Stap 1 Dapper
        // Aanmaken van een object uit de IDbConnection class en 
        // instantiëren van een SqlConnection.
        // Dit betekent dat de connectie met de database automatisch geopend wordt.
        private static IDbConnection db = new SqlConnection(connectionString);

        public int GetLastSession()
        {
            int _lastSession;
            try
            {
                _lastSession = db.Query<int>("GetLastSession", commandType: CommandType.StoredProcedure).Single();
            }
            catch (Exception)
            {
                // indien er geen resultaten in de database zitten, de sessie op 0 zetten
                _lastSession = 0;
            }
            return _lastSession;
        }
        public ObservableCollection<Resultaat> GetResultaten()
        {
            ObservableCollection<Resultaat> resultaten = db.Query<Resultaat>("GetResultaten", commandType: CommandType.StoredProcedure).ToObservableCollection();
            return resultaten;
        }
        public ObservableCollection<Resultaat> GetResultatenOpDatum(Resultaat selectedResultaatDatum)
        {
            DateTime Begintijd = selectedResultaatDatum.Datum.Date;
            DateTime Eindtijd = selectedResultaatDatum.Datum.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            ObservableCollection<Resultaat> resultaten = db.Query<Resultaat>("GetResultatenOpDatum", new { Begintijd, Eindtijd }, commandType: CommandType.StoredProcedure).ToObservableCollection();
            return resultaten;
        }
        public int RegisterTime(int sessie, int algorithmId, DateTime datum, decimal tijd)
        {
            int id = db.Query<int>("InsertResultaat", new { sessie, algorithmId, datum, tijd }, commandType: CommandType.StoredProcedure).Single();
            return id;
        }
        public void DeleteTime(int LaatsteId)
        {
            db.Execute("DeleteResultaatById", new { Id = LaatsteId }, commandType: CommandType.StoredProcedure);
        }
        public void DeleteTimesByDate(Resultaat resultaat)
        {
            DateTime Begintijd = resultaat.Datum.Date;
            DateTime Eindtijd = resultaat.Datum.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            db.Execute("DeleteTimeByDate", new { Begintijd, Eindtijd }, commandType: CommandType.StoredProcedure);
        }
        public void UpdateTime(Resultaat resultaat)
        {
            db.Execute("UpdateResultaat", new { Sessie = resultaat.Sessie, AlgorithmId = resultaat.AlgorithmId, Datum = resultaat.Datum, Tijd = resultaat.Tijd, Id = resultaat.Id }, commandType: CommandType.StoredProcedure);
        }

    }
}
