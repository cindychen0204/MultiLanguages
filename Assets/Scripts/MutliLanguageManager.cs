using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace MultiLanguageTK
{
    /// <summary>
    /// Implement singleton
    /// </summary>
    public sealed class MutliLanguageManager : MonoBehaviour, ILoadable
    {
        private EventInjector eventInjector = new EventInjector();

        private TextMeshReplacer TextMeshReplacer = new TextMeshReplacer();


        public MutliLanguageManager()
        {
            
        }


        /// <summary>
        ///  Collecting data from googleTranslation Sheet (Quick-Sheet)
        /// </summary>
        [SerializeField] private Translation _translation;


        /// <summary>
        /// ディクショナリー、タプルは翻訳のキー
        /// Tuple<元言語、ターゲット言語、翻訳したい内容>, Dictionary のValueは翻訳結果
        /// </summary>
        private static Dictionary<DictionaryKey, string> _languageDict = new Dictionary<DictionaryKey, string>();

       
        /// <summary>
        /// Event pointer
        /// </summary>
        public event GoogleSheetInjectedEventHandler googleSheetDictionaryInjected;

       


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
                googleSheetDictionaryInjected(this,EventArgs.Empty);
            }

        }

        public void Start()
        {

            googleSheetDictionaryInjected += eventInjector.OngoogleSheetDictionaryInjected;
            googleSheetDictionaryInjected += TextMeshReplacer.OngoogleSheetDictionaryInjected;

            GoogleSheetLoader();

            Debug.Log(_translation);

            //TranslationResults(Languages.En, Languages.Ja, "hello")
           // string x = TranslationResults(Languages.En, Languages.Ja, "hello");

        }

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
                AddSafe(new DictionaryKey(Languages.En, Languages.Ja, T.En[0].ToLower()), T.Ja[0]);

                AddSafe(new DictionaryKey(Languages.En, Languages.Zhcn, T.En[0].ToLower()), T.Zhcn[0]);

                AddSafe(new DictionaryKey(Languages.En, Languages.Zhtw, T.En[0].ToLower()), T.Zhtw[0]);


                //Ja - > ??
                AddSafe(new DictionaryKey(Languages.Ja, Languages.En, T.Ja[0]), T.En[0]);

                AddSafe(new DictionaryKey(Languages.Ja, Languages.Zhcn, T.Ja[0]), T.Zhcn[0]);

                AddSafe(new DictionaryKey(Languages.Ja, Languages.Zhtw, T.Ja[0]), T.Zhtw[0]);


                //Zhcn -> ??
                AddSafe(new DictionaryKey(Languages.Zhcn, Languages.En, T.Zhcn[0]), T.En[0]);

                AddSafe(new DictionaryKey(Languages.Zhcn, Languages.Ja, T.Zhcn[0]), T.Ja[0]);

                AddSafe(new DictionaryKey(Languages.Zhcn, Languages.Zhtw, T.Zhcn[0]), T.Zhtw[0]);


                //Zhtw -> ??
                AddSafe(new DictionaryKey(Languages.Zhtw, Languages.En, T.Zhtw[0]), T.En[0]);

                AddSafe(new DictionaryKey(Languages.Zhtw, Languages.Ja, T.Zhtw[0]), T.Ja[0]);

                AddSafe(new DictionaryKey(Languages.Zhtw, Languages.Zhcn, T.Zhtw[0]), T.Zhcn[0]);

            });

            OngoogleSheetDictionaryInjected();

          
        }

        public string TranslationResults(Languages resource, Languages target, string input)
        {
            input.ToLower();
            GoogleSheetLoader();

            string value = null;
            if (_languageDict.TryGetValue(new DictionaryKey(resource, target, input), out value))
            {
                Debug.Log("Finding result...." + new DictionaryKey(resource, target, input));
                return value;
                
            }

            return value;

        }

        public static void AddSafe(DictionaryKey key, string value)
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