using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YarcheTextEditor.Models;

namespace YarcheTextEditor.Classes
{
    static public class Options
    {
        static private ILanguage _language;
        static public ILanguage Language
        {
            get
            {
                if (_language == null)
                {
                    _language = RegistryMethods.GetLanguage();
                }

                return _language;
            }
            set
            {
                _language = value;
            }
        }
    }
}
