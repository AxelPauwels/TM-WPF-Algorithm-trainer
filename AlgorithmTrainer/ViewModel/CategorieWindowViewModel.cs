using AlgorithmTrainer.Extensions;
using AlgorithmTrainer.Messages;
using AlgorithmTrainer.Model;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AlgorithmTrainer.ViewModel
{
    class CategorieWindowViewModel : BaseViewModel
    {
        //*****DECLAREREN*****
        private DialogService _dialogService;
        private ICommand _exitCommand;
        private ObservableCollection<Categorie> _categories;
        private ObservableCollection<Algorithm> _categorieAlgorithms;
        private Categorie _selectedCategorie;
        private ICommand _wijzigCategorieCommand;
        private ICommand _voegCategorieToeCommand;

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
        public ObservableCollection<Categorie> Categories
        {
            get
            {
                return _categories;
            }

            set
            {
                _categories = value;
                NotifyPropertyChanged();
            }
        }
        public ObservableCollection<Algorithm> CategorieAlgorithms
        {
            get
            {
                return _categorieAlgorithms;
            }

            set
            {
                _categorieAlgorithms = value;
                NotifyPropertyChanged();
            }
        }
        public Categorie SelectedCategorie
        {
            get
            {
                return _selectedCategorie;
            }

            set
            {
                _selectedCategorie = value;
                AlgorithmDataService ads = new AlgorithmDataService();
                try
                {
                    // in try catch omdat indien je een categorie gedelete hebt, de 'selectedCategorie' een id heeft waar geen algorithms meer van zijn
                    CategorieAlgorithms = ads.GetAlgorithmsByCategorieId(SelectedCategorie.Id);
                }
                catch (Exception)
                {
                    // anders leegmaken, zodat er geen OLL images meer worden getoont
                    CategorieAlgorithms = null;
                }
                NotifyPropertyChanged();
            }
        }
        public ICommand WijzigCategorieCommand
        {
            get
            {
                return _wijzigCategorieCommand;
            }

            set
            {
                _wijzigCategorieCommand = value;
            }
        }
        public ICommand VoegCategorieToeCommand
        {
            get
            {
                return _voegCategorieToeCommand;
            }

            set
            {
                _voegCategorieToeCommand = value;
            }
        }

        //*****CONSTRUCTOR*****
        public CategorieWindowViewModel()
        {
            //laden data
            CategorieDataService cds = new CategorieDataService();
            Categories = cds.GetCategories();

            //koppelen commands
            ExitCommand = new BaseCommand(Exit);
            WijzigCategorieCommand = new BaseCommand(WijzigCategorie);
            VoegCategorieToeCommand = new BaseCommand(VoegCategorieToe);

            //instantiëren DialogService als singleton
            _dialogService = new DialogService();

            //luisteren naar updates vanuit categorieDetail
            Messenger.Default.Register<UpdateFinishedMessage>(this, OnMessageReceived);
        }

        //*****PROGRAMMA*****
        public void WijzigCategorie()
        {
            if (SelectedCategorie != null)
            {
                Messenger.Default.Send<Categorie>(SelectedCategorie);
                _dialogService.ShowCategorieDetailDialog();
            }
        }
        public void VoegCategorieToe()
        {
            Messenger.Default.Send<Categorie>(new Categorie());
            _dialogService.ShowCategorieDetailDialog();
        }
        public void Exit()
        {
            Messenger.Default.Send<UpdateFinishedMessage>(new UpdateFinishedMessage(UpdateFinishedMessage.MessageType.BackToMain));
        }

        //dialog vensters
        private void OnMessageReceived(UpdateFinishedMessage message)
        {
            if (message.Type == UpdateFinishedMessage.MessageType.Updated)
            {
                _dialogService.CloseCategorieDetailDialog();
            }
            if (message.Type == UpdateFinishedMessage.MessageType.Deleted || message.Type == UpdateFinishedMessage.MessageType.Inserted)
            {
                CategorieDataService cds = new CategorieDataService();
                Categories = cds.GetCategories();
                _dialogService.CloseCategorieDetailDialog();
            }
        }

    }
}
