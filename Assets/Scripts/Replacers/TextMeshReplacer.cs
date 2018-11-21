using System;
using UnityEngine;

namespace MultiLanguageTK
{
    public class TextMeshReplacer : TranslationTextBase
    {
        [SerializeField] private TextMesh textmesh;

        ILoadable Loadable = MutliLanguageManager.GetInstance();

        public TextMeshReplacer()
        {
            
        }

        /// <summary>
        /// Memo: Implemented before Start() method in MultiLanguageManger.cs
        /// </summary>
        void Awake()
        {
          
            Loadable.googleSheetDictionaryInjected += OngoogleSheetDictionaryInjected;

        }

        void Update()
        {
            //Debug.Log(Loadable.TranslationResults(ResourceLanguage.ToString(), TargetLanguage.ToString(), textmesh.text));
        }

        public override void OngoogleSheetDictionaryInjected(object source, EventArgs e)
        {
            Debug.Log("Translation Results:");

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

            textmesh.text = transResults;



            Debug.Log("Translation Results:" + transResults);

            //Debug.Log(e);
        }

        //public override void Replace()
        //{
        //    string transResults = null;
        //    //結果ディクショナリーのインプットを待つ
            

        //    if (AutoDetectLanguage)
        //    {
        //        DetectEnviromentalLanguage();
        //        transResults = Loadable.TranslationResults(ResourceLanguage, TargetLanguage, textmesh.text);
        //    }
        //    else
        //    {
        //        transResults = Loadable.TranslationResults(ResourceLanguage, TargetLanguage, textmesh.text);
        //    }

        //    textmesh.text = transResults;

        //    Debug.Log(transResults);
        //}

        void DetectEnviromentalLanguage()
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

        //public override void Replace()
        //{
        //    throw new NotImplementedException();
        //}
    }
}