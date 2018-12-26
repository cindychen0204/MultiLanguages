using System;

namespace MultiLanguageTK
{
    //Support language in MultiLanguageTK
    //パッケージに使われる予定のリスト    
    public enum Languages
    {
        English,
        Japanese,
        ChineseSimplified,
        ChineseTraditional
    };


    public interface ITranslator
    {
        /// <summary>
        /// Implement Translation : return translation result
        /// Translation インターフェース：翻訳結果を返す
        /// </summary>
        /// <param name="resourceLang"></param>
        /// <param name="targetLang"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        string TranslateResults(Languages resource, Languages target, string input);

        event EventHandler DictionaryInjected;



    }
}
    