using System;
using UnityEngine;

namespace MultiLanguageTK
{
    public enum TranslateResource
    {
        GoogleSheet,
        Excel,
        CSV
    }


    public abstract class TranslationTextBase : MonoBehaviour
    {
        protected ITranslator Translator;



        [Tooltip("テキストの言語を取得")]
        [SerializeField] protected bool IsDetectTextLanguage = true;
        [SerializeField] protected Languages SourceLanguage;


        [Tooltip("環境の言語を取得")]
        [SerializeField] protected bool IsDetectEnvironmentalLanguage = true;
        [SerializeField] protected Languages TargetLanguage;

        [SerializeField] protected TranslateResource TranslateResource;

        public abstract void TranslateDictionaryInjected(object source, EventArgs e);

        /// <summary>
        /// 環境の言語を取得
        /// </summary>
        protected abstract void DetectEnvironmentalLanguage();

        /// <summary>
        /// テキストの言語を取得
        /// </summary>
        /// <param name="str"></param> テキストの内容
        protected abstract void DetectTextLanguage(string str);



    }
}