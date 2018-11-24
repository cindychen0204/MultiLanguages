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
        void Start()
        {
            Loadable = (ILoadable)MutliLanguageManager.Instance;

            Loadable.googleSheetDictionaryInjected += OngoogleSheetDictionaryInjected;
        }


        public override void OngoogleSheetDictionaryInjected(object source, EventArgs e)
        {
         

           string transResults = null;

            if (AutoDetectLanguage)
            {
                //DetectEnviromentalLanguage();
                transResults = Loadable.TranslationResults(ResourceLanguage, TargetLanguage, textmesh.text);
            }
            else
            {
                transResults = Loadable.TranslationResults(ResourceLanguage, TargetLanguage, textmesh.text);
            }

            textmesh.text = transResults;


            Debug.Log("Translation Results:   " + transResults);

        }
    }

}

