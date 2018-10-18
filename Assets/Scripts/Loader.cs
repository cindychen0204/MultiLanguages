using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;
using System.Runtime.InteropServices;

namespace LanguageTK
{
    public class GoogleSheetLoader { 
        


        /// <summary>
        /// CSVファイル
        /// </summary>
        private TextAsset csvFile;

        /// <summary>
        /// CSVファイル各行のKey, Valueを入れる辞書string:(Text,Language),Value
        /// </summary>
        private Dictionary<Tuple<string, string>, string> LanguageTable = new Dictionary<Tuple<string, string>, string> ();

        TranslationData translationData = new TranslationData();

        //private static string key[] = translationData.Key;
       

        /// <summary>
        /// CSVファイルを読み込みます
        /// </summary>
        /// <param name="filenameWithExt">拡張子付きファイル名</param>
        private void loadGoogleSheetdata()
        {

            LanguageTable.Clear();
            int count = 0;
           
            // 一行ずつ読み込み処理する
            while (count < LanguageTable.Count) { 

                    if (Application.systemLanguage == SystemLanguage.English)
                    {
                        //LanguageTable.Add(Tuple.Create("en", Languages.English.ToString()), column[1]);
                        continue;
                        
                    }

                    
                }
            }
        

       
    }
}