using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace MultiLanguageTK
{
    public class CSVLoader : MonoBehaviour, ITranslator
    {

        /// <summary>
        /// CSVファイル
        /// </summary>
        private TextAsset csvFile;

        /// <summary>
        /// ディクショナリー
        /// TranslationKey<元言語、ターゲット言語、翻訳内容>, Dictionary のValueは翻訳結果
        /// </summary>
        private static Dictionary<TranslationKey, string> languageDict = new Dictionary<TranslationKey, string>();

        /// <summary>
        /// イベント作成
        /// </summary>
        public event EventHandler DictionaryInjected;

        /// <summary>
        /// シングルトンの実装（プライベート）
        /// </summary>
        private static CSVLoader _instance;


        /// <summary>
        /// シングルトンの実装（パブリック）
        /// </summary>
        public static CSVLoader Instance
        {
            get
            {
                if (_instance == null)
                {
                    var previous = FindObjectOfType(typeof(CSVLoader));
                    if (previous)
                    {
                        Debug.LogWarning("Initialized twice. Don't use MidiBridge in the scene hierarchy.");
                        _instance = (CSVLoader)previous;
                    }
                    else
                    {
                        var go = new GameObject("__MidiBridge");
                        _instance = go.AddComponent<CSVLoader>();
                        DontDestroyOnLoad(go);
                        go.hideFlags = HideFlags.HideInHierarchy;
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// イベントの購読者を見つける
        /// </summary>
        public void OnCSVDictionaryInjected()
        {
            DictionaryInjected?.Invoke(this, EventArgs.Empty);
        }

        [Tooltip("CSVファイルのパス（MultiLanguagePlatform/Resources/CSV/...）")]
        [SerializeField]
        private string CSVFileName = "StringTable.csv";


        /// <summary>
        /// 初期化の後（購読者ReplacerたちのMainメソッド）に、ロードを始める
        /// </summary>
        void Start()
        {
            Load(CSVFileName);
        }

        /// <summary>
        /// 重複を避ける
        /// </summary>
        private int count = 0;


        /// <summary>
        /// CSVファイルを読み込みます
        /// </summary>
        /// <param name="filenameWithExt">拡張子付きファイル名</param>
        private void Load(string filenameWithExt)
        {

            languageDict.Clear();

            // 拡張子無し文字列にする
            string filename = Path.GetFileNameWithoutExtension(filenameWithExt.Trim());


            csvFile = Resources.Load("CSV/" + filename) as TextAsset;


            // 一行ずつ読み込み処理する
            using (StringReader reader = new StringReader(csvFile.text))
            {

                while (reader.Peek() > -1)
                {

                    string line = reader.ReadLine();
                    var column = line.Split(',');


                    // English -> ??
                    AddIfNotExists(new TranslationKey(Languages.English, Languages.Japanese, column[0].ToLower()), column[1]);

                    AddIfNotExists(new TranslationKey(Languages.English, Languages.ChineseSimplified, column[0].ToLower()), column[2]);

                    AddIfNotExists(new TranslationKey(Languages.English, Languages.ChineseTraditional, column[0].ToLower()), column[3]);


                    //Japanese - > ??
                    AddIfNotExists(new TranslationKey(Languages.Japanese, Languages.English, column[1]), column[0]);

                    AddIfNotExists(new TranslationKey(Languages.Japanese, Languages.ChineseSimplified, column[1]), column[2]);

                    AddIfNotExists(new TranslationKey(Languages.Japanese, Languages.ChineseTraditional, column[1]), column[3]);


                    //ChineseSimplified -> ??
                    AddIfNotExists(new TranslationKey(Languages.ChineseSimplified, Languages.English, column[2]), column[0]);

                    AddIfNotExists(new TranslationKey(Languages.ChineseSimplified, Languages.Japanese, column[2]), column[1]);

                    AddIfNotExists(new TranslationKey(Languages.ChineseSimplified, Languages.ChineseTraditional, column[2]), column[3]);


                    //ChineseTraditional -> ??
                    AddIfNotExists(new TranslationKey(Languages.ChineseTraditional, Languages.English, column[3]), column[0]);

                    AddIfNotExists(new TranslationKey(Languages.ChineseTraditional, Languages.Japanese, column[3]), column[1]);

                    AddIfNotExists(new TranslationKey(Languages.ChineseTraditional, Languages.ChineseSimplified, column[3]), column[2]);

                    
                }
            }
            OnCSVDictionaryInjected();
        }

     

        /// <summary>
        /// 翻訳結果を返す
        /// </summary>
        /// <param name="resource"></param>元言語
        /// <param name="target"></param>ターゲット言語
        /// <param name="input"></param>翻訳内容
        /// <returns></returns>
        public string TranslateResults(Languages resource, Languages target, string input)
        {
            input = input.ToLower();//For English

            var key = new TranslationKey(resource, target, input);

            string value;

            languageDict.TryGetValue(key, out value);

            return value;

        }

        /// <summary>
        /// エラーを回避し、ディクショナリーに入れる
        /// </summary>
        /// <param name="key"></param>翻訳キー
        /// <param name="value"></param>翻訳結果
        private void AddIfNotExists(TranslationKey key, string value)
        {

            string result;
            if (languageDict.TryGetValue(key, out result) == false)
            {
                languageDict.Add(key, value);
            }

        }
    }//class
}//namespace
