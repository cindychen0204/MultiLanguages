using System;
using System.Text;
using UnityEngine;


namespace MultiLanguageTK
{
    public class TextMeshReplacer : TranslationTextBase
    {
        private ILoadable _loadable;


        void Awake()
        {
            _loadable = LoadManager.Instance;

            Replace();
        }

        public override void Replace()
        {

            try
            {
                var text_ = this.GetComponent<TextMesh>().text;
                var translationResult = text_;

                //To english
                switch (ResourceLanguage)
                {
                    case ResourceLang.En:
                        translationResult = _loadable.TranslationResults(ResourceLang.En.ToString(),
                            TargetLang.Ja.ToString(), "adjust");
                        break;
                    case ResourceLang.Ja:
                        translationResult = _loadable.TranslationResults(ResourceLang.Ja.ToString(),
                            TargetLang.En.ToString(), "調整");
                        break;
                    case ResourceLang.Zhtw:
                        translationResult = _loadable.TranslationResults(ResourceLang.Zhtw.ToString(),
                            TargetLang.En.ToString(), "調整");
                        break;
                    default:
                        return;
                }

                text_ = translationResult;
                //Debug.Log("Output:   " + text_);

                Debug.Log("にほんご　日本語　ニホンゴ");
                var tmp = _loadable.Hello("調整");
                Debug.Log($"Return output: {_loadable.Hello("調整")} クラスインターフェース経由");

            }
            catch (Exception ex)
            {

                Debug.Log(ex);
            }
        }

    }
}