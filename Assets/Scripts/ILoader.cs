using System.Collections.Generic;
using System;

/// <summary>
/// Interface for Loader,and take Dictionaris as a paramater
/// </summary>
namespace LanguageTK { 
    public interface ILoader {

        /// <summary>
        /// Definition of Load
        /// </summary>
        /// <param name="LanguageDict"> return CSV/DB results</param>
        void Load(Dictionary<Tuple<string, string>, string> LanguageDict);

    }
}
