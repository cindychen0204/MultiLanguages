using System;
using UnityEngine;

namespace MultiLanguageTK
{
    /// <summary>
    /// Implement part of event and delegate
    /// </summary>
    public class EventInjector : MonoBehaviour
    {
        [SerializeField] private TextMesh textmesh;


        private string outputText;

        private ILoadable Loadable;
        /// <summary>
        /// Initialization
        /// </summary>
        void Start()
        {
            Loadable = (ILoadable)MutliLanguageManager.Instance;

            Loadable.googleSheetDictionaryInjected += OngoogleSheetDictionaryInjected;

            outputText = textmesh.text;
        }


        /// <summary>
        /// Event subscriber
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void OngoogleSheetDictionaryInjected(object source, EventArgs e)
        {
            string transResults = null;

            transResults = Loadable.TranslationResults(Languages.En, Languages.Ja, outputText);
            //transResults = Loadable.Hello(outputText);
            textmesh.text = transResults;

        }

    }
} //namespace