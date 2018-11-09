using System;
using System.Collections.Generic;
using HoloToolkit.Unity;
using UnityEngine;

namespace MultiLanguageTK
{
    public class LoadManager : Singleton<LoadManager>, ILoadable
    {

        [SerializeField] private Translation translation;

        /// <summary>
        /// ディクショナリー、タプルは翻訳のキー
        /// Tuple<元言語、ターゲット言語、翻訳したい内容>, Dictionary のValueは翻訳結果
        /// </summary>
        private static Dictionary<Tuple<string, string, string>, string> LanguageDict = new Dictionary<Tuple<string, string, string>, string>();



        void Start()
        {

            GoogleSheetLoader();
            LanguageDict.Clear();
            //TranslationResults(ResourceLang.Ja.ToString(), TargetLang.En.ToString(), "調整");
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

        public string TranslationResults(string resourceLang,string targetLang, string input)
        {
            //英語対応
            input = input.ToLower();
            try
            {
                
                Debug.Log("input:" + input);
                Debug.Log("resource:" + resourceLang);

                Debug.Log("target:" + targetLang);

                Debug.Log("Output :" + LanguageDict[new Tuple<string, string, string>(resourceLang, targetLang, input)]);
                
                return LanguageDict[new Tuple<string, string, string>(resourceLang, targetLang, input)];


            }
            catch (Exception ex)
            {

                Debug.Log(ex);

                //Debug.Log("false :" + targetLang);
                return "Key not found in the dictionary.";
                
            }

        }

        public string Hello(string input)
        {

            //Byte[] encodedBytes = asc2Encoding.GetBytes(input);
            //string output = asc2Encoding.GetString(encodedBytes);

            var text = "調整";

            Debug.Log("Local string: " + input);
            Debug.Log("Local string: text" + text);

            return input;
        }


        public static void AddSafe(Dictionary<Tuple<string, string, string>, string> languageDict, Tuple<string, string, string> key, string value)
        {
            try
            {
                languageDict.Add(key, value);

            }
            catch (Exception ex)
            {

                //Debug.Log(ex);
            }

            return;
        }
    }//class
}//namespace