using UnityEngine;

namespace MultiLanguageTK
{
    public abstract class TranslationTextBase : MonoBehaviour
    {
        protected ILoadable Loadable = LoadManager.GetInstance();

        public abstract void Replace();

        [SerializeField] protected ResourceLang ResourceLanguage;
        [SerializeField] protected TargetLang TargetLanguage;

        [Tooltip("Settings for resource language.")] [SerializeField]
        protected bool AutoDetectLanguage = true;
    }
}