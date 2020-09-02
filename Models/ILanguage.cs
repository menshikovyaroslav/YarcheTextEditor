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
        string LanguageCode { get; }
        string DragFile { get; }
        string English { get; }
        string Exit { get; }
        string File { get; }
        string Open { get; }
        string Language { get; }
        string Russian { get; }
    }
}
