using System;
using UnityEngine;

namespace MultiLanguageTK
{
    public abstract class TranslationTextBase : MonoBehaviour
    {
        protected ILoadable Loadable;

        [SerializeField] protected Languages ResourceLanguage;

        [SerializeField] protected Languages TargetLanguage;

        [Tooltip("Settings for resource language.")] [SerializeField]
        protected bool AutoDetectLanguage = true;

        public abstract void OngoogleSheetDictionaryInjected(object source, EventArgs e);

        public abstract void DetectEnviromentalLanguage();



    }
}