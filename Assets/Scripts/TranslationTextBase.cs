using UnityEngine;


namespace MultiLanguageTK
{

    public abstract class TranslationTextBase : MonoBehaviour
    {


        protected ILoadable _loadable = LoadManager.GetInstance();

        public abstract void Replace();

        [SerializeField] protected ResourceLang ResourceLanguage;

        [Tooltip("Settings for resource language.")]
        [SerializeField] private bool AutoDetectLanguage = true;
        [SerializeField] protected TargetLang TargetLanguage;




    }
}