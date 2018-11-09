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
                            TargetLang.En.ToString(), "����");
                        break;
                    case ResourceLang.Zhtw:
                        translationResult = _loadable.TranslationResults(ResourceLang.Zhtw.ToString(),
                            TargetLang.En.ToString(), "����");
                        break;
                    default:
                        return;
                }

                text_ = translationResult;
                //Debug.Log("Output:   " + text_);

                Debug.Log("�ɂق񂲁@���{��@�j�z���S");
                var tmp = _loadable.Hello("����");
                Debug.Log($"Return output: {_loadable.Hello("����")} �N���X�C���^�[�t�F�[�X�o�R");

            }
            catch (Exception ex)
            {

                Debug.Log(ex);
            }
        }

    }
}