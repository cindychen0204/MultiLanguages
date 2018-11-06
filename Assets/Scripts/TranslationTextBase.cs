using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MultiLanguageTK
{

    public abstract class TranslationTextBase : MonoBehaviour
    {
        public abstract void Replace();


        ILoadable load = new LoadManager();

        public TargetLang TargetLanguage;

        public ResourceLang ResourceLanguage;
    }
}