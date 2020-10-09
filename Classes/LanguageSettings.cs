using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YarcheTextEditor.Models;

namespace YarcheTextEditor.Classes
{
    public static class LanguageSettings
    {
        private static ILanguage _language { get; set; }
        public static ILanguage Language
        {
            get
            {
                return _language;
            }
            set
            {
                _language = value;
                RegistryMethods.SetLanguage(Language);

                var eventArgs = new LanguageEventArgs(Language);
                LanguageChangedHandler?.Invoke(null, eventArgs);
            }
        }

        public static EventHandler<LanguageEventArgs> LanguageChangedHandler;
    }

    public class LanguageEventArgs : EventArgs
    {
        public ILanguage Language;
        public LanguageEventArgs(ILanguage language)
        {
            Language = language;
        }
    }
}
