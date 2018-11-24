using System;
using UnityEngine;

namespace MultiLanguageTK
{
    public class EventInjectorSecond : MonoBehaviour
    {
        [SerializeField] private TextMesh textmesh;

        /// <summary>
        /// Initialization
        /// </summary>
        void Awake()
        {
            var Loadable = (ILoadable)MutliLanguageManager.Instance;

            Loadable.googleSheetDictionaryInjected += OngoogleSheetDictionaryInjected;
        }

        /// <summary>
        /// Event subscriber
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void OngoogleSheetDictionaryInjected(object source, EventArgs e)
        {
            Debug.Log("Translation Results:");

            string transResults = "Event Completed";

            textmesh.text = transResults;

            Debug.Log("Translation Results:" + transResults);
        }

    }
}