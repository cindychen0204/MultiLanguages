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

            Debug.Log("�ɂق񂲁@���{��@�j�z���S");
            var tmp = _loadable.Hello("����");
            Debug.Log($"Return output: {_loadable.Hello("����")} �N���X�C���^�[�t�F�[�X�o�R");

        }

    }
}