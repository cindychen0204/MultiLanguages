﻿using System.Collections.Generic;
using UnityEngine;

namespace MultiLanguageTK
{
    using System;

    /// <summary>
    /// Load data from GoogleSheet
    /// GoogleSheetから取得したデータをロードする
    /// </summary>
    public sealed class GoogleSheetLoader : MonoBehaviour, ITranslator
    {

        /// <summary>
        /// DO NOT CHANGE THE NAME,
        /// TranslationといったScriptableObjectを取得（名前変更禁止）
        /// </summary>
        [SerializeField] private Translation _translation;


        /// <summary>
        /// TranslationKeyの初期化
        /// </summary>
        private static TranslationKey TranslationKey;


        /// <summary>
        /// ディクショナリー
        /// TranslationKey<元言語、ターゲット言語、翻訳内容>, Dictionary のValueは翻訳結果
        /// </summary>
        private static Dictionary<TranslationKey, string> languageDict = new Dictionary<TranslationKey, string>();

        /// <summary>
        /// イベント作成
        /// </summary>
        public event EventHandler DictionaryInjected;


        /// <summary>
        /// シングルトンの実装（プライベート）
        /// </summary>
        private static GoogleSheetLoader _instance;

        /// <summary>
        /// シングルトンの実装（パブリック）
        /// </summary>
        public static GoogleSheetLoader Instance
        {
            get
            {
                if (_instance == null)
                {
                    var previous = FindObjectOfType(typeof(GoogleSheetLoader));
                    if (previous)
                    {
                        Debug.LogWarning("Initialized twice. Don't use MidiBridge in the scene hierarchy.");
                        _instance = (GoogleSheetLoader)previous;
                    }
                    else
                    {
                        var go = new GameObject("__MidiBridge");
                        _instance = go.AddComponent<GoogleSheetLoader>();
                        DontDestroyOnLoad(go);
                        go.hideFlags = HideFlags.HideInHierarchy;
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// イベントの購読者を見つける
        /// </summary>
        public void OngoogleSheetDictionaryInjected()
        {
            if (DictionaryInjected != null)
            {
                DictionaryInjected(this, EventArgs.Empty);

            }

            //DictionaryInjected?.Invoke(this, EventArgs.Empty);

        }

        /// <summary>
        /// 初期化の後（購読者ReplacerたちのMainメソッド）に、ロードを始める
        /// </summary>
        void Start()
        {
            Load();
        }

        /// <summary>
        /// GoogleSheetのデータをインジェクト
        /// </summary>
        private void Load()
        {

            languageDict.Clear();

            var languageArray = _translation.dataArray;


            foreach (var data in languageArray)
            {
                //Collecting GoogleSheet into dictionary

                //Debug.Log(T.English[0]);
                // English -> ??

                AddIfNotExists(new TranslationKey(Languages.English, Languages.Japanese, data.En[0].ToLower()), data.Ja[0]);

                AddIfNotExists(new TranslationKey(Languages.English, Languages.ChineseSimplified, data.En[0].ToLower()), data.Zhcn[0]);

                AddIfNotExists(new TranslationKey(Languages.English, Languages.ChineseTraditional, data.En[0].ToLower()), data.Zhtw[0]);


                //Ja - > ??
                AddIfNotExists(new TranslationKey(Languages.Japanese, Languages.English, data.Ja[0]), data.En[0]);

                AddIfNotExists(new TranslationKey(Languages.Japanese, Languages.ChineseSimplified, data.Ja[0]), data.Zhcn[0]);

                AddIfNotExists(new TranslationKey(Languages.Japanese, Languages.ChineseTraditional, data.Ja[0]), data.Zhtw[0]);


                //Zhcn -> ??
                AddIfNotExists(new TranslationKey(Languages.ChineseSimplified, Languages.English, data.Zhcn[0]), data.En[0]);

                AddIfNotExists(new TranslationKey(Languages.ChineseSimplified, Languages.Japanese, data.Zhcn[0]), data.Ja[0]);

                AddIfNotExists(new TranslationKey(Languages.ChineseSimplified, Languages.ChineseTraditional, data.Zhcn[0]), data.Zhtw[0]);


                //Zhtw -> ??
                AddIfNotExists(new TranslationKey(Languages.ChineseTraditional, Languages.English, data.Zhtw[0]), data.En[0]);

                AddIfNotExists(new TranslationKey(Languages.ChineseTraditional, Languages.Japanese, data.Zhtw[0]), data.Ja[0]);

                AddIfNotExists(new TranslationKey(Languages.ChineseTraditional, Languages.ChineseSimplified, data.Zhtw[0]), data.Zhcn[0]);

            }

            OngoogleSheetDictionaryInjected();


        }


        /// <summary>
        /// Return translation result
        /// 翻訳結果を返す
        /// </summary>
        /// <param name="resource"></param>ソース言語
        /// <param name="target"></param>ターゲット言語
        /// <param name="input"></param>テキスト
        /// <returns></returns>
        public string TranslateResults(Languages resource, Languages target, string input)
        {
            input = input.ToLower();//For English

            var key = new TranslationKey(resource, target, input);

            string value;

            languageDict.TryGetValue(key, out value);

            return value;

        }

        /// <summary>
        /// Avoid any error from injecting data into dictionary
        /// エラーを回避し、ディクショナリーに入れる
        /// </summary>
        /// <param name="key"></param>翻訳キー
        /// <param name="value"></param>翻訳結果
        private void AddIfNotExists(TranslationKey key, string value)
        {
            string result;
            if (languageDict.TryGetValue(key, out result) == false)
            {
                languageDict.Add(key, value);
            }

        }
    } //class
} //namespace