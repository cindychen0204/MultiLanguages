using UnityEngine;
using UnityEngine.UI;

namespace LanguageTK
{
    public class MultiLanguageDisplacer : MonoBehaviour
    {
        [SerializeField]
        private Languages languages;

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
