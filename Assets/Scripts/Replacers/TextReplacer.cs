using System;
using UnityEngine;
using UnityEngine.UI;

namespace MultiLanguageTK
{
    public class TextReplacer : TranslationTextBase
    {
        [SerializeField] private Text UItext;


        private ITranslator _translator;

        /// <summary>
        /// Memo: Implemented before Start() method in MultiLanguageManger.cs
        /// </summary>
        void Main()
        {
            _translator = (ITranslator)GoogleSheetLoader.Instance;

            _translator.GoogleSheetDictionaryInjected += OngoogleSheetDictionaryInjected;
        }



        public override void OngoogleSheetDictionaryInjected(object source, EventArgs e)
        {


            string transResults = null;

            if (AutoDetectLanguage)
            {
                DetectEnviromentalLanguage();
                transResults = _translator.TranslateResults(ResourceLanguage, TargetLanguage, UItext.text);
            }
            else
            {
                transResults = _translator.TranslateResults(ResourceLanguage, TargetLanguage, UItext.text);
            }

            if (transResults != null)
            {
                UItext.text = transResults;
            }


        }

        public override void DetectEnviromentalLanguage()
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
    }
}
