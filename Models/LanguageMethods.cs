using System;
using System.Linq;
using System.Reflection;

namespace YarcheTextEditor.Models
{
    public static class LanguageMethods
    {
        /// <summary>
        /// Get language object by language code
        /// </summary>
        /// <param name="languageCode"></param>
        /// <returns></returns>
        public static ILanguage GetLanguage(string languageCode)
        {
            foreach (Type languageType in Assembly.GetExecutingAssembly().GetTypes().Where(languageType => languageType.GetInterfaces().Contains(typeof(ILanguage))))
            {
                object languageObject = Activator.CreateInstance(languageType);
                var language = languageObject as ILanguage;
                if (language.LanguageCode == languageCode) return language;
            }

            return new EnglishLanguage();
        }
    }
}
