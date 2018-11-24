using System;
using UnityEngine;

namespace MultiLanguageTK
{
    /// <summary>
    /// implement part of event and delegate
    /// </summary>
    public class EventInjector : MonoBehaviour
    {
        [SerializeField] private static TextMesh textmesh;

        public EventInjector(MutliLanguageManager MLM)
        {
            var Loadable = (ILoadable)MLM;

            Loadable.googleSheetDictionaryInjected += MLM_OngoogleSheetDictionaryInjected;
        }


        public void MLM_OngoogleSheetDictionaryInjected(object source, EventArgs e)
        {
            Debug.Log("Translation Results:");

            string transResults = "Event Completed";

            textmesh.text = transResults;

            Debug.Log("Translation Results:" + transResults);

        }
    }
} //namespace