using System.Threading.Tasks;
using UnityEngine;

namespace MultiLanguageTK
{
    public class TextMeshReplacer : TranslationTextBase
    {
        [SerializeField] private TextMesh textmesh;
        

        void Awake()
        {
           
            Replace();
        }

        void Update()
        {
            //Debug.Log(Loadable.TranslationResults(ResourceLanguage.ToString(), TargetLanguage.ToString(), textmesh.text));
        }

        public async override void Replace()
        {
            string transResults = null;
            //結果ディクショナリーのインプットを待つ
            

            if (AutoDetectLanguage)
            {
                DetectEnviromentalLanguage();
                transResults = await Loadable.TranslationResultsAsync(ResourceLanguage, TargetLanguage, textmesh.text);
            }
            else
            {
                transResults = await Loadable.TranslationResultsAsync(ResourceLanguage, TargetLanguage, textmesh.text);
            }

            textmesh.text = transResults;

            Debug.Log(transResults);
        }

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
    }
}