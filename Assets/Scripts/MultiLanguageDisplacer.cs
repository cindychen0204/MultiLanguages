using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MultiLanguageTK
{
    public class MultiLanguageDisplacer : MonoBehaviour
    {
        /// <summary>
        /// Not for use
        /// </summary>
        //[SerializeField]
        //private Languages languages;

        private void Awake()
        {
            if (this.GetComponent<TextMesh>() != null)
            {
                var text = this.GetComponent<TextMesh>().text;
                
            }

            else if (this.GetComponent<Text>() != null)
            {
                var text = this.GetComponent<Text>().text;

            }
        }

    }
}
