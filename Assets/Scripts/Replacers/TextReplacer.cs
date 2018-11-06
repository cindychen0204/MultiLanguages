using System;
using UnityEngine;
using UnityEngine.UI;

namespace MultiLanguageTK
{
    public class TextReplacer : TranslationTextBase
    {

        public override void Replace()
        {
            try
            {
                var text = this.GetComponent<Text>().text;
                text = translationResult;
            }

            catch (Exception ex)
            {

                Debug.Log(ex);
            }
        }
    }
}