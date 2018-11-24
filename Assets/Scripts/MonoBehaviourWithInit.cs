using UnityEngine;

namespace MultiLanguageTK
{
    /// <summary>
    /// 初期化メソッドを備えたMonoBehaviour
    /// </summary>
    public class MonoBehaviourWithInit : MonoBehaviour
    {

        //初期化したかどうかのフラグ(一度しか初期化が走らないようにするため)
        private bool _isInitialized = false;

        /// <summary>
        /// 必要なら初期化する
        /// </summary>
        public void InitIfNeeded()
        {
            if (_isInitialized)
            {
                return;
            }
            Init();
            _isInitialized = true;
        }

        /// <summary>
        /// 初期化(Awake時かその前の初アクセス、どちらかの一度しか行われない)
        /// </summary>
        protected virtual void Init() { }

        //sealed overrideするためにvirtualで作成
        protected virtual void Awake() { }

    }
}