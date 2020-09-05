using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using YarcheTextEditor.Classes;
using YarcheTextEditor.Models;

namespace YarcheTextEditor.Controller
{
    public class ProgramController : INotifyPropertyChanged
    {
        public MainWindow MainWindow { get; set; }
        public ILanguage Language { get; set; }
        public ObservableCollection<StringElement> TextCollection { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ProgramController()
        {
            Language = GetLanguage();
            TextCollection = new ObservableCollection<StringElement>();
        }
        public void SetLanguage(string languageCode)
        {
            Language = LanguageMethods.GetLanguage(languageCode);

            OnPropertyChanged("Language");
            RegistryMethods.SetLanguage(Language.LanguageCode);
        }

        /// <summary>
        /// Get saved in options language or default language
        /// </summary>
        /// <returns></returns>
        public ILanguage GetLanguage()
        {
            return RegistryMethods.GetLanguage();
        }

        public void LoadFile(string path)
        {
            TextCollection.Clear();

            MainWindow.LoadFileControl.Visibility = System.Windows.Visibility.Collapsed;
            MainWindow.WorkFileControl.Visibility = System.Windows.Visibility.Visible;

            var lines = File.ReadAllLines(path);
            var index = 0;
            foreach (var line in lines)
            {
                index++;
                TextCollection.Add(new StringElement() { Index = index, Text = line});
            }
            OnPropertyChanged("TextCollection");
        }

        public void ChooseFile()
        {
            var fileDialog = new Microsoft.Win32.OpenFileDialog();
            var file = fileDialog.ShowDialog();
            if (file == false) return;

            LoadFile(fileDialog.FileName);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
