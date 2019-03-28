namespace AlgorithmTrainer.Model
{
    class Categorie : BaseModel
    {
        //declaratie
        private int _id;
        private string _naam;

        //getters setters
        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
                NotifyPropertyChanged();
            }
        }
        public string Naam
        {
            get
            {
                return _naam;
            }

            set
            {
                _naam = value;
                NotifyPropertyChanged();
            }
        }

        //constructor
        public Categorie ()
        {
        }
        public Categorie(int id, string naam)
        {
            Id = id;
            Naam = naam;
        }

    }
}
