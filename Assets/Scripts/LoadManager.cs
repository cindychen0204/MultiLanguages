using System;
using System.Collections.Generic;
using UnityEngine;

namespace MultiLanguageTK
{
    public sealed class LoadManager : MonoBehaviour, ILoadable
    {
        [SerializeField] private Translation _translation;

        private bool _dictionaryCompleted;
        private int _conveyingInt;

        public bool DictionaryCompleted
        {
            get { return _dictionaryCompleted; }
            set { _dictionaryCompleted = value; }
        }

        public int ConveyingInt
        {
            get { return _conveyingInt; }
            set { _conveyingInt = value; }
        }

        /// <summary>
        /// ディクショナリー、タプルは翻訳のキー
        /// Tuple<元言語、ターゲット言語、翻訳したい内容>, Dictionary のValueは翻訳結果
        /// </summary>
        private static Dictionary<Tuple<string, string, string>, string> _languageDict;

        /// <summary>
        /// Singleton implement
        /// </summary>
        private static readonly LoadManager _loadManage = new LoadManager();

        public static LoadManager GetInstance()
        {
            return _loadManage;
        }

        void Start()
        {
            DictionaryCompleted = false;

            GoogleSheetLoader();

            if (DictionaryCompleted)
            {
                //Debug.Log("looking great!");
                //TranslationResults(ResourceLang.Ja.ToString(), TargetLang.En.ToString(), "調整");
                return;
            }
        }

        public async void GoogleSheetLoader()
        {
            _languageDict = new Dictionary<Tuple<string, string, string>, string>();
            _languageDict.Clear();

            var languageArray = _translation.dataArray;

            //Load GoogleSheet into dictionary
            foreach (var T in languageArray)
            {
                //Debug.Log(T.En[0]);

                // En -> ??
                AddSafe(_languageDict,
                    new Tuple<string, string, string>(ResourceLang.En.ToString(), TargetLang.Ja.ToString(),
                        T.En[0].ToLower()), T.Ja[0]);

                AddSafe(_languageDict,
                    new Tuple<string, string, string>(ResourceLang.En.ToString(), TargetLang.Zhcn.ToString(),
                        T.En[0].ToLower()), T.Zhcn[0]);

                AddSafe(_languageDict,
                    new Tuple<string, string, string>(ResourceLang.En.ToString(), TargetLang.Zhtw.ToString(),
                        T.En[0].ToLower()), T.Zhtw[0]);

                //Ja -> ??

                AddSafe(_languageDict,
                    new Tuple<string, string, string>(ResourceLang.Ja.ToString(), TargetLang.En.ToString(), T.Ja[0]),
                    T.En[0].ToLower());

                AddSafe(_languageDict,
                    new Tuple<string, string, string>(ResourceLang.Ja.ToString(), TargetLang.Zhcn.ToString(), T.Ja[0]),
                    T.Zhcn[0]);

                AddSafe(_languageDict,
                    new Tuple<string, string, string>(ResourceLang.Ja.ToString(), TargetLang.Zhtw.ToString(), T.Ja[0]),
                    T.Zhtw[0]);

                // Zhcn -> ??

                AddSafe(_languageDict,
                    new Tuple<string, string, string>(ResourceLang.Zhcn.ToString(), TargetLang.En.ToString(),
                        T.Zhcn[0]), T.En[0].ToLower());

                AddSafe(_languageDict,
                    new Tuple<string, string, string>(ResourceLang.Zhcn.ToString(), TargetLang.Ja.ToString(),
                        T.Zhcn[0]), T.Ja[0]);

                AddSafe(_languageDict,
                    new Tuple<string, string, string>(ResourceLang.Zhcn.ToString(), TargetLang.Zhtw.ToString(),
                        T.Zhcn[0]), T.Zhtw[0]);

                //Zhtw -> ??

                AddSafe(_languageDict,
                    new Tuple<string, string, string>(ResourceLang.Zhtw.ToString(), TargetLang.En.ToString(),
                        T.Zhtw[0]), T.En[0].ToLower());

                AddSafe(_languageDict,
                    new Tuple<string, string, string>(ResourceLang.Zhtw.ToString(), TargetLang.Ja.ToString(),
                        T.Zhtw[0]), T.Ja[0]);

                AddSafe(_languageDict,
                    new Tuple<string, string, string>(ResourceLang.Zhtw.ToString(), TargetLang.Zhcn.ToString(),
                        T.Zhtw[0]), T.Zhcn[0]);
            }

            DictionaryCompleted = true;
        }

        public string TranslationResults(string resourceLang, string targetLang, string input)
        {
            //英語対応
            input = input.ToLower();

            try
            {
                //Debug.Log("input:" + input);

                //Debug.Log("resource:" + resourceLang);

                //Debug.Log("target:" + targetLang);

                //Debug.Log("Output :" + _languageDict[new Tuple<string, string, string>(resourceLang, targetLang, input)]);

                return _languageDict[new Tuple<string, string, string>(resourceLang, targetLang, input)];
            }
            catch (Exception ex)
            {
                Debug.Log(ex);

                //Debug.Log("false :" + targetLang);
                return "Key not found in the dictionary.";
            }
        }

        public static void AddSafe(Dictionary<Tuple<string, string, string>, string> languageDict,
            Tuple<string, string, string> key, string value)
        {
            try
            {
                languageDict.Add(key, value);
                Debug.Log("key" + key+ ",value" + value);
            }
            catch (Exception ex)
            {
                //Debug.Log(ex);
            }

            return;
        }
    } //class
} //namespace