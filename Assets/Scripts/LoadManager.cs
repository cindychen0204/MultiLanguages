using System;
using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity;
using UnityEngine;

namespace MultiLanguageTK
{
    public class LoadManager : Singleton<LoadManager>, ILoadable
    {

        [SerializeField] private Translation translation;
        private object targetLang;

        //Set tuple <<TargetLang,resource>,Transresult>

        /// <summary>
        /// 翻訳の言語の決定
        /// </summary>
        [HideInInspector]
        public enum TargetLang
        {
            En,
            Ja,
            Zhcn,
            Zhtw
        };

        /// <summary>
        /// リソース言語の決定
        /// </summary>
        [HideInInspector]
        public enum ResourceLang
        {
            En,
            Ja,
            Zhcn,
            Zhtw
        };

        /// <summary>
        /// ディクショナリー、タプルは翻訳のキー
        /// Tuple<元言語、ターゲット言語、翻訳したい内容>
        /// </summary>
        private Dictionary<Tuple<string, string,string>, string> LanguageDict = new Dictionary<Tuple<string, string, string>, string>() ;

        void Awake()
        {

            GoogleSheetLoader();
            Debug.Log(TranslationResults(ResourceLang.En.ToString(), TargetLang.Zhcn.ToString(), "HELLO"));

        }


        public void GoogleSheetLoader()
        {

            var languageArray = translation.dataArray;

            //Load GoogleSheet into dictionary
            foreach (var T in languageArray)
            {

                //Debug.Log(T.En[0]);

                // En -> ??
                
                AddSafe(LanguageDict,new Tuple<string, string, string>(ResourceLang.En.ToString(), TargetLang.Ja.ToString(),T.En[0].ToLower()), T.Ja[0]);
          
                AddSafe(LanguageDict, new Tuple<string, string, string>(ResourceLang.En.ToString(), TargetLang.Zhcn.ToString(), T.En[0].ToLower()), T.Zhcn[0]);
           
                AddSafe(LanguageDict, new Tuple<string, string, string>(ResourceLang.En.ToString(), TargetLang.Zhtw.ToString(),T.En[0].ToLower()), T.Zhtw[0]);



                //Ja -> ??

                AddSafe(LanguageDict, new Tuple<string, string, string>(ResourceLang.Ja.ToString(), TargetLang.En.ToString(), T.Ja[0]), T.En[0].ToLower());

                AddSafe(LanguageDict, new Tuple<string, string, string>(ResourceLang.Ja.ToString(), TargetLang.Zhcn.ToString(), T.Ja[0]), T.Zhcn[0]);

                AddSafe(LanguageDict, new Tuple<string, string, string>(ResourceLang.Ja.ToString(), TargetLang.Zhtw.ToString(), T.Ja[0]), T.Zhtw[0]);



                // Zhcn -> ??

                AddSafe(LanguageDict, new Tuple<string, string, string>(ResourceLang.Zhcn.ToString(), TargetLang.En.ToString(), T.Zhcn[0]), T.En[0].ToLower());

                AddSafe(LanguageDict, new Tuple<string, string, string>(ResourceLang.Zhcn.ToString(), TargetLang.Ja.ToString(), T.Zhcn[0]), T.Ja[0]);

                AddSafe(LanguageDict, new Tuple<string, string, string>(ResourceLang.Zhcn.ToString(), TargetLang.Zhtw.ToString(), T.Zhcn[0]), T.Zhtw[0]);



                //Zhtw -> ??

                 AddSafe(LanguageDict, new Tuple<string, string, string>(ResourceLang.Zhtw.ToString(), TargetLang.En.ToString(), T.Zhtw[0]), T.En[0].ToLower());

                 AddSafe(LanguageDict, new Tuple<string, string, string>(ResourceLang.Zhtw.ToString(), TargetLang.Ja.ToString(), T.Zhtw[0]), T.Ja[0]);
   
                 AddSafe(LanguageDict, new Tuple<string, string, string>(ResourceLang.Zhtw.ToString(), TargetLang.Zhcn.ToString(), T.Zhtw[0]), T.Zhcn[0]);


            }


        }

        public string TranslationResults(string targetLang, string resourceLang, string input)
        {
           
        
            if (LanguageDict.ContainsKey(new Tuple<string, string, string>(targetLang, resourceLang, input.ToLower())))
            {
                return LanguageDict[new Tuple<string, string, string>(targetLang, resourceLang, input.ToLower())];
            }

        
            return "Result not found.";
        }


        public static void AddSafe(Dictionary<Tuple<string, string, string>, string> languageDict, Tuple<string, string, string> key, string value)
        {
            if (!languageDict.ContainsKey(key))
                languageDict.Add(key, value);

            return;
        }
    }//class
}//namespace