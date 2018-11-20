using System;

public delegate void GoogleSheetInjectedEventHandler(object source, EventArgs args);


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
        string TranslationResults(Languages resource, Languages target, string input);
        
        event GoogleSheetInjectedEventHandler googleSheetDictionaryInjected;


    }
}
    