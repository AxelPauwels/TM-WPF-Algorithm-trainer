using System.Collections.ObjectModel;
using System.Windows.Input;
using AlgorithmTrainer.Infrastructure;

namespace AlgorithmTrainer.Model
{
    public class BackgroundMenu : MenuBase
    {
        private ICommand _command;
        private bool _isEnabled = true;
        private ObservableCollection<BackgroundMenu> _items;
        public string Header { get; set; }

        public string CommandParameter { get; set; }

        public ICommand Command
        {
            get
            {
                return (_command = _command ??
                                   new DelegateCommand<string>(OnMenuItemClick, (x) => IsEnabled));
            }
        }

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                _isEnabled = value;
                OnPropertyChanged("IsEnabled");
            }
        }

        public ObservableCollection<BackgroundMenu> Items
        {
            get
            {
                return (_items = _items ??
                                 new ObservableCollection<BackgroundMenu>());
            }
        }

        public bool HasChildren
        {
            get { return Items.Count > 0; }
        }

        public event FileMenuHandler FileMenuClick;

        public virtual void OnFileMenuClick(object sender, BackgroundMenuEventArgs args)
        {
            if (FileMenuClick != null)
            {
                FileMenuClick(sender, args);
            }
        }

        public virtual void OnMenuItemClick(string parameter)
        {
            OnFileMenuClick(this, new BackgroundMenuEventArgs
            {
                CommandName = parameter
            });
        }
    }
}
