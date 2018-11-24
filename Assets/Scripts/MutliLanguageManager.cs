using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace MultiLanguageTK
{
    using System;

    public enum Languages
    {
        En,
        Ja,
        Zhcn,
        Zhtw
    };

    /// <summary>
    /// Implement singleton
    /// </summary>
    public sealed class MutliLanguageManager : MonoBehaviour, ILoadable
    {

        /// <summary>
        ///  Collecting data from googleTranslation Sheet (Quick-Sheet)
        /// </summary>
        [SerializeField] private Translation _translation;

        /// <summary>
        /// ディクショナリー、タプルは翻訳のキー
        /// Tuple<元言語、ターゲット言語、翻訳したい内容>, Dictionary のValueは翻訳結果
        /// </summary>
        private static Dictionary<TranslationKey, string> _languageDict = new Dictionary<TranslationKey, string>();



        /// <summary>
        /// no need???/
        /// </summary>
        public event EventHandler googleSheetDictionaryInjected;


        /// <summary>
        /// Singleton implement
        /// </summary>
        public static MutliLanguageManager GetInstance()
        {
            return new MutliLanguageManager();
        }

        public void OngoogleSheetDictionaryInjected()
        {
            if (googleSheetDictionaryInjected != null)
            {
                googleSheetDictionaryInjected(this, EventArgs.Empty);
            }

        }

        void Start()
        {

            GoogleSheetLoader();

            //Debug.Log(_translation);

            //TranslationResults(Languages.En, Languages.Ja, "hello")
            //string x = TranslationResults(Languages.En, Languages.Ja, "hello");

        }


        /// <summary>
        /// Importing data from GoogleSheet
        /// </summary>
        public void GoogleSheetLoader()
        {
            _languageDict.Clear();

            var languageArray = _translation.dataArray;

            //Collecting GoogleSheet into dictionary
            Parallel.For(0, languageArray.Length, i =>
            {
                //Debug.Log(T.En[0]);
                var T = languageArray[i];
                // En -> ??
                AddSafe(new TranslationKey(Languages.En, Languages.Ja, T.En[0].ToLower()), T.Ja[0]);

                AddSafe(new TranslationKey(Languages.En, Languages.Zhcn, T.En[0].ToLower()), T.Zhcn[0]);

                AddSafe(new TranslationKey(Languages.En, Languages.Zhtw, T.En[0].ToLower()), T.Zhtw[0]);


                //Ja - > ??
                AddSafe(new TranslationKey(Languages.Ja, Languages.En, T.Ja[0]), T.En[0]);

                AddSafe(new TranslationKey(Languages.Ja, Languages.Zhcn, T.Ja[0]), T.Zhcn[0]);

                AddSafe(new TranslationKey(Languages.Ja, Languages.Zhtw, T.Ja[0]), T.Zhtw[0]);


                //Zhcn -> ??
                AddSafe(new TranslationKey(Languages.Zhcn, Languages.En, T.Zhcn[0]), T.En[0]);

                AddSafe(new TranslationKey(Languages.Zhcn, Languages.Ja, T.Zhcn[0]), T.Ja[0]);

                AddSafe(new TranslationKey(Languages.Zhcn, Languages.Zhtw, T.Zhcn[0]), T.Zhtw[0]);


                //Zhtw -> ??
                AddSafe(new TranslationKey(Languages.Zhtw, Languages.En, T.Zhtw[0]), T.En[0]);

                AddSafe(new TranslationKey(Languages.Zhtw, Languages.Ja, T.Zhtw[0]), T.Ja[0]);

                AddSafe(new TranslationKey(Languages.Zhtw, Languages.Zhcn, T.Zhtw[0]), T.Zhcn[0]);

            });

            OngoogleSheetDictionaryInjected();

          
        }


        /// <summary>
        /// Return translation results
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="target"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public string TranslationResults(Languages resource, Languages target, string input)
        {
            input.ToLower();
            GoogleSheetLoader();

            string value = null;
            if (_languageDict.TryGetValue(new TranslationKey(resource, target, input), out value))
            {
                Debug.Log("Finding result...." + new TranslationKey(resource, target, input));
                return value;
                
            }

            return value;

        }

        /// <summary>
        /// Add into dictionary safely
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void AddSafe(TranslationKey key, string value)
        {
            string notuse = null;
            if (_languageDict.TryGetValue(key, out notuse))
            {
                return;
            }

            //Debug.Log("Key : "+ key +  "value : "+ value);

            _languageDict.Add(key,value);
        }
    } //class
} //namespace