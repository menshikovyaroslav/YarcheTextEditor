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
        public string Close { get { return "Закрыть"; } }
        public string DragFile { get { return "Перетащите текстовый файл сюда или нажмите"; } }
        public string Encoding { get { return "Кодировка"; } }
        public string English { get { return "English"; } }
        public string Exit { get { return "Выход"; } }
        public string File { get { return "Файл"; } }
        public string Language { get { return "Язык"; } }
        public string OnlyOneFileSupported { get { return "Поддерживается работа только с одним файлом, перетащите один файл"; } }
        public string Open { get { return "Открыть"; } }
        public string Russian { get { return "Русский"; } }
        public string Save { get { return "Сохранить"; } }
        public string SaveAs { get { return "Сохранить как"; } }
        public string Tools { get { return "Инструменты"; } }
        public string RemoveStringWithWordTool { get { return "Удалить строки с определенным словом"; } }
        public string RemoveStringWithOutWordTool { get { return "Удалить строки без определенного слова"; } }
        public string StatisticsOnOccurrences { get { return "Статистика по вхождениям"; } }
    }
}
