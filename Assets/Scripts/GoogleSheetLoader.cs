using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;
using System.Runtime.InteropServices;

namespace LanguageTK
{
    public class GoogleSheetLoader : MonoBehaviour{ 

        /// <summary>
        /// CSVファイル各行のKey, Valueを入れる辞書string:(Text,Language),Value
        /// </summary>
        private Dictionary<Tuple<string, string>, string> LanguageTable = new Dictionary<Tuple<string, string>, string> ();

        /// <summary>
        /// TranslationResult from google sheet
        /// </summary>
        TranslationData translationData = new TranslationData();

        //private static string key[] = translationData.Key;

        private string[] Zhcn;



        private void Start() {

             Zhcn = translationData.Zhcn;

            foreach (string i in Zhcn) {
                Debug.Log(i);
                Debug.Log("Here");
            }
            
    }



        /// <summary>
        /// GoogleSheetDataを読み込み
        /// </summary>
        /// <param name="filenameWithExt">拡張子付きファイル名</param>
        private void loadGoogleSheetdata()
        {

            LanguageTable.Clear();

            LanguageTable.Add(Tuple.Create( "Jan", "こんにちは" ), "Hello");

        }
        

       
    }
}