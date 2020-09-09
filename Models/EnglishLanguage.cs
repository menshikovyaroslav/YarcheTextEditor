using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YarcheTextEditor.Models
{
    public class EnglishLanguage : ILanguage
    {
        public string AllFiles { get { return "All Files (*.*)|*.*"; } }
        public string LanguageCode { get { return "en"; } }
        public string Close { get { return "Close"; } }
        public string Current { get { return "Current"; } }
        public string DragFile { get { return "Drag text file here or press"; } }
        public string Encoding { get { return "Encoding"; } }
        public string English { get { return "English"; } }
        public string Exit { get { return "Exit"; } }
        public string File { get { return "File"; } }
        public string Language { get { return "Language"; } }
        public string OnlyOneFileSupported { get { return "Only one file is supported, drag and drop one file"; } }
        public string Open { get { return "Open"; } }
        public string Russian { get { return "Русский"; } }
        public string Save { get { return "Save"; } }
        public string SaveAs { get { return "Save as"; } }
        public string Tools { get { return "Tools"; } }
        public string YourEncoding { get { return "Your Encoding"; } }
        public string RemoveStringWithWordTool { get { return "Remove strings with certain word"; } }
        public string RemoveStringWithOutWordTool { get { return "Remove strings without certain word"; } }
        public string StatisticsOnOccurrences { get { return "Statistics on occurrences"; } }
        public string StatisticsOnOccurrencesWithWord { get { return "How many lines contain certain word"; } }
    }
}
