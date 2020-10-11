using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using YarcheTextEditor.Classes;
using YarcheTextEditor.Commands;
using YarcheTextEditor.Models;

namespace YarcheTextEditor.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Commands

        #region Command Init

        public ICommand SetRussianCommand { get; set; }
        public ICommand SetEnglishCommand { get; set; }
        public ICommand CloseProgramCommand { get; set; }
        public ICommand RemoveStringWithWordCommand { get; set; }
        public ICommand RemoveStringWithOutWordCommand { get; set; }
        public ICommand StatisticsOnOccurrencesCommand { get; set; }
        public ICommand StatisticsOnOccurrencesWithWordCommand { get; set; }
        public ICommand FileOpenCommand { get; set; }
        public ICommand FileCloseCommand { get; set; }
        public ICommand FileSaveCommand { get; set; }
        public ICommand FileSaveAsCommand { get; set; }
        public ICommand EncodingMenuCommand { get; set; }
        public ICommand SetEncodingWin1251Command { get; set; }
        public ICommand SetEncodingUtf8Command { get; set; }
        public ICommand SetYourEncodingCommand { get; set; }
        public ICommand NavigationBackCommand { get; set; }
        public ICommand NavigationForwardCommand { get; set; }
        public ICommand DeleteEmptyLinesCommand { get; set; }
        public ICommand RemoveWordCommand { get; set; }
        public ICommand ReplaceWordCommand { get; set; }

        #endregion

        #region Commands - Methods

        public void SetRussianCommand_Execute()
        {
            //   _canBack = _canForward = false;

            Language = new RussianLanguage();
            AddMessageToUser($"Language changed to '{Language.LanguageCode}'");
        }

        public void SetEnglishCommand_Execute()
        {
            //    _canBack = _canForward = false;

            Language = new EnglishLanguage();
            AddMessageToUser($"Language changed to '{Language.LanguageCode}'");
        }

        public bool SetRussianCommand_CanExecute()
        {
            if (Language.GetType() == typeof(RussianLanguage)) return false;
            return true;
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

       

        public void EncodingMenuCommand_Execute()
        {
        }

        public bool EncodingMenuCommand_CanExecute()
        {
            return IsFileLoaded;
        }

      

        public void FileOpenCommand_Execute()
        {
            ChooseFile();
        }

        public bool FileOpenCommand_CanExecute()
        {
            return true;
        }

     

        public void SetEncodingWin1251Command_Execute()
        {
            _canBack = _canForward = false;

            _fileEncoding = Encoding.GetEncoding("Windows-1251");
            AddMessageToUser($"Set '{_fileEncoding.BodyName}' encoding");
            LoadFile(_pathToLoadedFile);
        }

        public bool SetEncodingWin1251Command_CanExecute()
        {
            if (IsFileLoaded && _fileEncoding != Encoding.GetEncoding("Windows-1251")) return true;
            return false;
        }

        public void SetEncodingUtf8Command_Execute()
        {
            _canBack = _canForward = false;

            _fileEncoding = Encoding.UTF8;
            AddMessageToUser($"Set '{_fileEncoding.BodyName}' encoding");
            LoadFile(_pathToLoadedFile);
        }

        public bool SetEncodingUtf8Command_CanExecute()
        {
            if (IsFileLoaded && _fileEncoding != Encoding.UTF8) return true;
            return false;
        }

        public void SetYourEncodingCommand_Execute(string encoding)
        {
            try
            {
                _canBack = _canForward = false;

                _fileEncoding = Encoding.GetEncoding(encoding);
                AddMessageToUser($"Set '{_fileEncoding.BodyName}' encoding");
                LoadFile(_pathToLoadedFile);
            }
            catch (Exception ex)
            {
                AddMessageToUser($"Failed to set '{encoding}' encoding: {ex.Message}");
            }
        }

        public bool SetYourEncodingCommand_CanExecute(string parameter)
        {
            return IsFileLoaded;
        }

        public void RemoveStringWithWordCommand_Execute(string word)
        {
            var newCollection = new ObservableCollection<StringElement>();
            var index = 0;
            foreach (var stringElement in Collections.TextCollection)
            {
                var line = stringElement.Text;
                var isContains = line.Contains(word);
                if (!isContains)
                {
                    index++;
                    newCollection.Add(new StringElement() { Index = index, Text = line });
                }
            }

            AddMessageToUser($"Used {Language.RemoveStringWithWordTool}, word='{word}'");
            ChangeTextCollection(newCollection);
        }

        public bool RemoveStringWithWordCommand_CanExecute(string parameter)
        {
            return IsFileLoaded;
        }

        public void RemoveWordCommand_Execute(string word)
        {
            var newCollection = new ObservableCollection<StringElement>();
            var index = 0;
            foreach (var stringElement in Collections.TextCollection)
            {
                index++;
                var line = stringElement.Text;
                var isContains = line.Contains(word);
                if (isContains)
                {
                    line = line.Replace(word, "");
                }
                newCollection.Add(new StringElement() { Index = index, Text = line });
            }

            AddMessageToUser($"Used {Language.RemoveWordTool}, word='{word}'");
            ChangeTextCollection(newCollection);
        }

        public bool RemoveWordCommand_CanExecute(string parameter)
        {
            return IsFileLoaded;
        }

        public void ReplaceWordCommand_Execute(object[] parameters)
        {
            try
            {
                var word1 = parameters[0] as string;
                var word2 = parameters[1] as string;

                var newCollection = new ObservableCollection<StringElement>();
                var index = 0;
                foreach (var stringElement in Collections.TextCollection)
                {
                    index++;
                    var line = stringElement.Text;
                    var isContains = line.Contains(word1);
                    if (isContains)
                    {
                        line = line.Replace(word1, word2);
                    }
                    newCollection.Add(new StringElement() { Index = index, Text = line });
                }

                AddMessageToUser($"Used {Language.ReplaceWordTool}, word='{word1} to word='{word2}'");
                ChangeTextCollection(newCollection);
            }
            catch (Exception)
            {
            }

        }

        public bool ReplaceWordCommand_CanExecute(object[] parameters)
        {
            return true;
        }

        public void RemoveStringWithOutWordCommand_Execute(string word)
        {
            var newCollection = new ObservableCollection<StringElement>();
            var index = 0;
            foreach (var stringElement in Collections.TextCollection)
            {
                var line = stringElement.Text;
                var isContains = line.Contains(word);
                if (isContains)
                {
                    index++;
                    newCollection.Add(new StringElement() { Index = index, Text = line });
                }
            }

            AddMessageToUser($"Used {Language.RemoveStringWithOutWordTool}, word='{word}'");
            ChangeTextCollection(newCollection);
        }

        public bool RemoveStringWithOutWordCommand_CanExecute(string parameter)
        {
            return IsFileLoaded;
        }

        public void StatisticsOnOccurrencesCommand_Execute()
        {
            var newCollection = new ObservableCollection<StringElement>();

            // line -> number of occurrences 
            var dict = new SortedList<string, int>();
            foreach (var stringElement in Collections.TextCollection)
            {
                if (dict.ContainsKey(stringElement.Text)) dict[stringElement.Text]++;
                else dict[stringElement.Text] = 1;
            }

            var index = 0;
            foreach (KeyValuePair<string, int> pair in dict.OrderByDescending(pair => pair.Value))
            {
                index++;
                newCollection.Add(new StringElement() { Index = index, Text = $"{pair.Key}={pair.Value}" });
            }

            AddMessageToUser($"Used {Language.StatisticsOnOccurrences}");
            ChangeTextCollection(newCollection);
        }

        public bool StatisticsOnOccurrencesCommand_CanExecute()
        {
            return IsFileLoaded;
        }

        public void StatisticsOnOccurrencesWithWordCommand_Execute(string word)
        {
            var newCollection = new ObservableCollection<StringElement>();

            var count = 0;
            foreach (var stringElement in Collections.TextCollection)
            {
                if (stringElement.Text.Contains(word)) count++;
            }

            newCollection.Add(new StringElement() { Index = 1, Text = $"{word}={count}" });

            AddMessageToUser($"Used {Language.StatisticsOnOccurrencesWithWord}, word='{word}'");
            ChangeTextCollection(newCollection);
        }

        public bool StatisticsOnOccurrencesWithWordCommand_CanExecute(string word)
        {
            return IsFileLoaded;
        }

        public void DeleteEmptyLinesCommand_Execute()
        {
            var newCollection = new ObservableCollection<StringElement>();

            var index = 0;
            foreach (var item in Collections.TextCollection)
            {
                if (item.Text == "") continue;

                index++;
                newCollection.Add(new StringElement() { Index = index, Text = item.Text });
            }

            AddMessageToUser($"Used {Language.DeleteEmptyLines}");
            ChangeTextCollection(newCollection);
        }

        public bool DeleteEmptyLinesCommand_CanExecute()
        {
            return IsFileLoaded;
        }

        public void FileSaveCommand_Execute()
        {
            var lines = new List<string>();
            foreach (var item in Collections.TextCollection)
            {
                lines.Add(item.Text);
            }
            File.WriteAllLines(_pathToLoadedFile, lines, _fileEncoding);

            AddMessageToUser($"Saved '{_pathToLoadedFile}' file");
        }

        public bool FileSaveCommand_CanExecute()
        {
            return IsFileLoaded;
        }

        public void NavigationBackCommand_Execute()
        {
            AddMessageToUser($"Navigation back");
            _canBack = false;
            _canForward = true;
            ForwardCollection.Clear();
            foreach (var item in Collections.TextCollection)
            {
                ForwardCollection.Add(item);
            }
            Collections.TextCollection.Clear();
            foreach (var item in BackCollection)
            {
                Collections.TextCollection.Add(item);
            }
            BackCollection.Clear();
            OnPropertyChanged("TextCollection");
        }

        public bool NavigationBackCommand_CanExecute()
        {
            return IsFileLoaded && _canBack;
        }

        public void NavigationForwardCommand_Execute()
        {
            AddMessageToUser($"Navigation forward");
            _canBack = true;
            _canForward = false;
            BackCollection.Clear();
            foreach (var item in Collections.TextCollection)
            {
                BackCollection.Add(item);
            }
            Collections.TextCollection.Clear();
            foreach (var item in ForwardCollection)
            {
                Collections.TextCollection.Add(item);
            }
            ForwardCollection.Clear();
            OnPropertyChanged("TextCollection");
        }

        public bool NavigationForwardCommand_CanExecute()
        {
            return IsFileLoaded && _canForward;
        }

        public void FileCloseCommand_Execute()
        {
            Collections.TextCollection.Clear();

            //   MainWindow.LoadFileControl.Visibility = System.Windows.Visibility.Visible;
            //   MainWindow.WorkFileControl.Visibility = System.Windows.Visibility.Collapsed;

            IsFileLoaded = false;
            OnPropertyChanged("TextCollection");
            OnPropertyChanged("IsFileLoaded");

            AddMessageToUser($"Closed '{_pathToLoadedFile}' file");
        }

        public bool FileCloseCommand_CanExecute()
        {
            return IsFileLoaded;
        }

        public void FileSaveAsCommand_Execute()
        {
            var chosenFile = string.Empty;
            try
            {
                var extension = Path.GetExtension(_pathToLoadedFile);

                var saveDialog = new SaveFileDialog();
                saveDialog.AddExtension = true;
                saveDialog.Filter = $"{Language.Current} ({extension})|*{extension}|{Language.AllFiles}";
                if (saveDialog.ShowDialog() == true)
                {
                    chosenFile = saveDialog.FileName;

                    var lines = new List<string>();
                    foreach (var item in Collections.TextCollection)
                    {
                        lines.Add(item.Text);
                    }

                    File.WriteAllLines(chosenFile, lines, _fileEncoding);

                    AddMessageToUser($"Saved as '{chosenFile}' file");
                }
            }
            catch (Exception ex)
            {
                AddMessageToUser($"Not saved as '{chosenFile}' file: {ex.Message}");
            }

        }

        public bool FileSaveAsCommand_CanExecute()
        {
            return IsFileLoaded;
        }




        #endregion

        #endregion



        public ObservableCollection<StringElement> BackCollection { get; set; }
        public ObservableCollection<StringElement> ForwardCollection { get; set; }
        private ObservableCollection<LogEvent> _eventsCollection;
        public ObservableCollection<LogEvent> EventsCollection { get { return new ObservableCollection<LogEvent>(_eventsCollection.OrderByDescending(t => t.Time)); } set { _eventsCollection = value; } }
        public bool IsFileLoaded { get; set; }
        private string _pathToLoadedFile { get; set; }
        private Encoding _fileEncoding { get; set; }
        private bool _canBack;
        private bool _canForward;

        private BaseViewModel _selectedViewModel = new LoadFileViewModel();
        public BaseViewModel SelectedViewModel { get { return _selectedViewModel; } set { _selectedViewModel = value; } }

        public ILanguage Language
        {
            get
            {
                return LanguageSettings.Language;
            }
            set
            {
                LanguageSettings.Language = value;
                OnPropertyChanged("Language");
            }
        }

        public MainViewModel()
        {
            Language = RegistryMethods.GetLanguage();
            Collections.TextCollectionChangedHandler += TextCollectionChangedHandler;

            BackCollection = new ObservableCollection<StringElement>();
            ForwardCollection = new ObservableCollection<StringElement>();
            EventsCollection = new ObservableCollection<LogEvent>();

            SetRussianCommand = new DelegateCommand(SetRussianCommand_Execute, SetRussianCommand_CanExecute);
            SetEnglishCommand = new DelegateCommand(SetEnglishCommand_Execute, SetEnglishCommand_CanExecute);
            CloseProgramCommand = new DelegateCommand(CloseProgramCommand_Execute, CloseProgramCommand_CanExecute);
            RemoveStringWithWordCommand = new DelegateWithParameterCommand<string>(RemoveStringWithWordCommand_Execute, RemoveStringWithWordCommand_CanExecute);
            RemoveStringWithOutWordCommand = new DelegateWithParameterCommand<string>(RemoveStringWithOutWordCommand_Execute, RemoveStringWithOutWordCommand_CanExecute);
            StatisticsOnOccurrencesCommand = new DelegateCommand(StatisticsOnOccurrencesCommand_Execute, StatisticsOnOccurrencesCommand_CanExecute);
            FileOpenCommand = new DelegateCommand(FileOpenCommand_Execute, FileOpenCommand_CanExecute);
            FileCloseCommand = new DelegateCommand(FileCloseCommand_Execute, FileCloseCommand_CanExecute);
            FileSaveCommand = new DelegateCommand(FileSaveCommand_Execute, FileSaveCommand_CanExecute);
            FileSaveAsCommand = new DelegateCommand(FileSaveAsCommand_Execute, FileSaveAsCommand_CanExecute);
            EncodingMenuCommand = new DelegateCommand(EncodingMenuCommand_Execute, EncodingMenuCommand_CanExecute);
            SetEncodingWin1251Command = new DelegateCommand(SetEncodingWin1251Command_Execute, SetEncodingWin1251Command_CanExecute);
            SetEncodingUtf8Command = new DelegateCommand(SetEncodingUtf8Command_Execute, SetEncodingUtf8Command_CanExecute);
            SetYourEncodingCommand = new DelegateWithParameterCommand<string>(SetYourEncodingCommand_Execute, SetYourEncodingCommand_CanExecute);
            StatisticsOnOccurrencesWithWordCommand = new DelegateWithParameterCommand<string>(StatisticsOnOccurrencesWithWordCommand_Execute, StatisticsOnOccurrencesWithWordCommand_CanExecute);
            NavigationBackCommand = new DelegateCommand(NavigationBackCommand_Execute, NavigationBackCommand_CanExecute);
            NavigationForwardCommand = new DelegateCommand(NavigationForwardCommand_Execute, NavigationForwardCommand_CanExecute);
            DeleteEmptyLinesCommand = new DelegateCommand(DeleteEmptyLinesCommand_Execute, DeleteEmptyLinesCommand_CanExecute);
            RemoveWordCommand = new DelegateWithParameterCommand<string>(RemoveWordCommand_Execute, RemoveWordCommand_CanExecute);
            ReplaceWordCommand = new DelegateWithParameterCommand<object[]>(ReplaceWordCommand_Execute, ReplaceWordCommand_CanExecute);

            _fileEncoding = Encoding.UTF8;
        }

        private void TextCollectionChangedHandler(object sender, EventArgs EventArgs)
        {
            OnPropertyChanged("TextCollection");
        }

        public void LoadFile(string path)
        {
            _canBack = _canForward = false;
            Collections.TextCollection.Clear();

            try
            {
                var lines = File.ReadAllLines(path, _fileEncoding);
                var index = 0;
                foreach (var line in lines)
                {
                    index++;
                    Collections.TextCollection.Add(new StringElement() { Index = index, Text = line });
                }

                _pathToLoadedFile = path;

                SelectedViewModel = new WorkFileViewModel();

                IsFileLoaded = true;
                OnPropertyChanged("TextCollection");
                OnPropertyChanged("IsFileLoaded");
                OnPropertyChanged("SelectedViewModel");

                Collections.TextCollectionChanged();

                AddMessageToUser($"Opened '{path}' file");
            }
            catch (Exception ex)
            {
                AddMessageToUser(ex.Message);
            }
        }

        private void AddMessageToUser(string message)
        {
            _eventsCollection.Add(new LogEvent(message));
            OnPropertyChanged("EventsCollection");
        }

        public void ChooseFile()
        {
            var fileDialog = new Microsoft.Win32.OpenFileDialog();
            var file = fileDialog.ShowDialog();
            if (file == false) return;

            LoadFile(fileDialog.FileName);
        }

        private void ChangeTextCollection(ObservableCollection<StringElement> newCollection)
        {
            _canBack = true;
            _canForward = false;
            BackCollection.Clear();
            foreach (var item in Collections.TextCollection)
            {
                BackCollection.Add(item);
            }
            Collections.TextCollection.Clear();
            Collections.TextCollection = newCollection;
            Collections.TextCollectionChanged();
        }
    }
}
