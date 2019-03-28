using AlgorithmTrainer.ViewModel;

namespace AlgorithmTrainer
{
    class ViewModelLocator
    {
        //private
        private static MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
        private static AlgorithmWindowViewModel algorithmWindowViewModel = new AlgorithmWindowViewModel();
        private static AlgorithmDetailWindowViewModel algorithmDetailWindowViewModel = new AlgorithmDetailWindowViewModel();
        private static CategorieWindowViewModel categorieWindowViewModel = new CategorieWindowViewModel();
        private static CategorieDetailWindowViewModel categorieDetailWindowViewModel = new CategorieDetailWindowViewModel();
        private static ResultaatWindowViewModel resultaatWindowViewModel = new ResultaatWindowViewModel();
        private static AboutWindowViewModel aboutWindowViewModel = new AboutWindowViewModel();

        //public
        public static MainWindowViewModel MainWindowViewModel
        {
            get
            {
                return mainWindowViewModel;
            }
        }
        public static AlgorithmWindowViewModel AlgorithmWindowViewModel
        {
            get
            {
                return algorithmWindowViewModel;
            }
        }
        public static AlgorithmDetailWindowViewModel AlgorithmDetailWindowViewModel
        {
            get
            {
                return algorithmDetailWindowViewModel;
            }
        }
        public static CategorieWindowViewModel CategorieWindowViewModel
        {
            get
            {
                return categorieWindowViewModel;
            }
        }
        public static CategorieDetailWindowViewModel CategorieDetailWindowViewModel
        {
            get
            {
                return categorieDetailWindowViewModel;
            }
        }
        public static ResultaatWindowViewModel ResultaatWindowViewModel
        {
            get
            {
                return resultaatWindowViewModel;
            }
        }
        public static AboutWindowViewModel AboutWindowViewModel
        {
            get
            {
                return aboutWindowViewModel;
            }
        }
    }
}
