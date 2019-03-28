using AlgorithmTrainer.View;
using System.Windows;

namespace AlgorithmTrainer.Extensions
{
    class DialogService
    {
        Window algorithmView = null;
        Window algorithmDetailView = null;
        Window categorieView = null;
        Window categorieDetailView = null;
        Window resultaatView = null;
        Window aboutView = null;

        public DialogService() { }

        // algorithm Window
        public void ShowAlgorithmDialog()
        {
            algorithmView = new AlgorithmWindow();
            algorithmView.ShowDialog();
        }
        public void CloseAlgorithmDialog()
        {
            if (algorithmView != null)
                algorithmView.Close();
        }

        // algorithmDetail Window
        public void ShowAlgorithmDetailDialog()
        {
            algorithmDetailView = new AlgorithmDetailWindow();
            algorithmDetailView.ShowDialog();
        }
        public void CloseAlgorithmDetailDialog()
        {
            if (algorithmDetailView != null)
                algorithmDetailView.Close();
        }

        // categorie Window
        public void ShowCategorieDialog()
        {
            categorieView = new CategorieWindow();
            categorieView.ShowDialog();
        }
        public void CloseCategorieDialog()
        {
            if (categorieView != null)
                categorieView.Close();
        }

        // categorieDetail Window
        public void ShowCategorieDetailDialog()
        {
            categorieDetailView = new CategorieDetailWindow();
            categorieDetailView.ShowDialog();
        }
        public void CloseCategorieDetailDialog()
        {
            if (categorieDetailView != null)
                categorieDetailView.Close();
        }

        // resultaten Window
        public void ShowResultaatDialog()
        {
            resultaatView = new ResultaatWindow();
            resultaatView.ShowDialog();
        }
        public void CloseResultaatDialog()
        {
            if (resultaatView != null)
                resultaatView.Close();
        }

        // about Window
        public void ShowAboutDialog()
        {
            aboutView = new AboutWindow();
            aboutView.ShowDialog();
        }
        public void CloseAboutDialog()
        {
            if (aboutView != null)
                aboutView.Close();
        }

    }
}
