using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MultiLanguageTK
{

    public abstract class TranslationTextBase : MonoBehaviour
    {
        public abstract void Replace();

        protected string translationResult;

        ILoadable load = new LoadManager();

        [SerializeField]
        private TargetLang TargetLanguage;

        [SerializeField]
        private ResourceLang ResourceLanguage;


    }
}