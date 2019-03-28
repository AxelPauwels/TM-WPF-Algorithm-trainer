using System.Collections.ObjectModel;
using System.IO;

namespace AlgorithmTrainer.Model
{
    class BackgroundDataService
    {
        public ObservableCollection<Background> GetBackgrounds()
        {
            var backgrounds = new ObservableCollection<Background>();
            DirectoryInfo map = new DirectoryInfo("images/backgrounds");
            FileInfo[] bestanden = map.GetFiles();

            foreach (FileInfo bestand in bestanden)
            {
                string bestandsNaam = (string)Path.GetFileNameWithoutExtension(bestand.Name);
                backgrounds.Add(new Background { Naam = bestandsNaam });
            }

            return backgrounds;
        }

    }
}
