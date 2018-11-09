using System.Collections.Generic;
using System;

namespace MultiLanguageTK
{
    public interface ILoadable
    {
        /// <summary>
        /// Translation interface: it will return a translation result
        /// </summary>
        /// <param name="resourceLang"></param>
        /// <param name="targetLang"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        string TranslationResults(string resourceLang, string targetLang, string input);

        string Hello(string input);
    }
}