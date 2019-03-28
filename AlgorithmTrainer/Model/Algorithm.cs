namespace AlgorithmTrainer.Model
{
    class Algorithm : BaseModel
    {
        //declaratie
        private int _id;
        private int _categorieId;
        private int _nummer;
        private string _afbeelding;
        private string _algorithmSolution;
        private bool _actief;
        private decimal _resultaatBest;
        private decimal _resultaatWorst;
        private decimal _resultaatAverage;
        private int _resultaatProgress;
        private string _actiefColor;
        private string _categorieNaam;

        // getters setters
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
        public int CategorieId
        {
            get
            {
                return _categorieId;
            }

            set
            {
                _categorieId = value;
                NotifyPropertyChanged();
            }
        }
        public int Nummer
        {
            get
            {
                return _nummer;
            }

            set
            {
                _nummer = value;
                NotifyPropertyChanged();
            }
        }
        public string Afbeelding
        {
            get
            {
                return _afbeelding;
            }

            set
            {
                _afbeelding = value;
                NotifyPropertyChanged();
            }
        }
        public string AlgorithmSolution
        {
            get
            {
                return _algorithmSolution;
            }

            set
            {
                _algorithmSolution = value;
                NotifyPropertyChanged();
            }
        }
        public bool Actief
        {
            get
            {
                return _actief;
            }

            set
            {
                _actief = value;
                NotifyPropertyChanged();
            }
        }
        public decimal ResultaatBest
        {
            get
            {
                return _resultaatBest;
            }

            set
            {
                _resultaatBest = value;
                NotifyPropertyChanged();
            }
        }
        public decimal ResultaatWorst
        {
            get
            {
                return _resultaatWorst;
            }

            set
            {
                _resultaatWorst = value;
                NotifyPropertyChanged();
            }
        }
        public decimal ResultaatAverage
        {
            get
            {
                return _resultaatAverage;
            }

            set
            {
                _resultaatAverage = value;
                NotifyPropertyChanged();
            }
        }
        public int ResultaatProgress
        {
            get
            {
                return _resultaatProgress;
            }

            set
            {
                _resultaatProgress = value;
                NotifyPropertyChanged();
            }
        }
        public string ActiefColor
        {
            get
            {
                return _actiefColor;
            }

            set
            {
                _actiefColor = value;
                NotifyPropertyChanged();
            }
        }
        public string CategorieNaam
        {
            get
            {
                return _categorieNaam;
            }

            set
            {
                _categorieNaam = value;
                NotifyPropertyChanged();
            }
        }

        // constructor
        public Algorithm()
        {
        }
        public Algorithm(int id, int categorieId, int nummer, string afbeelding, string algorithmSolution, bool actief)
        {
            Id = id;
            CategorieId = categorieId;
            Nummer = nummer;
            Afbeelding = afbeelding;
            AlgorithmSolution = algorithmSolution;
            Actief = actief;
        }

    }
}
