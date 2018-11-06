using System;
using UnityEngine;

namespace MultiLanguageTK
{
    public class TextMeshReplacer : TranslationTextBase
    {

        public override void Replace()
        {
            try
            {
                var text = this.GetComponent<TextMesh>().text;
                text = translationResult;
            }

            catch (Exception ex)
            {

                Debug.Log(ex);
            }
        }
    }
}