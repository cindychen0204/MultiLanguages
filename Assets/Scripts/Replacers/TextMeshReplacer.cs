using System.Threading.Tasks;
using UnityEngine;

namespace MultiLanguageTK
{
    public class TextMeshReplacer : TranslationTextBase
    {
        [SerializeField] private TextMesh textmesh;

        private TargetLang language;

        void Awake()
        {
            Replace();
        }

        void Update()
        {
            //Debug.Log(Loadable.TranslationResults(ResourceLanguage.ToString(), TargetLanguage.ToString(), textmesh.text));
        }

        public override async void Replace()
        {
            string transResults = null;
            //結果ディクショナリーのインプットを待つ
            await Task.Run(() => Loadable.GoogleSheetLoader());

            if (AutoDetectLanguage)
            {
                DetectEnviromentalLanguage();
                transResults =
                    Loadable.TranslationResults(ResourceLanguage.ToString(), language.ToString(), textmesh.text);
            }
            else
            {
                transResults = Loadable.TranslationResults(ResourceLanguage.ToString(), TargetLanguage.ToString(),
                    textmesh.text);
            }

            textmesh.text = transResults;

            Debug.Log(transResults);
        }

        void DetectEnviromentalLanguage()
        {
            if (Application.systemLanguage == SystemLanguage.English)
            {
                language = TargetLang.En;
                TargetLanguage = TargetLang.En;
            }

            else if (Application.systemLanguage == SystemLanguage.Japanese)
            {
                language = TargetLang.Ja;
                TargetLanguage = TargetLang.Ja;
            }
            else if (Application.systemLanguage == SystemLanguage.ChineseSimplified)
            {
                language = TargetLang.Zhcn;
                TargetLanguage = TargetLang.Zhcn;
            }
            else if (Application.systemLanguage == SystemLanguage.ChineseTraditional)
            {
                language = TargetLang.Zhtw;
                TargetLanguage = TargetLang.Zhtw;
            }
        }
    }
}