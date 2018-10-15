using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace HKT
{
    /// <summary>
    /// ローカライズ処理のサンプル
    /// </summary>
    public class LocalizeHoloLens : MonoBehaviour
    {
        /// <summary>
        /// CSVファイル
        /// </summary>
        private TextAsset csvFile;

        /// <summary>
        /// CSVファイル各行のKey, Valueを入れる辞書
        /// </summary>
        private Dictionary<string, string> dict = new Dictionary<string, string>();

        /// <summary>
        /// CSVの読み込んだ行数
        /// </summary>
        private int rowCount;

        /// <summary>
        /// すべてのゲームオブジェクトの取得、Boolは翻訳の時、訪れたことがあるかどうかを記録
        /// </summary>
        private Dictionary<GameObject, bool> gameObjectinScene = new Dictionary<GameObject, bool>();

        /// <summary>
        /// 重複を避ける
        /// </summary>
        private int count = 0;

        /// <summary>
        /// ゲームオブジェクトの個数
        /// </summary>
        private int tempLength = 0;

        void Start()
        {

            LoadCSV("StringTable.csv");
            //Debug.Log("読み込んだ行数 : " + rowCount);

            // 一覧表示
            //foreach (var data in dict)
            //{
            //    Debug.Log("Key:" + data.Key + ", Value:" + data.Value);
            //}


            // 指定のキーの値を表示
            //Debug.Log(dict["That".ToLower()]);
            //Debug.Log(gameObjectinScene[GameObject.Find("MixedRealityCameraParent")]);
        }

        private void Update()
        {
            if (tempLength != UnityEngine.Resources.FindObjectsOfTypeAll(typeof(GameObject)).Length)
            {

                //Scene の中にあるすべてのゲームオブジェクトを取得
                foreach (GameObject obj in UnityEngine.Resources.FindObjectsOfTypeAll(typeof(GameObject))) {
                    if (obj.GetComponent<TextMesh>() != null) {
                        //obj.tag = "Text";
                        //obj.GetComponent<TextMesh>().text = "Hello";
                        if (dict.ContainsKey(obj.GetComponent<TextMesh>().text.ToLower())) { 

                            obj.GetComponent<TextMesh>().text = dict[obj.GetComponent<TextMesh>().text.ToLower()];
                            
                        }
                    }
                }
                tempLength = UnityEngine.Object.FindObjectsOfType(typeof(GameObject)).Length;
            }

           
           
        }
        /// <summary>
        /// CSVファイルを読み込みます
        /// </summary>
        /// <param name="filenameWithExt">拡張子付きファイル名</param>
        private void LoadCSV(string filenameWithExt)
        {
            // 拡張子無し文字列にする
            string filename = Path.GetFileNameWithoutExtension(filenameWithExt.Trim());

            dict.Clear();
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
                        dict.Add(column[0], column[1]);
                       
                    }
                    else if (Application.systemLanguage == SystemLanguage.Japanese)
                    {
                        dict.Add(column[0], column[2]);

                    }
                    else if (Application.systemLanguage == SystemLanguage.ChineseTraditional)
                    {
                        dict.Add(column[0], column[3]);

                    }
                    else if (Application.systemLanguage == SystemLanguage.ChineseSimplified)
                    {
                        dict.Add(column[0], column[4]);

                    }
                    rowCount++;
                }
            }
        }

    } // class
} // namespace