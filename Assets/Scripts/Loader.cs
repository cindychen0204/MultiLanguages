using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;

namespace LanguageTK
{
    public class Loader : ILoader
    {
        /// <summary>
        /// CSVファイル
        /// </summary>
        private TextAsset csvFile;

        /// <summary>
        /// CSVファイル各行のKey, Valueを入れる辞書string:(Text,Language),Value
        /// </summary>
        private Dictionary<Tuple<string, string>, string> LanguageTable = new Dictionary<Tuple<string, string>, string> ();


        //internal class LanguageTable
        //{
        //}


        /// <summary>
        /// CSVの読み込んだ行数
        /// </summary>
        private int rowCount;


        public void Load(Dictionary<Tuple<string, string>, string> LanguageDict)
        {
            throw new System.NotImplementedException();
        }


        void Main(string[] args)
        {

            LoadCSV("StringTable.csv");
        }

        /// <summary>
        /// CSVファイルを読み込みます
        /// </summary>
        /// <param name="filenameWithExt">拡張子付きファイル名</param>
        private void LoadCSV(string filenameWithExt)
        {
            // 拡張子無し文字列にする
            string filename = Path.GetFileNameWithoutExtension(filenameWithExt.Trim());

            LanguageTable.Clear();
            rowCount = 0;
            
            // CSV読み込み
            //Debug.Log("CSV FileName:" + filename);
            csvFile = Resources.Load("Localize/" + filename) as TextAsset;
            //Debug.Log(csvFile);

            // 一行ずつ読み込み処理する
            using (StringReader reader = new StringReader(csvFile.text))
            {

                while (reader.Peek() > -1)
                {

                    string line = reader.ReadLine();
                    var column = line.Split(',');
                    // 0列目がキー、1列目がバリュー想定のCSV

                    if (Application.systemLanguage == SystemLanguage.English)
                    {
                        LanguageTable.Add(Tuple.Create(column[0], Languages.English.ToString()), column[1]);
                    }

                    else if (Application.systemLanguage == SystemLanguage.Japanese)
                    {
                        LanguageTable.Add(Tuple.Create(column[0], Languages.English.ToString()), column[2]);

                    }
                    else if (Application.systemLanguage == SystemLanguage.ChineseTraditional)
                    {
                        LanguageTable.Add(Tuple.Create(column[0], Languages.English.ToString()), column[3]);

                    }
                    else if (Application.systemLanguage == SystemLanguage.ChineseSimplified)
                    {
                        LanguageTable.Add(Tuple.Create(column[0], Languages.English.ToString()), column[4]);

                    }
                    rowCount++;
                }
            }
        }
    
    }

    
}