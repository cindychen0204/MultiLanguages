using UnityEngine;


namespace MultiLanguageTK
{

    public abstract class TranslationTextBase : MonoBehaviour
    {
        private readonly ILoadable _loadable = new LoadManager();
 

        [SerializeField] protected ResourceLang ResourceLanguage;
       

        [Tooltip("Settings for resource language.")]
        [SerializeField] private bool AutoDetectLanguage = true;
        [SerializeField] protected TargetLang TargetLanguage;



        public abstract void Replace();

    }
}