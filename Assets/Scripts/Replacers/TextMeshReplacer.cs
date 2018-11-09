using UnityEngine;

namespace MultiLanguageTK
{
    public class TextMeshReplacer : TranslationTextBase
    {
        void Awake()
        {

            Replace();
        }
        
        public override void Replace()
        {

            Debug.Log("にほんご　日本語　ニホンゴ");
            var tmp = _loadable.Hello("調整");
            Debug.Log($"Return output: {_loadable.Hello("調整")} クラスインターフェース経由");

        }

    }
}