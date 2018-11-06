using System.Collections.Generic;
using System;

namespace MultiLanguageTK
{
    public interface ILoadable
    {

        /// <summary>
        /// Load google sheet
        /// </summary>
        /// <param name="LanguageDict"> return CSV/DB results</param>
        void GoogleSheetLoader();

        string TranslationResults(string targetLang,string resourceLang,string input);


    }
}