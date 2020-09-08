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
        string Close { get; }
        string LanguageCode { get; }
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


        string RemoveStringWithWordTool { get; }
        string RemoveStringWithOutWordTool { get; }
        string StatisticsOnOccurrences { get; }
    }
}
