using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace MultiLanguageTK
{
    /// <summary>
    /// Not for use
    /// </summary>
    public class PrintDataTesting : MonoBehaviour
    {
        [SerializeField] private Translation translation;

        CultureInfo cultureInfo = new CultureInfo("es-ES", false);


        // Use this for initialization
        void Start()
        {
            var printTest = translation.dataArray;
            foreach (var p in printTest)
            {
                Debug.Log(p.En[0]);

            }


        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}


