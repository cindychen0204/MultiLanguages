using System;
using UnityEngine;


namespace MultiLanguageTK
{
    public class ReplacerTesting : TranslationTextBase
    {

        [SerializeField] private TextMesh textmesh;


        /// <summary>
        /// Memo: Implemented before Start() method in MultiLanguageManger.cs
        /// </summary>
        void Awake()
        {
            ReplacerTesting replacerTesting = this.GetComponent<ReplacerTesting>();

            Loadable.googleSheetDictionaryInjected += replacerTesting.OngoogleSheetDictionaryInjected;

        }


        public override void OngoogleSheetDictionaryInjected(object source, EventArgs e)
        {
            Debug.Log("Translation Results:");

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



            Debug.Log("Translation Results:" + transResults);

        }
    }

}

