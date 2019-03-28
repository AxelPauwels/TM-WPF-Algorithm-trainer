using AlgorithmTrainer.Extensions;
using AlgorithmTrainer.Messages;
using AlgorithmTrainer.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Media;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace AlgorithmTrainer.ViewModel
{
    class MainWindowViewModel : BaseViewModel
    {
        //*****DECLAREREN*****
        //Menu
        private string _background = System.AppDomain.CurrentDomain.BaseDirectory + "/images/backgrounds/background5.jpg";
        private string _afbeeldingPath = (System.AppDomain.CurrentDomain.BaseDirectory + "images\\OLL\\").Replace("\\", "/");
        private ObservableCollection<Background> _backgrounds;
        private Background _selectedBackground;
        private ICommand _editAlgorithmsCommand;
        private ICommand _editCategoriesCommand;
        private ICommand _editResultatenCommand;
        private ICommand _aboutCommand;
        //algemeen
        private string _progressVisibility = "Hidden";
        private static DateTime _huidigeDag = DateTime.Now;
        private DialogService _dialogService;
        private ObservableCollection<Algorithm> _algorithms;
        private ObservableCollection<Resultaat> _resultaten;
        private List<int> _actieveAlgorithmIds = new List<int>(); //om te weten welke algorihms actief zijn na ze aan te passen in het programma      
        private ICommand _algorithmActiefCommand;
        private int _laatsteInsertedId;
        private Algorithm _selectedAlgorithm;  //om te zien welke algorithm random is gegenereerd in het overzicht
        private int _nieuweSessie; // tijdens het opstarten een nieuwe sessie starten
        private int _gekozenSessie;
        private bool _functionIsActive = true;
        //random image
        private Algorithm _randomAlgorithm;
        private string _randomAlgorithmImage;
        //timer
        private bool _skipInspection = false;
        private bool _timerOn = true;
        private bool _inspectionOn = false;
        private string _timerStatus = "START";
        private decimal _elapsedTime;
        private string _timerDisplay;
        private DispatcherTimer _timer = new DispatcherTimer();
        private Stopwatch _stopWatch = new Stopwatch();
        //timer2(countdown) + settings
        private DispatcherTimer _timer2 = new DispatcherTimer();
        private int _inspectionTime = 3;
        private int _inspection;
        // buttons
        private bool _isEnabled = true;
        private ICommand _timerCommand;
        private ICommand _deleteLastTimeCommand;
        private ICommand _resetActiveCommand;
        // settings
        private bool _playSound = true;
        private SoundPlayer _sound = new SoundPlayer(System.AppDomain.CurrentDomain.BaseDirectory + "/sounds/sound.wav");
        private bool _showResultsBySession = true;

        //*****GETTERS & SETTERS*****
        //Menu
        public string Background
        {
            get
            {
                return _background;
            }

            set
            {
                _background = value;
                NotifyPropertyChanged();
            }
        }
        public string AfbeeldingPath
        {
            get
            {
                return _afbeeldingPath;
            }

            set
            {
                _afbeeldingPath = value;
                NotifyPropertyChanged();
            }
        }
        public ObservableCollection<Background> Backgrounds
        {
            get
            {
                return _backgrounds;
            }

            set
            {
                _backgrounds = value;
                NotifyPropertyChanged();
            }
        }
        public Background SelectedBackground
        {
            get
            {
                return _selectedBackground;
            }

            set
            {
                _selectedBackground = value;
                NotifyPropertyChanged();
            }
        }
        public ICommand EditAlgorithmsCommand
        {
            get
            {
                return _editAlgorithmsCommand;
            }

            set
            {
                _editAlgorithmsCommand = value;
            }
        }
        public ICommand EditCategoriesCommand
        {
            get
            {
                return _editCategoriesCommand;
            }

            set
            {
                _editCategoriesCommand = value;
            }
        }
        public ICommand EditResultatenCommand
        {
            get
            {
                return _editResultatenCommand;
            }

            set
            {
                _editResultatenCommand = value;
            }
        }
        public ICommand AboutCommand
        {
            get
            {
                return _aboutCommand;
            }

            set
            {
                _aboutCommand = value;
            }
        }
        //algemeen
        public string ProgressVisibility
        {
            get
            {
                return _progressVisibility;
            }

            set
            {
                _progressVisibility = value;
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
        public List<int> ActieveAlgorithmIds
        {
            get
            {
                return _actieveAlgorithmIds;
            }

            set
            {
                _actieveAlgorithmIds = value;
                NotifyPropertyChanged();
            }
        }
        public ICommand AlgorithmActiefCommand
        {
            get
            {
                return _algorithmActiefCommand;
            }

            set
            {
                _algorithmActiefCommand = value;
            }
        }
        public int LaatsteInsertedId
        {
            get
            {
                return _laatsteInsertedId;
            }

            set
            {
                _laatsteInsertedId = value;
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
                NotifyPropertyChanged();
            }
        }
        public bool FunctionIsActive
        {
            get
            {
                return _functionIsActive;
            }

            set
            {
                _functionIsActive = value;
                NotifyPropertyChanged();
            }
        }
        //random image
        public Algorithm RandomAlgorithm
        {
            get
            {
                return _randomAlgorithm;
            }

            set
            {
                _randomAlgorithm = value;
                NotifyPropertyChanged();
            }
        }
        public string RandomAlgorithmImage
        {
            get
            {
                return _randomAlgorithmImage;
            }

            set
            {
                _randomAlgorithmImage = value;
                NotifyPropertyChanged();
            }
        }
        //timer
        public bool SkipInspection
        {
            get
            {
                return _skipInspection;
            }

            set
            {
                _skipInspection = value;
                NotifyPropertyChanged();
            }
        }
        public bool TimerOn
        {
            get
            {
                return _timerOn;
            }

            set
            {
                _timerOn = value;
                NotifyPropertyChanged();
            }
        }
        public bool InspectionOn
        {
            get
            {
                return _inspectionOn;
            }

            set
            {
                _inspectionOn = value;
                NotifyPropertyChanged();
            }
        }
        public string TimerStatus
        {
            get
            {
                return _timerStatus;
            }

            set
            {
                _timerStatus = value;
                NotifyPropertyChanged();
            }
        }
        public string TimerDisplay
        {
            get
            {
                return _timerDisplay;
            }

            set
            {
                _timerDisplay = value;
                NotifyPropertyChanged();
            }
        }
        //timer2(countdown)
        public int InspectionTime
        {
            get
            {
                return _inspectionTime;
            }

            set
            {
                _inspectionTime = value;
                if (_inspectionTime < 0)
                {
                    _inspectionTime = 0;
                    MessageBox.Show("Please enter a positive number.");
                }
                NotifyPropertyChanged();
            }
        }
        //buttons
        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }

            set
            {
                _isEnabled = value;
                NotifyPropertyChanged();
            }
        }
        public ICommand TimerCommand
        {
            get
            {
                return _timerCommand;
            }

            set
            {
                _timerCommand = value;
            }
        }
        public ICommand DeleteLastTimeCommand
        {
            get
            {
                return _deleteLastTimeCommand;
            }

            set
            {
                _deleteLastTimeCommand = value;
            }
        }
        public ICommand ResetActiveCommand
        {
            get
            {
                return _resetActiveCommand;
            }

            set
            {
                _resetActiveCommand = value;
            }
        }
        //settings
        public bool PlaySound
        {
            get
            {
                return _playSound;
            }

            set
            {
                _playSound = value;
                NotifyPropertyChanged();
            }
        }
        public bool ShowResultsBySession
        {
            get
            {
                return _showResultsBySession;
            }

            set
            {
                _showResultsBySession = value;
                NotifyPropertyChanged();
                // enkel de functie uitvoeren wanneer de timer NIET loopt
                if (FunctionIsActive)
                {
                if (_showResultsBySession)
                {
                    _gekozenSessie = _nieuweSessie;
                }
                else
                {
                    _gekozenSessie = 1;
                }
                refreshResultsView();
                }

            }
        }

        //*****CONSTRUCTOR*****
        public MainWindowViewModel()
        {
            //laden data
            ResultaatDataService rds = new ResultaatDataService();
            _nieuweSessie = (rds.GetLastSession() + 1);
            _gekozenSessie = _nieuweSessie;
            AlgorithmDataService ads = new AlgorithmDataService();
            Algorithms = ads.GetAlgorithms(_gekozenSessie);
            BackgroundDataService bds = new BackgroundDataService();
            Backgrounds = bds.GetBackgrounds();
            CreateBackgroundsMenu();
            // ids van algorithms nu al opslaan voor de "generate random algorithm" , dit is nodig om de start functie uit te schakelen indien alles op "niet-actief" staat
            refreshIdList();

            //koppelen commands
            TimerCommand = new BaseCommand(StartStopTimer);
            ResetActiveCommand = new BaseCommand(ResetActive);
            DeleteLastTimeCommand = new BaseCommand(DeleteLastTime);
            AlgorithmActiefCommand = new ParameterCommand(AlgorithmActief);
            EditAlgorithmsCommand = new BaseCommand(EditAlgorithms);
            EditCategoriesCommand = new BaseCommand(EditCategories);
            EditResultatenCommand = new BaseCommand(EditResultaten);
            AboutCommand = new BaseCommand(About);

            // timer + timer2(countdown)
            _timer.Tick += new EventHandler(timer_Tick);
            _timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            _timer2.Tick += new EventHandler(timer2_Tick);
            _timer2.Interval = new TimeSpan(0, 0, 0, 1, 0);

            //instantiëren DialogService als singleton
            _dialogService = new DialogService();

            //luisteren naar updates vanuit detailvenster
            Messenger.Default.Register<UpdateFinishedMessage>(this, OnMessageReceived);
        }

        //*****PROGRAMMA*****

        // menu backgrounds
        private void CreateBackgroundsMenu()
        {
            var rootmenu = new BackgroundMenu { Header = "Backgrounds", CommandParameter = "backgrounds" };
            MenuItems.Add(rootmenu);

            foreach (var background in Backgrounds)
            {
                var submenu = new BackgroundMenu { Header = background.Naam, CommandParameter = background.Naam };
                submenu.FileMenuClick += MenuItemClick;
                rootmenu.Items.Add(submenu);
            }
        }
        public virtual void MenuItemClick(object sender, BackgroundMenuEventArgs args)
        {
            string naam = ((BackgroundMenu)sender).Header;
            Background = System.AppDomain.CurrentDomain.BaseDirectory + "/images/backgrounds/" + naam + ".jpg";
        }
        private ObservableCollection<BackgroundMenu> _menuItems;
        public ObservableCollection<BackgroundMenu> MenuItems
        {
            get
            {
                return (_menuItems = _menuItems ??
                                     new ObservableCollection<BackgroundMenu>());
            }
        }
        private void refreshIdList()
        {
            ActieveAlgorithmIds.Clear();
            foreach (var Algorithm in Algorithms)
            {
                if (Algorithm.Actief)
                {
                    ActieveAlgorithmIds.Add(Algorithm.Id);
                }
            }
        }

        // random algorithm genereren uit de collection 'Algorithm' (die enkel de actieve algorithms bevatten)
        private void generateRandomAlgorithm()
        {
            // enkel een random algorithm genereren indien en minstens 1 Algorithm "actief" is 
            if (ActieveAlgorithmIds.Count > 0)
            {
                refreshIdList();
                // random id ophalen uit de lijst 'ids'  
                Random getal = new Random();
                int _randomIndex = getal.Next(ActieveAlgorithmIds.Count);
                int _randomId = ActieveAlgorithmIds[_randomIndex];

                // randomAlgorithm ophalen met de randomId
                foreach (var Algorithm in Algorithms)
                {
                    if (Algorithm.Id == _randomId)
                    {
                        RandomAlgorithm = Algorithm;
                    }
                }
                // imagenaam opslaan 
                RandomAlgorithmImage = AfbeeldingPath + RandomAlgorithm.Afbeelding;
            }
        }
        // buttons
        // button_DeleteLastTime
        private void DeleteLastTime()
        {
            // enkel uitvoeren wanneer de timer NIET loopt
            if (FunctionIsActive)
            {
                ResultaatDataService rds = new ResultaatDataService();
                rds.DeleteTime(LaatsteInsertedId);
                try
                {
                    refreshLastAlgorithm(RandomAlgorithm.Id);
                }
                catch (Exception)
                {
                    // geen update doen wanneer er geen RandomAlgorithm Id is
                }
            }
            
        }
        private async void refreshResultsView()
        {
            var slowTask = Task<string>.Factory.StartNew(() => resfreshInBackground());
            ProgressVisibility = "Visible";
            IsEnabled = false;
            await slowTask;
            ProgressVisibility = "Hidden";
            IsEnabled = true;
        }
        private string resfreshInBackground()
        {
            AlgorithmDataService ads = new AlgorithmDataService();
            Algorithms = ads.GetAlgorithms(_gekozenSessie);
            return "Done";
        }
        private void refreshLastAlgorithm(int _algorithmId)
        {
            // enkel 1 algorithm updaten (de getoonde random algorithm of de geselecteerde algorithm in OLL overzicht)
            foreach (var Algorithm in Algorithms)
            {
                if (Algorithm.Id == _algorithmId)
                {
                    AlgorithmDataService ads = new AlgorithmDataService();
                    var updatedAlgorithm = ads.RefreshLastAlgorithm(_gekozenSessie, Algorithm);
                    Algorithm.ResultaatAverage = updatedAlgorithm.ResultaatAverage;
                    Algorithm.ResultaatBest = updatedAlgorithm.ResultaatBest;
                    Algorithm.ResultaatWorst = updatedAlgorithm.ResultaatWorst;
                    Algorithm.ResultaatProgress = updatedAlgorithm.ResultaatProgress;
                    Algorithm.Actief = updatedAlgorithm.Actief;
                    Algorithm.ActiefColor = updatedAlgorithm.ActiefColor;
                }
            }
        }
        private void AlgorithmActief(object algorithmId)
        {
            int _algorithmId = (int)algorithmId;
            AlgorithmDataService ads = new AlgorithmDataService();
            ads.SetAlgorithmActief(_algorithmId);
            // de algorithm updaten in collection 'Algorithms'
            refreshLastAlgorithm(_algorithmId);
            refreshIdList(); //om terug te kijken welke algorithms random mogen gegenereerd worden 
        }
        // Button_Start
        // timer stoppen | timer2(countdown) starten
        private void StartStopTimer()
        {
            // ButtonClick tijdens inpectieTijd
            if (InspectionOn)
            {
                SkipInspection = true;
            }
            else
            {
                SkipInspection = false;
            }

            // ButtonClick tijdens de timer loopt
            if (TimerOn == false)
            {
                TimerOn = true;
                // timer stoppen
                _stopWatch.Stop();
                // text knop aanpassen
                TimerStatus = "START";
                if (InspectionOn == false)
                {
                    // verstreken tijd opslaan
                    ResultaatDataService rds = new ResultaatDataService();
                    LaatsteInsertedId = rds.RegisterTime(_nieuweSessie, RandomAlgorithm.Id, _huidigeDag, _elapsedTime);
                    refreshLastAlgorithm(RandomAlgorithm.Id);
                    //wanneer de timer start, de "reset active", "delete last" en "show only this sessions" inschakelen
                    FunctionIsActive = true;
                }
            }

            // ButtonClick wanneer geen timer loopt (BEGINSTATUS)
            else
            {
                // enkel de timer kunnen starten indien er tenminste 1 algorithm "actief" is
                if (ActieveAlgorithmIds.Count > 0)
                {
                    //wanneer de timer start, de "reset active", "delete last" en "show only this sessions" uitshakelen
                    FunctionIsActive = false;
                    TimerOn = false;
                    //nieuw algorithm uit collection halen
                    generateRandomAlgorithm();
                    //countdown starten
                    _inspection = InspectionTime;
                    _timer2.Start();
                    TimerStatus = "Inspection";
                    TimerDisplay = _inspection.ToString();
                }
                else
                {
                    MessageBox.Show("All Alorithms are disabled. Please enable some Algorithms to use the timer.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            if (_stopWatch.IsRunning)
            {
                // tijd van de timer omzetten naar een decimal om op te slaan in de database (decimal om later een gemiddelde te berekenen)
                TimeSpan ts = _stopWatch.Elapsed;
                _elapsedTime = (decimal)ts.Seconds + ((decimal)ts.Milliseconds / 1000);
                TimerDisplay = String.Format("{1:0},{2:00}",
                ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            }
        }
        // timer2(countdown) | timer starten
        private void timer2_Tick(object sender, EventArgs e)
        {
            TimerOn = false;

            if (_inspection > 1 && SkipInspection == false)
            {
                InspectionOn = true;
                _inspection = _inspection - 1;
                TimerDisplay = _inspection.ToString();
            }
            else
            {
                InspectionOn = false;
                //geluid afspelen indien aangevinkt in het programma
                if (PlaySound)
                {
                    _sound.Play();
                }
                // timer2(countdown) stoppen
                _timer2.Stop();
                // timer starten
                _stopWatch.Reset();
                _stopWatch.Start();
                _timer.Start();
                // text knop aanpassen
                TimerStatus = "STOP";
            }
        }
        // button_ResetActive
        private async void ResetActive()
        {
            // enkel uitvoeren wanneer de timer NIET loopt
            if (FunctionIsActive)
            {
            var slowTask = Task<string>.Factory.StartNew(() => resetActiveInBackground());
            ProgressVisibility = "Visible";
            await slowTask;
            ProgressVisibility = "Hidden";

            refreshIdList();
            refreshResultsView();
            }
        }
        private string resetActiveInBackground()
        {
            //enkel degene updaten in database die momenteel niet actief zijn is performater 
            //dan in de database alles op actief te zetten en vervolgens alle data weer op te halen
            foreach (var Algorithm in Algorithms)
            {
                if (!Algorithm.Actief)
                {
                    AlgorithmDataService ads = new AlgorithmDataService();
                    ads.SetAlgorithmActief(Algorithm.Id);
                    refreshLastAlgorithm(Algorithm.Id);
                }
            }
            return "Done";
        }
        // Dialogvensters
        private void OnMessageReceived(UpdateFinishedMessage message)
        {
            switch (message.Type)
            {
                case UpdateFinishedMessage.MessageType.BackToMain:
                    _dialogService.CloseAlgorithmDialog();
                    _dialogService.CloseCategorieDialog();
                    _dialogService.CloseResultaatDialog();
                    break;
                case UpdateFinishedMessage.MessageType.BackToMainWithRefresh:
                    _dialogService.CloseAlgorithmDialog();
                    _dialogService.CloseResultaatDialog();
                    refreshIdList();
                    refreshResultsView();
                    break;
                default:
                    break;
            }
        }
        public void EditAlgorithms()
        {
            _dialogService.ShowAlgorithmDialog();
        }
        public void EditCategories()
        {
            _dialogService.ShowCategorieDialog();
        }
        public void EditResultaten()
        {
            _dialogService.ShowResultaatDialog();
        }
        public void About()
        {
            _dialogService.ShowAboutDialog();
        }

    }
}
