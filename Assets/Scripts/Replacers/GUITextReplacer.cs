using System;
using UnityEngine;

namespace MultiLanguageTK
{
    public class GUITextReplacer : TranslationTextBase
    {
        [SerializeField] private GUIText GUItext;


        private ILoadable Loadable;



        /// <summary>
        /// Memo: Implemented before Start() method in MultiLanguageManger.cs
        /// </summary>
        void Main()
        {
            Loadable = (ILoadable)MutliLanguageManager.Instance;

            Loadable.googleSheetDictionaryInjected += OngoogleSheetDictionaryInjected;
        }



        public override void OngoogleSheetDictionaryInjected(object source, EventArgs e)
        {


            string transResults = null;

            if (AutoDetectLanguage)
            {
                DetectEnviromentalLanguage();
                transResults = Loadable.TranslationResults(ResourceLanguage, TargetLanguage, GUItext.text);
            }
            else
            {
                transResults = Loadable.TranslationResults(ResourceLanguage, TargetLanguage, GUItext.text);
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
                TargetLanguage = Languages.En;
            }

            else if (Application.systemLanguage == SystemLanguage.Japanese)
            {
                TargetLanguage = Languages.Ja;

            }
            else if (Application.systemLanguage == SystemLanguage.ChineseSimplified)
            {

                TargetLanguage = Languages.Zhcn;

            }
            else if (Application.systemLanguage == SystemLanguage.ChineseTraditional)
            {
                TargetLanguage = Languages.Zhtw;

            }
        }
    }
}
