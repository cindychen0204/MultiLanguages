using System;
using UnityEngine;


namespace MultiLanguageTK
{
    public class ReplacerTesting : TranslationTextBase
    {

        [SerializeField] private TextMesh textmesh;

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
                transResults = Loadable.TranslationResults(ResourceLanguage, TargetLanguage, textmesh.text);
            }
            else
            {
                
                transResults = Loadable.TranslationResults(ResourceLanguage, TargetLanguage, textmesh.text);
                
            }

            if (transResults != null)
            {
                textmesh.text = transResults;
            }


            //Debug.Log("Translation Results:   " + transResults);

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

