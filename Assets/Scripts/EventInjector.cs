using System;
using UnityEngine;

namespace MultiLanguageTK
{
    /// <summary>
    /// implement part of event and delegate
    /// </summary>
    public class EventInjector : MonoBehaviour
    {
        void Awake()
        {
            ILoadable Loadable = MutliLanguageManager.GetInstance();

            Loadable.googleSheetDictionaryInjected += OngoogleSheetDictionaryInjected;           

        }

        public void OngoogleSheetDictionaryInjected(object source, EventArgs e)
        {
            string transResults = "EventInjectorLooksGreat!";

            Debug.Log(transResults);
        }
    }
} //namespace