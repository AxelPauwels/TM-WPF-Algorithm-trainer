using AlgorithmTrainer.Extensions;
using AlgorithmTrainer.Messages;
using AlgorithmTrainer.Model;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Input;

namespace AlgorithmTrainer.ViewModel
{
    class ResultaatWindowViewModel : BaseViewModel
    {
        //*****DECLAREREN*****
        private DialogService _dialogService;
        private ObservableCollection<Resultaat> _datums = new ObservableCollection<Resultaat>();
        private ObservableCollection<Resultaat> _resultaten;
        private ObservableCollection<Resultaat> _resultatenOpDatum;
        private ObservableCollection<Algorithm> _algorithms;
        private Resultaat _selectedDatum;
        private Resultaat _selectedResultaat;
        private Algorithm _selectedAlgorithm;
        private ICommand _exitCommand;
        private ICommand _wijzigResultaatCommand;
        private ICommand _voegResultaatToeCommand;
        private ICommand _deleteResultaatCommand;
        private bool _backWithRefresh = false;
        private bool _deleteButtonEnabled = true;

        //*****GETTERS & SETTERS*****
        public ObservableCollection<Resultaat> Datums
        {
            get
            {
                return _datums;
            }

            set
            {
                _datums = value;
                NotifyPropertyChanged();
            }
        }
        public ObservableCollection<Resultaat> Resultaten
        {
            get
            {
                return _resultaten;
            }

            set
            {
                _resultaten = value;
                NotifyPropertyChanged();
            }
        }
        public ObservableCollection<Resultaat> ResultatenOpDatum
        {
            get
            {
                return _resultatenOpDatum;
            }

            set
            {
                _resultatenOpDatum = value;
                NotifyPropertyChanged();
            }
        }
        public ObservableCollection<Algorithm> Algorithms
        {
            get
            {
                return _algorithms;
            }

            set
            {
                _algorithms = value;
                NotifyPropertyChanged();
            }
        }
        public Resultaat SelectedDatum
        {
            get
            {
                return _selectedDatum;
            }

            set
            {
                _selectedDatum = value;
                ResultaatDataService rds = new ResultaatDataService();
                try
                {
                    // in try catch omdat indien je een datum gedelete hebt, de 'selectedResultaat' een id heeft waar geen resultaten meer van zijn
                    ResultatenOpDatum = rds.GetResultatenOpDatum(SelectedDatum);
                }
                catch (Exception)
                {
                    // anders niets doen
                }
                NotifyPropertyChanged();
            }
        }
        public Resultaat SelectedResultaat
        {
            get
            {
                return _selectedResultaat;
            }

            set
            {
                _selectedResultaat = value;
                // bij het selecteren van een resultaat , de combobox laten weten welke oll moet geselecteerd worden
                try
                {
                    foreach (var Algorithm in Algorithms)
                    {
                        if (SelectedResultaat.AlgorithmId == Algorithm.Id)
                        {
                            SelectedAlgorithm = Algorithm;
                        }
                    }
                }
                catch (Exception)
                {
                    // anders niets doen
                }

                NotifyPropertyChanged();
            }
        }
        public Algorithm SelectedAlgorithm
        {
            get
            {
                return _selectedAlgorithm;
            }

            set
            {
                _selectedAlgorithm = value;
                try
                {
                    SelectedResultaat.AlgorithmId = SelectedAlgorithm.Id;
                }
                catch (Exception)
                {
                    // anders niets doen
                }
                NotifyPropertyChanged();
            }
        }
        public ICommand ExitCommand
        {
            get
            {
                return _exitCommand;
            }

            set
            {
                _exitCommand = value;
            }
        }
        public ICommand WijzigResultaatCommand
        {
            get
            {
                return _wijzigResultaatCommand;
            }

            set
            {
                _wijzigResultaatCommand = value;
            }
        }
        public ICommand VoegResultaatToeCommand
        {
            get
            {
                return _voegResultaatToeCommand;
            }

            set
            {
                _voegResultaatToeCommand = value;
            }
        }
        public ICommand DeleteResultaatCommand
        {
            get
            {
                return _deleteResultaatCommand;
            }

            set
            {
                _deleteResultaatCommand = value;
            }
        }
        public bool BackWithRefresh
        {
            get
            {
                return _backWithRefresh;
            }

            set
            {
                _backWithRefresh = value;
                NotifyPropertyChanged();
            }
        }
        public bool DeleteButtonEnabled
        {
            get
            {
                return _deleteButtonEnabled;
            }

            set
            {
                _deleteButtonEnabled = value;
                NotifyPropertyChanged();
            }
        }

        //*****CONSTRUCTOR*****
        public ResultaatWindowViewModel()
        {
            //laden data
            AlgorithmDataService ads = new AlgorithmDataService();
            Algorithms = ads.GetAlgorithms(0);
            ResultaatDataService rds = new ResultaatDataService();
            Resultaten = rds.GetResultaten();

            // unieke datums uit de collection halen en opslaan in 'Datums'
            DateTime _vorigeDatum = new DateTime().Date;
            foreach (Resultaat Resultaat in Resultaten)
            {
                if (Resultaat.Datum.Date != _vorigeDatum)
                {
                    Datums.Add(Resultaat);
                    _vorigeDatum = Resultaat.Datum.Date;
                }
            }

            //koppelen commands
            ExitCommand = new BaseCommand(Exit);
            WijzigResultaatCommand = new BaseCommand(WijzigResultaat);
            VoegResultaatToeCommand = new BaseCommand(VoegResultaatToe);
            DeleteResultaatCommand = new BaseCommand(DeleteResultaat);

            //instantiëren DialogService als singleton
            _dialogService = new DialogService();
        }

        //*****PROGRAMMA*****
        public void refreshResutaten()
        {
            Resultaten.Clear();
            ResultaatDataService rds = new ResultaatDataService();
            Resultaten = rds.GetResultaten();

            Datums.Clear();
            // unieke datums uit de collection halen en opslaan in 'Datums'
            DateTime _vorigeDatum = new DateTime().Date;
            foreach (Resultaat Resultaat in Resultaten)
            {
                if (Resultaat.Datum.Date != _vorigeDatum)
                {
                    Datums.Add(Resultaat);
                    _vorigeDatum = Resultaat.Datum.Date;
                }
            }
        }
        public void WijzigResultaat()
        {
            if (SelectedResultaat != null)
            {
                BackWithRefresh = true;
                ResultaatDataService rds = new ResultaatDataService();
                // controleren of de fields zijn ingevuld
                if (SelectedResultaat.Datum == null || SelectedResultaat.AlgorithmId < 1)
                {
                    MessageBoxResult result = MessageBox.Show("Please fill in all fields.",
                    "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    // controleren of update of insert moet zijn
                    if (SelectedResultaat.Id == 0)
                    {
                        rds.RegisterTime(SelectedResultaat.Sessie, SelectedResultaat.AlgorithmId, SelectedResultaat.Datum, SelectedResultaat.Tijd);
                    }
                    else
                    {
                        rds.UpdateTime(SelectedResultaat);
                    }
                    BackWithRefresh = true;
                    // datum selecteren om te refreshen met binding
                    SelectedDatum = SelectedResultaat;
                    refreshResutaten();
                }
                //Resultaat leegmaken om messagebox te tonen "You have selected a Date, not a Result..." in functie deleteResultaat()
                SelectedResultaat = null;
                SelectedAlgorithm = null;
                // delete button inschakelen
                DeleteButtonEnabled = true;
            }
        }
        public void VoegResultaatToe()
        {
            // delete button uitschakelen
            DeleteButtonEnabled = false;
            SelectedResultaat = null;
            SelectedAlgorithm = null;
            // nieuw resultaat maken
            decimal _tijd = 0.0m;
            Resultaat nieuwresultaat = new Resultaat();
            try
            {
                // gebruik de geselecteerde datum indien mogelijk, anders gebruik de huidige datum
                nieuwresultaat.Datum = SelectedDatum.Datum;
            }
            catch (Exception)
            {
                nieuwresultaat.Datum = DateTime.Now;
            }
            nieuwresultaat.Tijd = (_tijd);
            SelectedResultaat = nieuwresultaat;
        }
        public void DeleteResultaat()
        {
            BackWithRefresh = true;
            ResultaatDataService rds = new ResultaatDataService();

            // kijken of je enkel 1 resutaat wil wissen of een datum met al zijn resultaten
            if (SelectedResultaat == null && SelectedDatum != null)
            {
                // datum met zijn resultaten wissen 
                MessageBoxResult result = MessageBox.Show("You have selected a Date, not a Result." + "\n" + "Are you sure you want to delete all Results of this Date?",
            "Delete more Results?", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        rds.DeleteTimesByDate(SelectedDatum);
                        ResultatenOpDatum = rds.GetResultatenOpDatum(SelectedDatum);
                        refreshResutaten();
                        break;
                }
            }
            else
            {
                if (SelectedResultaat != null || SelectedDatum != null)
                {
                    // 1 resultaat deleten en de gegevens refreshen 
                    rds.DeleteTime(SelectedResultaat.Id);
                    SelectedDatum = SelectedResultaat;
                    refreshResutaten();
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("There is nothing selected to delete." + "\n" + "Please select a Date or Result.",
                      "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
        public void Exit()
        {
            if (BackWithRefresh)
            {
                Messenger.Default.Send<UpdateFinishedMessage>(new UpdateFinishedMessage(UpdateFinishedMessage.MessageType.BackToMainWithRefresh));
            }
            else
            {
                Messenger.Default.Send<UpdateFinishedMessage>(new UpdateFinishedMessage(UpdateFinishedMessage.MessageType.BackToMain));
            }
        }


    }
}
