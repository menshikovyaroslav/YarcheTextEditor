using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YarcheTextEditor.Models
{
    public class EnglishLanguage : ILanguage
    {
        public string LanguageCode { get { return "en"; } }

        public string DragFile { get { return "Drag text file here"; } }
        public string English { get { return "English"; } }
        public string Exit { get { return "Exit"; } }
        public string File { get { return "File"; } }
        public string Language { get { return "Language"; } }
        public string Open { get { return "Open"; } }
        public string Russian { get { return "Русский"; } }
    }
}
