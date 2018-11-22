using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MultiLanguageTK
{
    public class ReplacerTesting : TranslationTextBase
    {

        [SerializeField] private TextMesh textmesh;

        ILoadable Loadable = MutliLanguageManager.GetInstance();

        public override void OngoogleSheetDictionaryInjected(object source, EventArgs e)
        {
            //Debug.Log("Translation Results:");

            //string transResults = null;

            //if (AutoDetectLanguage)
            //{
            //    //DetectEnviromentalLanguage();
            //    transResults = Loadable.TranslationResults(ResourceLanguage, TargetLanguage, textmesh.text);
            //}
            //else
            //{
            //    transResults = Loadable.TranslationResults(ResourceLanguage, TargetLanguage, textmesh.text);
            //}

            //textmesh.text = transResults;



            //Debug.Log("Translation Results:" + transResults);

            ////Debug.Log(e);
        }
    }

}

