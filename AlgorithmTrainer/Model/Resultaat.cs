using System;

namespace AlgorithmTrainer.Model
{
    class Resultaat : BaseModel
    {
        //declaratie
        private int _id;
        private int _sessie;
        private int _algorithmId;
        private DateTime _datum;
        private decimal _tijd;

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
        public int Sessie
        {
            get
            {
                return _sessie;
            }

            set
            {
                _sessie = value;
                NotifyPropertyChanged();
            }
        }
        public int AlgorithmId
        {
            get
            {
                return _algorithmId;
            }

            set
            {
                _algorithmId = value;
                NotifyPropertyChanged();
            }
        }
        public DateTime Datum
        {
            get
            {
                return _datum;
            }

            set
            {
                _datum = value;
                NotifyPropertyChanged();
            }
        }
        public decimal Tijd
        {
            get
            {
                return _tijd;
            }

            set
            {
                _tijd = value;
                NotifyPropertyChanged();
            }
        }

        //constructor
        public Resultaat()
        {
        }
        public Resultaat(int id, int sessie, int algorithmId, DateTime datum, decimal tijd)
        {
            Id = id;
            Sessie = sessie;
            AlgorithmId = algorithmId;
            Datum = datum;
            Tijd = tijd;
        }

    }
}
