using AlgorithmTrainer.Extensions;
using AlgorithmTrainer.Messages;
using AlgorithmTrainer.Model;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AlgorithmTrainer.ViewModel
{
    class AlgorithmWindowViewModel : BaseViewModel
    {
        //*****DECLAREREN*****
        private DialogService _dialogService;
        private ICommand _exitCommand;
        private DateTime _huidigeDag = DateTime.Today;
        private DateTime _datum;
        private ObservableCollection<Algorithm> _algorithms;
        private Algorithm _selectedAlgorithm;
        private ICommand _wijzigAlgorithmCommand;
        private ICommand _voegAlgorithmToeCommand;
        private bool _backWithRefresh = false;

        //*****GETTERS & SETTERS*****
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
        public DateTime HuidigeDag
        {
            get
            {
                return _huidigeDag;
            }

            set
            {
                _huidigeDag = value;
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
        public ICommand WijzigAlgorithmCommand
        {
            get
            {
                return _wijzigAlgorithmCommand;
            }

            set
            {
                _wijzigAlgorithmCommand = value;
            }
        }
        public ICommand VoegAlgorithmToeCommand
        {
            get
            {
                return _voegAlgorithmToeCommand;
            }

            set
            {
                _voegAlgorithmToeCommand = value;
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

        //*****CONSTRUCTOR*****
        public AlgorithmWindowViewModel()
        {
            //laden data
            AlgorithmDataService ads = new AlgorithmDataService();
            Algorithms = ads.GetAlgorithmsWithCategorie();

            //koppelen commands
            ExitCommand = new BaseCommand(Exit);
            WijzigAlgorithmCommand = new BaseCommand(WijzigAlgorithm);
            VoegAlgorithmToeCommand = new BaseCommand(VoegAlgorithmToe);

            //instantiëren DialogService als singleton
            _dialogService = new DialogService();

            //luisteren naar updates vanuit detailvenster
            Messenger.Default.Register<UpdateFinishedMessage>(this, OnMessageReceived);
        }

        //*****PROGRAMMA*****
        public void WijzigAlgorithm()
        {
            if (SelectedAlgorithm != null)
            {
                Messenger.Default.Send<Algorithm>(SelectedAlgorithm);
                _dialogService.ShowAlgorithmDetailDialog();
            }
        }
        public void VoegAlgorithmToe()
        {
            Messenger.Default.Send<Algorithm>(new Algorithm());
            _dialogService.ShowAlgorithmDetailDialog();
        }
        public void Exit()
        {
            //enkel refreshen na een insert of delete
            if (BackWithRefresh)
            {
                Messenger.Default.Send<UpdateFinishedMessage>(new UpdateFinishedMessage(UpdateFinishedMessage.MessageType.BackToMainWithRefresh));
            }
            else
            {
                Messenger.Default.Send<UpdateFinishedMessage>(new UpdateFinishedMessage(UpdateFinishedMessage.MessageType.BackToMain));
            }
        }

        //dialog vensters
        private void OnMessageReceived(UpdateFinishedMessage message)
        {
            // altijd refreshen omdat je deze algorithms actief kan zetten en dat getoont moet worden in het overzicht (en al dan niet random gegenereerd moet worden
            BackWithRefresh = true;
            if (message.Type == UpdateFinishedMessage.MessageType.Updated)
            {
                _dialogService.CloseAlgorithmDetailDialog();
            }
            if (message.Type == UpdateFinishedMessage.MessageType.Deleted || message.Type == UpdateFinishedMessage.MessageType.Inserted)
            {
                AlgorithmDataService ads = new AlgorithmDataService();
                Algorithms = ads.GetAlgorithmsWithCategorie();
                _dialogService.CloseAlgorithmDetailDialog();
            }
        }

    }
}
