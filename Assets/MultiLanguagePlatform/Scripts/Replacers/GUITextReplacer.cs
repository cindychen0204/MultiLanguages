using System;
using System.Text.RegularExpressions;
using UnityEngine;

namespace MultiLanguageTK
{
    [RequireComponent(typeof(GUIText))]
    public class GUITextReplacer : TranslationTextBase
    {
        [SerializeField] private GUIText GUItext;


        private ITranslator _translator;
        /// <summary>
        /// Check with regular expression
        /// 正規表現で文字列を綺麗にする
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static string CleanUp(string str)
        {
            str = Regex.Replace(str, @"\s.", "");
            str = Regex.Replace(str, @"^[0-9]", "");
            str = Regex.Replace(str, @"^[.,!?:...]", "");

            return str;
        }

        /// <summary>
        /// Detect Japanese
        /// 日本語を判断
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static bool IsJapanese(string str)
        {
            str = CleanUp(str);

            return Regex.IsMatch(str, @"^\p{IsHiragana}*$") || Regex.IsMatch(str, @"^\p{IsKatakana}*$") || Regex.IsMatch(str, @"[\p{IsCJKUnifiedIdeographs}" +
                                                                                                                              @"\p{IsCJKCompatibilityIdeographs}" +
                                                                                                                              @"\p{IsCJKUnifiedIdeographsExtensionA}]|" +
                                                                                                                              @"[\uD840-\uD869][\uDC00-\uDFFF]|\uD869[\uDC00-\uDEDF]");
        }

        /// <summary>
        /// Detect English
        /// 英語を判断
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static bool IsEnglish(string str)
        {
            str = CleanUp(str);

            return Regex.IsMatch(str, @"^[a-zA-Z]+$");
        }

        /// <summary>
        /// Memo: Implemented before Start() method in Loaders.cs, and after TextReplacer conflict
        void Main()
        {
            switch (TranslateResource)
            {
                case TranslateResource.GoogleSheet:

                    _translator = (ITranslator)GoogleSheetLoader.Instance;
                    GoogleSheetLoader.Instance.OngoogleSheetDictionaryInjected();

                    break;

                case TranslateResource.Excel:

                    _translator = (ITranslator)ExcelLoader.Instance;
                    ExcelLoader.Instance.OnExcelDictionaryInjected();

                    break;

                case TranslateResource.CSV:

                    _translator = (ITranslator)CSVLoader.Instance;
                    CSVLoader.Instance.OnCSVDictionaryInjected();

                    break;
            }

            _translator.DictionaryInjected += TranslateDictionaryInjected;

        }
        public override void TranslateDictionaryInjected(object source, EventArgs e)
        {

            string transResults = null;

            //Detect environmental language
            //環境の言語を取得
            if (IsDetectEnvironmentalLanguage)
            {
                DetectEnvironmentalLanguage();

            }
            //Obtain Language of Text
            //テキストの言語を取得
            if (IsDetectTextLanguage)
            {
                DetectTextLanguage(GUItext.text);

            }

            transResults = _translator.TranslateResults(SourceLanguage, TargetLanguage, GUItext.text);

            if (transResults != null)
            {
                GUItext.text = transResults;
            }

            
        }

        protected override void DetectEnvironmentalLanguage()
        {
            if (Application.systemLanguage == SystemLanguage.English)
            {
                TargetLanguage = Languages.English;
            }

            else if (Application.systemLanguage == SystemLanguage.Japanese)
            {
                TargetLanguage = Languages.Japanese;

            }
            else if (Application.systemLanguage == SystemLanguage.ChineseSimplified)
            {

                TargetLanguage = Languages.ChineseSimplified;

            }
            else if (Application.systemLanguage == SystemLanguage.ChineseTraditional)
            {
                TargetLanguage = Languages.ChineseTraditional;

            }
        }

        protected override void DetectTextLanguage(string str)
        {
            if (IsJapanese(str))
            {
                SourceLanguage = Languages.Japanese;
            }
            else if (IsEnglish(str))
            {
                SourceLanguage = Languages.English;

            }


        }
    }
}
