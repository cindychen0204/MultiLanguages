using System;
using UnityEngine;

namespace MultiLanguageTK
{
    public abstract class TranslationTextBase : MonoBehaviour
    {
        protected ILoadable Loadable;

        //public abstract void Replace();

        public abstract void OngoogleSheetDictionaryInjected(object source, EventArgs e);

        [SerializeField] protected Languages ResourceLanguage;

        [SerializeField] protected Languages TargetLanguage;

        [Tooltip("Settings for resource language.")] [SerializeField]
        protected bool AutoDetectLanguage = true;

      
    }
}