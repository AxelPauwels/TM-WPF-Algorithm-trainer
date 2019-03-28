using AlgorithmTrainer.Extensions;
using AlgorithmTrainer.Messages;
using AlgorithmTrainer.Model;
using AlgorithmTrainer.Validation;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace AlgorithmTrainer.ViewModel
{
    class AlgorithmDetailWindowViewModel : BaseViewModel
    {
        //*****DECLAREREN*****
        private DialogService _dialogService;
        private ICommand _updateCommand;
        private ICommand _deleteCommand;
        private Algorithm _selectedAlgorithm;
        private Categorie _selectedCategorie;
        private ObservableCollection<Categorie> _categories;
        private bool _isSelectedTrue;
        private bool _isSelectedFalse;
        private ICommand _loadImageCommand;
        private string _showLoadImage;
        private bool _deleteButtonEnabled = true;
        private string _windowTitle;
        //validatie
        private string _validationMessage = "";
        private int _hoogsteGuideNummer;
        private int _vorigeGuideNumber;
        private string _vorigeSolution;
        //images opslaan bij save
        private string _importNaam = "";
        private string _importPath;
        private string _destinationPath;
        private string _afbeeldingWeergavePath;

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
        public bool IsSelectedTrue
        {
            get
            {
                return _isSelectedTrue;
            }

            set
            {
                _isSelectedTrue = value;
                NotifyPropertyChanged();
            }
        }
        public bool IsSelectedFalse
        {
            get
            {
                return _isSelectedFalse;
            }

            set
            {
                _isSelectedFalse = value;
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
                NotifyPropertyChanged();
            }
        }
        public ICommand LoadImageCommand
        {
            get
            {
                return _loadImageCommand;
            }

            set
            {
                _loadImageCommand = value;
            }
        }
        public string ShowLoadImage
        {
            get
            {
                return _showLoadImage;
            }

            set
            {
                _showLoadImage = value;
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
        //validatie
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
        public int HoogsteGuideNummer
        {
            get
            {
                return _hoogsteGuideNummer;
            }

            set
            {
                _hoogsteGuideNummer = value;
                NotifyPropertyChanged();
            }
        }
        public int VorigeGuideNumber
        {
            get
            {
                return _vorigeGuideNumber;
            }

            set
            {
                _vorigeGuideNumber = value;
                NotifyPropertyChanged();
            }
        }
        public string VorigeSolution
        {
            get
            {
                return _vorigeSolution;
            }

            set
            {
                _vorigeSolution = value;
                NotifyPropertyChanged();
            }
        }
        //images opslaan bij save
        public string ImportNaam
        {
            get
            {
                return _importNaam;
            }

            set
            {
                _importNaam = value;
                NotifyPropertyChanged();
            }
        }
        public string ImportPath
        {
            get
            {
                return _importPath;
            }

            set
            {
                _importPath = value;
                NotifyPropertyChanged();
            }
        }
        public string DestinationPath
        {
            get
            {
                return _destinationPath;
            }

            set
            {
                _destinationPath = value;
                NotifyPropertyChanged();
            }
        }
        public string AfbeeldingWeergavePath
        {
            get
            {
                return _afbeeldingWeergavePath;
            }

            set
            {
                _afbeeldingWeergavePath = value;
                NotifyPropertyChanged();
            }
        }

        //*****CONSTRUCTOR*****
        public AlgorithmDetailWindowViewModel()
        {
            //laden data
            CategorieDataService cds = new CategorieDataService();
            Categories = cds.GetCategories();

            //koppelen commands
            UpdateCommand = new BaseCommand(UpdateAlgorithm);
            DeleteCommand = new BaseCommand(DeleteAlgorithm);
            LoadImageCommand = new BaseCommand(LoadImage);

            //instantiëren DialogService als singleton
            _dialogService = new DialogService();

            //luisteren naar updates
            Messenger.Default.Register<Algorithm>(this, OnAlgorithmReceived);
        }

        //*****PROGRAMMA*****
        //doorgegeven algorithm opslaan in 'SelectedAlgorithm'
        private void OnAlgorithmReceived(Algorithm algorithm)
        {
            // gegevens apart opslaan om bij update (niet insert) gegevens controle te doen
            VorigeGuideNumber = algorithm.Nummer;

            VorigeSolution = algorithm.AlgorithmSolution;


            // browse-button tonen indien het een "insert" is. Indien het een "save" is, browse-button verbergen + delete-button verbergen indien het een insert is
            if (algorithm.Id == 0)
            {
                ShowLoadImage = "Visible";
                WindowTitle = "Add Algorithm";
                DeleteButtonEnabled = false;
            }
            else
            {
                ShowLoadImage = "Collapsed";
                WindowTitle = "Change Algorithm";
                DeleteButtonEnabled = true;
            }

            SelectedAlgorithm = algorithm;
            if (SelectedAlgorithm.Actief)
            {
                IsSelectedTrue = true;
                IsSelectedFalse = false;
            }
            else
            {
                IsSelectedTrue = false;
                IsSelectedFalse = true;
            }
            //selectedCategorie instellen
            foreach (var Categorie in Categories)
            {
                if (Categorie.Naam == algorithm.CategorieNaam)
                {
                    SelectedCategorie = Categorie;
                }
            }
        }
        public void UpdateAlgorithm()
        {
            AlgorithmDataService ads = new AlgorithmDataService();
            //haal de hoogste Nummer op in de database
            HoogsteGuideNummer = ads.GetHoogsteGuideNummer();

            //INSERT een nieuwe algorithm
            if (SelectedAlgorithm.Id == 0)
            {
                //controleer of er wel een Nummer is ingevuld en of het groter is dan 0
                if (SelectedAlgorithm.Nummer <= 0)
                {
                    ValidationMessage = "Please fill in a Guide Number greater than 0 .";
                }
                else
                {
                    ValidationMessage = "";
                    // controleer of deze AlgorithmSolution of Nummer al bestaat in de database
                    string _algorithmSolutionBestaat = ads.AlgorithmExist(SelectedAlgorithm.AlgorithmSolution);
                    int _nummerBestaat = ads.NummerExist(SelectedAlgorithm.Nummer);

                    if (_algorithmSolutionBestaat != null || _nummerBestaat != 0)
                    {
                        // message opbouwen voor validatiemessage
                        // get bestaande nummers
                        string _bestaandeNummers = ads.GetAllGuideNummers();
                        string _message = "";
                        if (_algorithmSolutionBestaat != null && _nummerBestaat != 0)
                        {
                            _message = "The Solution and Guide Number already exists.";
                        }
                        else
                        {
                            if (_algorithmSolutionBestaat != null)
                            {
                                _message = "The Solution already exists.";
                            }
                            else
                            {
                                _message = "The Guide Number already exists.";
                                MessageBox.Show("This Guide Number already exists. " + "\n" + "Please use a different Number." + "\n \n" + "These numbers already exists:" + "\n" + _bestaandeNummers, "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }
                        //validatiemessage tonen
                        ValidationMessage = _message;
                    }
                    else
                    {
                        ValidationMessage = "";
                        // kijken of dat er een afbeelding geselecteerd is
                        if (ImportNaam == "")
                        {
                            ValidationMessage = "Please select an image";
                        }
                        else
                        {
                            try
                            {
                                File.Copy(ImportPath, this.DestinationPath, true);
                            }
                            catch
                            {
                                ImportNaam = "";
                                MessageBox.Show("Unable to open file.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                            }
                            SelectedAlgorithm.Afbeelding = ImportNaam;
                            ads.InsertAlgorithm(SelectedAlgorithm);
                            ImportNaam = "";
                            Messenger.Default.Send<UpdateFinishedMessage>(new UpdateFinishedMessage(UpdateFinishedMessage.MessageType.Inserted));
                        }
                    }
                }
            }
            //UPDATE bestaande Algorithm
            else
            {
                //controleer of er wel een Nummer is ingevuld en of het groter is dan 0
                if (SelectedAlgorithm.Nummer <= 0)
                {
                    ValidationMessage = "Please fill in a Guide Number greater than 0 .";
                }
                else
                {
                    ValidationMessage = "";
                    // controleer of deze AlgorithmSolution of Nummer al bestaat in de database EN controleren of deze ook is aangepast
                    string _algorithmSolutionBestaat = ads.AlgorithmExist(SelectedAlgorithm.AlgorithmSolution);
                    int _nummerBestaat = ads.NummerExist(SelectedAlgorithm.Nummer);
                    if ((_algorithmSolutionBestaat != null && SelectedAlgorithm.AlgorithmSolution != VorigeSolution) || (_nummerBestaat != 0 && SelectedAlgorithm.Nummer != VorigeGuideNumber))
                    {
                        // haal bestaande nummers op
                        string _bestaandeNummers = ads.GetAllGuideNummers();
                        // message opbouwen voor validatiemessage
                        string _message = "";
                        if ((_algorithmSolutionBestaat != null && _nummerBestaat != 0) && (SelectedAlgorithm.Nummer != VorigeGuideNumber && SelectedAlgorithm.AlgorithmSolution != VorigeSolution))
                        {
                            _message = "The Solution and Guide Number already exists.";
                        }
                        else
                        {
                            if (_algorithmSolutionBestaat != null && (SelectedAlgorithm.AlgorithmSolution != VorigeSolution))
                            {
                                _message = "The Solution already exists.";
                            }
                            if (_nummerBestaat != 0 && (SelectedAlgorithm.Nummer != VorigeGuideNumber))
                            {
                                _message = "The Guide Number already exists.";
                                MessageBox.Show("This Guide Number already exists. " + "\n" + "Please use a different Number." + "\n \n" + "These numbers already exists:" + "\n" + _bestaandeNummers, "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }
                        //validatiemessage tonen
                        ValidationMessage = _message;
                    }
                    else
                    {
                        ValidationMessage = "";
                        // "Actief" als bool opslaan
                        if (IsSelectedTrue)
                        {
                            SelectedAlgorithm.Actief = true;
                        }
                        else
                        {
                            SelectedAlgorithm.Actief = false;
                        }

                        // de categorieId opslaan aan de hand van de categorieNaam
                        foreach (var Categorie in Categories)
                        {
                            if (SelectedCategorie.Naam == Categorie.Naam)
                            {
                                SelectedAlgorithm.CategorieId = Categorie.Id;
                                SelectedAlgorithm.CategorieNaam = Categorie.Naam;
                            }
                        }
                        // de algorithm updaten in de database
                        ads.UpdateAlgorithm(SelectedAlgorithm);
                        Messenger.Default.Send<UpdateFinishedMessage>(new UpdateFinishedMessage(UpdateFinishedMessage.MessageType.Updated));
                    }
                }
            }
        }
        public void DeleteAlgorithm()
        {
            // controleren of de delete knop wordt gebruikt terwijl je een nieuwe categorie aan het creeëren bent
            if (SelectedAlgorithm.Id == 0)
            {
                MessageBoxResult result = MessageBox.Show("It's not possible to delete a Algorithm when you are creating a new Algorithm.",
                "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("When you delete a Algorithm, all Results from this Algorithm will be removed too." + "\n" + " Are you sure you want to delete this Algorithm ?",
                "Delete Algorithm?", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        AlgorithmDataService ads = new AlgorithmDataService();
                        ads.DeleteAlgorithm(SelectedAlgorithm);
                        Messenger.Default.Send<UpdateFinishedMessage>(new UpdateFinishedMessage(UpdateFinishedMessage.MessageType.Deleted));
                        break;
                }
            }
        }
        public void LoadImage()
        {
            //upload image
            OpenFileDialog _importAfbeelding = new OpenFileDialog();
            _importAfbeelding.Title = "Select a image";

            if (_importAfbeelding.ShowDialog() == true)
            {
                ImportPath = _importAfbeelding.FileName;
                string[] _padGesplitst = _importPath.Split('\\');
                ImportNaam = _padGesplitst[(_padGesplitst.Length - 1)];

                // kijk of de afbeeldingsNaam al bestaat in de database
                AlgorithmDataService ads = new AlgorithmDataService();
                string afbeeldingBestaat = ads.ImageExists(ImportNaam);
                if (afbeeldingBestaat != null)
                {
                    // voorstel voor een imageNaam ophalen
                    string _allImages = ads.GetAllImages();
                    string _messageBoxMessage = "This image already exists. " + "\n" + "Please use a different name for your image." + "\n \n" + "These images already exists: \n " + _allImages;
                    MessageBox.Show(_messageBoxMessage, "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    ValidationMessage = "";
                    string _destinationFullPath = System.AppDomain.CurrentDomain.BaseDirectory + "images\\OLL\\" + ImportNaam;
                    DestinationPath = _destinationFullPath.Replace("\\", "/");
                }

            }
        }

    }
}
