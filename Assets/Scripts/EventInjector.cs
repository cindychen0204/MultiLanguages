using System;
using UnityEngine;

namespace MultiLanguageTK
{
    /// <summary>
    /// Implement part of event and delegate
    /// </summary>
    public class EventInjector : MonoBehaviour
    {
        [SerializeField] private static TextMesh textmesh;


        /// <summary>
        /// Initialization
        /// </summary>
        void Awake()
        {
            var Loadable = (ILoadable) MutliLanguageManager.Instance;

            EventInjector eventInjector = this.GetComponent<EventInjector>();

            Loadable.googleSheetDictionaryInjected += eventInjector.MLM_OngoogleSheetDictionaryInjected;
        }

        /// <summary>
        /// Event subscriber
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void MLM_OngoogleSheetDictionaryInjected(object source, EventArgs e)
        {
            Debug.Log("Translation Results:");

            string transResults = "Event Completed";

            textmesh.text = transResults;

            Debug.Log("Translation Results:" + transResults);
        }
    }
} //namespace