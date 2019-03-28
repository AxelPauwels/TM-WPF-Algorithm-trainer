using AlgorithmTrainer.Extensions;
using AlgorithmTrainer.Messages;
using AlgorithmTrainer.Model;
using AlgorithmTrainer.Validation;
using System.Windows;
using System.Windows.Input;

namespace AlgorithmTrainer.ViewModel
{
    class CategorieDetailWindowViewModel : BaseViewModel
    {
        //*****DECLAREREN*****
        private DialogService _dialogService;
        private ICommand _updateCommand;
        private ICommand _deleteCommand;
        private Categorie _selectedCategorie;
        private bool _deleteButtonEnabled = true;
        private string _windowTitle;
        private string _validationMessage="";


        //*****GETTERS & SETTERS*****
        public ICommand UpdateCommand
        {
            get
            {
                return _updateCommand;
            }

            set
            {
                _updateCommand = value;
            }
        }
        public ICommand DeleteCommand
        {
            get
            {
                return _deleteCommand;
            }

            set
            {
                _deleteCommand = value;
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
        public string WindowTitle
        {
            get
            {
                return _windowTitle;
            }

            set
            {
                _windowTitle = value;
                NotifyPropertyChanged();
            }
        }
        public string ValidationMessage
        {
            get
            {
                return _validationMessage;
            }

            set
            {
                _validationMessage = value;
                NotifyPropertyChanged();
            }
        }

        //*****CONSTRUCTOR*****
        public CategorieDetailWindowViewModel()
        {
            //koppelen commands
            UpdateCommand = new BaseCommand(UpdateCategorie);
            DeleteCommand = new BaseCommand(DeleteCategorie);

            //instantiëren DialogService als singleton
            _dialogService = new DialogService();

            //luisteren naar updates
            Messenger.Default.Register<Categorie>(this, OnCategorieReceived);
        }

        //*****PROGRAMMA*****
        //doorgegeven categorie opslaan in 'SelectedCategorie'
        private void OnCategorieReceived(Categorie categorie)
        {
            SelectedCategorie = categorie;
            // tijdens een nieuwe categorie toevoegen, de delete button uitschakelen en juiste titel tonen
            if (SelectedCategorie.Id ==0)
            {
                WindowTitle = "Add Category";
                DeleteButtonEnabled = false;
            }
            else
            {
                WindowTitle = "Change Category";
                DeleteButtonEnabled = true;
            }
        }
        public void UpdateCategorie()
        {
            CategorieDataService cds = new CategorieDataService();

            ValidationMessage = "This field is required.";
            // controleren of het veld "naam" is ingevuld met validatie
            if (MyValidation.ControleForm(SelectedCategorie.Naam))
            {
                return;
            }
            else
            {
                ValidationMessage = "";
                // controleren of de categorie al bestaat in de database
                string _categorieBestaat = cds.CategorieNaamExist(SelectedCategorie.Naam);
                if (_categorieBestaat != null)
                {
                    MessageBox.Show("This Category already exists.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    // controleren of update of insert moet zijn
                    if (SelectedCategorie.Id == 0)
                    {
                        cds.InsertCategorie(SelectedCategorie);
                        Messenger.Default.Send<UpdateFinishedMessage>(new UpdateFinishedMessage(UpdateFinishedMessage.MessageType.Inserted));
                    }
                    else
                    {
                        cds.UpdateCategorie(SelectedCategorie);
                        Messenger.Default.Send<UpdateFinishedMessage>(new UpdateFinishedMessage(UpdateFinishedMessage.MessageType.Updated));
                    }
                }
            }
        }
        public void DeleteCategorie()
        {
                MessageBoxResult result = MessageBox.Show("When you delete a Category, all Algorithms from this Category will be removed too." + "\n" + "By removing a Algorithm, all Results from this Algorithm will be deleted too." + "\n" + " Are you sure you want to delete this Category ?",
                "Delete Category?", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        CategorieDataService cds = new CategorieDataService();
                        cds.DeleteCategorie(SelectedCategorie);
                        Messenger.Default.Send<UpdateFinishedMessage>(new UpdateFinishedMessage(UpdateFinishedMessage.MessageType.Deleted));
                        break;
                }
        }

    }
}

