using System.Collections.Generic;
using System;
using System.Threading.Tasks;

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
        Task<string> TranslationResultsAsync(Languages resource, Languages target, string input);
    }
}
    