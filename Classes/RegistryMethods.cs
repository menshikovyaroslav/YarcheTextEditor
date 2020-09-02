using Microsoft.Win32;
using System;
using YarcheTextEditor.Models;

namespace YarcheTextEditor.Classes
{
    public static class RegistryMethods
    {
        /// <summary>
        /// Save chosen language for next start
        /// </summary>
        /// <param name="language">chosen language</param>
        public static void SetLanguage(string language)
        {
            try
            {
                var hkcu = Registry.CurrentUser;
                RegistryKey settingsBranch = hkcu.OpenSubKey("Software\\YarcheTextEditor", true);
                settingsBranch.SetValue("Language", language, RegistryValueKind.String);

                settingsBranch?.Close();
                hkcu?.Close();
            }
            catch (Exception ex)
            {
                Log.Instance.Error(1, ex.Message, "RegistryMethods");
            }

        }

        public static ILanguage GetLanguage()
        {
            ILanguage result = new EnglishLanguage();

            try
            {
                var hkcu = Registry.CurrentUser;
                RegistryKey settingsBranch = hkcu.OpenSubKey("Software\\YarcheTextEditor", true);
                if (settingsBranch == null)
                {
                    hkcu.CreateSubKey("Software\\YarcheTextEditor");
                    settingsBranch = hkcu.OpenSubKey("Software\\YarcheTextEditor", true);
                }

                var languageCode = settingsBranch.GetValue("Language", "en").ToString();

                settingsBranch?.Close();
                hkcu?.Close();

                result = LanguageMethods.GetLanguage(languageCode);
            }
            catch (Exception ex)
            {
                Log.Instance.Error(1, ex.Message, "RegistryMethods");
            }

            return result;
        }
    }
}
