using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YarcheTextEditor.Models
{
    public interface ILanguage
    {
        /// <summary>
        /// Code to fast access
        /// </summary>
        string AllFiles { get; }
        string Close { get; }
        string Current { get; }
        string LanguageCode { get; }
        string DeleteEmptyLines { get; }
        string DragFile { get; }
        string Encoding { get; }
        string English { get; }
        string Exit { get; }
        string File { get; }
        string Open { get; }
        string Language { get; }
        string Russian { get; }
        string Save { get; }
        string SaveAs { get; }
        string Tools { get; }
        string OnlyOneFileSupported { get; }
        string YourEncoding { get; }

        string RemoveStringWithWordTool { get; }
        string RemoveStringWithOutWordTool { get; }
        string RemoveWordTool { get; }
        string ReplaceWordTool { get; }
        string StatisticsOnOccurrences { get; }
        string StatisticsOnOccurrencesWithWord { get; }
    }
}
