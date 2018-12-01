using System.Collections.Generic;
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

    public class TranslationKey
    {
        public Languages Resource;
        public Languages Target;
        public string Input;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="target"></param>
        /// <param name="input"></param>
        public TranslationKey(Languages resource, Languages target, string input)
        {
            this.Resource = resource;
            this.Target = target;
            this.Input = input;
        }

        /// <summary>
        /// Override HashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Resource.GetHashCode() ^ Target.GetHashCode() ^ Input.GetHashCode();
        }


        /// <summary>
        /// Override system Equals methods
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var other = obj as TranslationKey;
            if (other == null) return false;
            return this.Resource == other.Resource && this.Target == other.Target && this.Input == other.Input;
        }



    }
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
        /// Instantiate TranslationKey
        /// </summary>
        private static TranslationKey TranslationKey;


        /// <summary>
        /// ディクショナリー、タプルは翻訳のキー
        /// Tuple<元言語、ターゲット言語、翻訳したい内容>, Dictionary のValueは翻訳結果
        /// </summary>
        private static Dictionary<TranslationKey, string> languageDict =  new Dictionary<TranslationKey, string>();

        /// <summary>
        /// Create an event
        /// </summary>
        public event EventHandler googleSheetDictionaryInjected;
        
        /// <summary>
        /// Singleton implement for private
        /// </summary>
        private static MutliLanguageManager _instance;

        /// <summary>
        /// Singleton implement for public 
        /// </summary>
        public static MutliLanguageManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    var previous = FindObjectOfType(typeof(MutliLanguageManager));
                    if (previous)
                    {
                        Debug.LogWarning("Initialized twice. Don't use MidiBridge in the scene hierarchy.");
                        _instance = (MutliLanguageManager)previous;
                    }
                    else
                    {
                        var go = new GameObject("__MidiBridge");
                        _instance = go.AddComponent<MutliLanguageManager>();
                        DontDestroyOnLoad(go);
                        go.hideFlags = HideFlags.HideInHierarchy;
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// Detection for subscribers
        /// </summary>
        public void OngoogleSheetDictionaryInjected()
        {
            if (googleSheetDictionaryInjected != null)
            {
                googleSheetDictionaryInjected(this, EventArgs.Empty);
            }

        }


        void Awake()
        {
            googleSheetDictionaryInjected += TestingTranslationResult;
            
        }
        
        /// <summary>
        /// After initialization, then started Load
        /// </summary>
        void Start()
        {
            GoogleSheetLoader();
        }

        void TestingTranslationResult(object source, EventArgs e)
        {
            string transResults = null;
            
            transResults = TranslationResults(Languages.En, Languages.Ja, "Hello");
            //transResults = Loadable.Hello(outputText);
            //Debug.Log(transResults);

        }


        /// <summary>
        /// Importing data from GoogleSheet
        /// </summary>
        private void GoogleSheetLoader()
        {
           
            languageDict.Clear();

            var languageArray = _translation.dataArray;


            foreach(var T in languageArray) {
                //Collecting GoogleSheet into dictionary

                //Debug.Log(T.En[0]);
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

            }

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
            input = input.ToLower();//For english
            //var key = translationKey(resource, target, input);


            string value = null;

            if (languageDict.TryGetValue(new TranslationKey(resource, target, input), out value))
            {
                //Debug.Log("Finding result...." + new TranslationKey(resource, target, input));
                return value;
                
            }

            ///Testing------------------
            ///
            //Debug.Log("!!!!"  + key);
            //Debug.Log("!!!!" + languageDict[key]); //Null




            var key = new TranslationKey(resource, target, input);
            Debug.Log(key);

            ///Testing------------------

            return value;

        }

        /// <summary>
        /// Add into dictionary safely
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        private void AddSafe(TranslationKey key, string value)
        {
            string notuse = null;
            if (languageDict.TryGetValue(key, out notuse))
            {   
                return;
            }
            //Debug.Log("Key : " + key + "value : " + value);

            languageDict.Add(key, value);



            ///Testing------------------


            //Debug.Log("????" + languageDict[key]);// Value Ok
            ///Testing------------------
           

            
        }
    } //class
} //namespace