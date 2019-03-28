using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Dapper;
using System.Collections.ObjectModel;
using AlgorithmTrainer.Extensions;
using System.Linq;

namespace AlgorithmTrainer.Model
{
    class CategorieDataService
    {
        // Ophalen ConnectionString uit App.config
        private static string connectionString =
        ConfigurationManager.ConnectionStrings["azure"].ConnectionString;

        // Stap 1 Dapper
        // Aanmaken van een object uit de IDbConnection class en 
        // instantiëren van een SqlConnection.
        // Dit betekent dat de connectie met de database automatisch geopend wordt.
        private static IDbConnection db = new SqlConnection(connectionString);

        public ObservableCollection<Categorie> GetCategories()
        {
            //Type casten van het generieke return type naar een collectie 
            ObservableCollection<Categorie> categories = db.Query<Categorie>("GetCategories", commandType: CommandType.StoredProcedure).ToObservableCollection();
            return categories;
        }
        public void UpdateCategorie(Categorie categorie)
        {
            db.Execute("UpdateCategorie", new { Naam = categorie.Naam, Id = categorie.Id }, commandType: CommandType.StoredProcedure);
        }
        public void InsertCategorie(Categorie categorie)
        {
            db.Execute("InsertCategorie", new { Naam = categorie.Naam }, commandType: CommandType.StoredProcedure);
        }
        public void DeleteCategorie(Categorie categorie)
        {
            //delete eerst resultaten die bij deze algorithm horen
            ObservableCollection<Algorithm> algorithms = db.Query<Algorithm>("GetAlgorithmsByCategorieId", new { Id = categorie.Id }, commandType: CommandType.StoredProcedure).ToObservableCollection();
            if (algorithms != null)
            {
                foreach (var algorithm in algorithms)
                {
                    db.Execute("DeleteResultaatByAlgorithmId", new { Id = algorithm.Id }, commandType: CommandType.StoredProcedure);
                }
            }

            //delete dan alle algorithms die bij deze categorie horen
            db.Execute("DeleteAlgorithmByCategorieId", new { Id = categorie.Id }, commandType: CommandType.StoredProcedure);

            //delete categorie
            db.Execute("DeleteCategorie", new { Id = categorie.Id }, commandType: CommandType.StoredProcedure);
        }
        public string CategorieNaamExist(string zoekCategorieNaam)
        {
            string _categorieNaam = "";
            _categorieNaam = db.Query<string>("GetCategorieNaam", new { Naam = zoekCategorieNaam }, commandType: CommandType.StoredProcedure).SingleOrDefault();
            return _categorieNaam;
        }

    }
}
