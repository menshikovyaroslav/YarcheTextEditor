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
using System.Windows.Input;
using YarcheTextEditor.Classes;
using YarcheTextEditor.Commands;
using YarcheTextEditor.Models;

namespace YarcheTextEditor.Controller
{
    public class ProgramController : INotifyPropertyChanged
    {
        #region Commands

        #region Command Init

        private ICommand _setRussianCommand;
        private ICommand _setEnglishCommand;

        public ICommand SetRussianCommand
        {
            get { return _setRussianCommand; }
            set { _setRussianCommand = value; }
        }

        public ICommand SetEnglishCommand
        {
            get { return _setEnglishCommand; }
            set { _setEnglishCommand = value; }
        }

        public ICommand CloseProgramCommand { get; set; }

        public ICommand RemoveStringWithWordCommand { get; set; }
        public ICommand RemoveStringWithOutWordCommand { get; set; }

        #endregion

        #region Commands - Methods

        public void SetRussianCommand_Execute()
        {
            Language = new RussianLanguage();

            OnPropertyChanged("Language");
            RegistryMethods.SetLanguage(Language);
        }

        public bool SetRussianCommand_CanExecute()
        {
            if (Language.GetType() == typeof(RussianLanguage)) return false;
            return true;
        }

        public void SetEnglishCommand_Execute()
        {
            Language = new EnglishLanguage();

            OnPropertyChanged("Language");
            RegistryMethods.SetLanguage(Language);
        }

        public bool SetEnglishCommand_CanExecute()
        {
            if (Language.GetType() == typeof(EnglishLanguage)) return false;
            return true;
        }

        public void CloseProgramCommand_Execute()
        {
            Application.Current.Shutdown();
        }

        public bool CloseProgramCommand_CanExecute()
        {
            return true;
        }

        public void RemoveStringWithWordCommand_Execute(string word)
        {
            var newCollection = new ObservableCollection<StringElement>();
            var index = 0;
            foreach (var stringElement in TextCollection)
            {
                var line = stringElement.Text;
                var isContains = line.Contains(word);
                if (!isContains)
                {
                    index++;
                    newCollection.Add(new StringElement() { Index = index, Text = line });
                }
            }

            TextCollection.Clear();
            TextCollection = newCollection;
            OnPropertyChanged("TextCollection");
        }

        public bool RemoveStringWithWordCommand_CanExecute(string parameter)
        {
            return IsFileLoaded;
        }

        public void RemoveStringWithOutWordCommand_Execute(string word)
        {
            var newCollection = new ObservableCollection<StringElement>();
            var index = 0;
            foreach (var stringElement in TextCollection)
            {
                var line = stringElement.Text;
                var isContains = line.Contains(word);
                if (isContains)
                {
                    index++;
                    newCollection.Add(new StringElement() { Index = index, Text = line });
                }
            }

            TextCollection.Clear();
            TextCollection = newCollection;
            OnPropertyChanged("TextCollection");
        }

        public bool RemoveStringWithOutWordCommand_CanExecute(string parameter)
        {
            return IsFileLoaded;
        }

        #endregion

        #endregion

        public MainWindow MainWindow { get; set; }
        public ILanguage Language { get; set; }
        public ObservableCollection<StringElement> TextCollection { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsFileLoaded { get; set; }

        public ProgramController()
        {
            Language = GetLanguage();
            TextCollection = new ObservableCollection<StringElement>();

            SetRussianCommand = new DelegateCommand(SetRussianCommand_Execute, SetRussianCommand_CanExecute);
            SetEnglishCommand = new DelegateCommand(SetEnglishCommand_Execute, SetEnglishCommand_CanExecute);
            CloseProgramCommand = new DelegateCommand(CloseProgramCommand_Execute, CloseProgramCommand_CanExecute);
            RemoveStringWithWordCommand = new DelegateWithParameterCommand<string>(RemoveStringWithWordCommand_Execute, RemoveStringWithWordCommand_CanExecute);
            RemoveStringWithOutWordCommand = new DelegateWithParameterCommand<string>(RemoveStringWithOutWordCommand_Execute, RemoveStringWithOutWordCommand_CanExecute);
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

            IsFileLoaded = true;
            OnPropertyChanged("TextCollection");
            OnPropertyChanged("IsFileLoaded");
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
