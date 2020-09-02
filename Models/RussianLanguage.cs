using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YarcheTextEditor.Models
{
    public class RussianLanguage : ILanguage
    {
        public string LanguageCode { get { return "ru"; } }

        public string DragFile { get { return "Перетащите текстовый файл сюда"; } }
        public string English { get { return "English"; } }
        public string Exit { get { return "Выход"; }}
        public string File { get { return "Файл"; } }
        public string Language { get { return "Язык"; } }
        public string Open { get { return "Открыть"; } }
        public string Russian { get { return "Русский"; } }

    }
}
