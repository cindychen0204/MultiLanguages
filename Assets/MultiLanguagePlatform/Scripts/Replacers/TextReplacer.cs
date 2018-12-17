using System;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

namespace MultiLanguageTK
{
    [RequireComponent(typeof(Text))]
    public class TextReplacer : TranslationTextBase
    {
        [SerializeField] private Text UItext;


        private ITranslator _translator;
        /// <summary>
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
        /// Memo: Implemented before Start() method in MultiLanguageManger.cs
        /// </summary>
        void Main()
        {
            switch (TranslateResource)
            {
                case TranslateResource.GoogleSheet:

                    _translator = (ITranslator)GoogleSheetLoader.Instance;

                    break;

                case TranslateResource.Excel:

                    _translator = (ITranslator)ExcelLoader.Instance;

                    break;

                case TranslateResource.CSV:

                    _translator = (ITranslator)CSVLoader.Instance;

                    break;
            }

            _translator.DictionaryInjected += TranslateDictionaryInjected;

        }
        public override void TranslateDictionaryInjected(object source, EventArgs e)
        {

            string transResults = null;

            //環境の言語を取得
            if (IsDetectEnvironmentalLanguage)
            {
                DetectEnvironmentalLanguage();

            }

            //テキストの言語を取得
            if (IsDetectTextLanguage)
            {
                DetectTextLanguage(UItext.text);

            }

            transResults = _translator.TranslateResults(SourceLanguage, TargetLanguage, UItext.text);

            if (transResults != null)
            {
                UItext.text = transResults;
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
