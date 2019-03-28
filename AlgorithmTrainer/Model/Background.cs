namespace AlgorithmTrainer.Model
{
    class Background : BaseModel
    {
        //declaratie
        private string _naam;

        //getters setters
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

        // constructor
        public Background()
        {
        }
        public Background(string naam)
        {
            Naam = naam;
        }

    }
}
