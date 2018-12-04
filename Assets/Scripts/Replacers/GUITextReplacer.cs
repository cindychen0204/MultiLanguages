using System;
using UnityEngine;

namespace MultiLanguageTK
{
    public class GUITextReplacer : TranslationTextBase
    {
        [SerializeField] private GUIText GUItext;


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
                transResults = _translator.TranslateResults(ResourceLanguage, TargetLanguage, GUItext.text);
            }
            else
            {
                transResults = _translator.TranslateResults(ResourceLanguage, TargetLanguage, GUItext.text);
            }

            if (transResults != null)
            {
                GUItext.text = transResults;
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
