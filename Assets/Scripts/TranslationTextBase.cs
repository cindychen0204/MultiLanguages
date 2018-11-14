using UnityEngine;

namespace MultiLanguageTK
{
    public abstract class TranslationTextBase : MonoBehaviour
    {
        protected ILoadable Loadable = LoadManager.GetInstance();

        public abstract void Replace();


        [SerializeField] protected Languages ResourceLanguage;

        [SerializeField] protected Languages TargetLanguage;

        [Tooltip("Settings for resource language.")] [SerializeField]
        protected bool AutoDetectLanguage = true;
    }
}