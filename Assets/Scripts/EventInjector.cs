﻿using System;
using UnityEngine;

namespace MultiLanguageTK
{
    /// <summary>
    /// Implement part of event and delegate
    /// </summary>
    public class EventInjector : MonoBehaviour
    {
        [SerializeField] private TextMesh textmesh;

        ILoadable Loadable = (ILoadable)MutliLanguageManager.Instance;

        /// <summary>
        /// Initialization
        /// </summary>
        void Awake()
        {
            

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
} //namespace