using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
///
public class TranslateExcelAssetPostprocessor : AssetPostprocessor 
{
    private static readonly string filePath = "Assets/MultiLanguagePlatform/Resources/Excel/TranslationExcel.xlsx";
    private static readonly string assetFilePath = @"Assets\MultiLanguagePlatform\Resources\Excel/TranslateExcel.asset";
    private static readonly string sheetName = "TranslateExcel";
    
    static void OnPostprocessAllAssets (string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
    {
        foreach (string asset in importedAssets) 
        {
            if (!filePath.Equals (asset))
                continue;
                
            TranslateExcel data = (TranslateExcel)AssetDatabase.LoadAssetAtPath (assetFilePath, typeof(TranslateExcel));
            if (data == null) {
                data = ScriptableObject.CreateInstance<TranslateExcel> ();
                data.SheetName = filePath;
                data.WorksheetName = sheetName;
                AssetDatabase.CreateAsset ((ScriptableObject)data, assetFilePath);
                //data.hideFlags = HideFlags.NotEditable;
            }
            
            //data.dataArray = new ExcelQuery(filePath, sheetName).Deserialize<TranslateExcelData>().ToArray();		

            //ScriptableObject obj = AssetDatabase.LoadAssetAtPath (assetFilePath, typeof(ScriptableObject)) as ScriptableObject;
            //EditorUtility.SetDirty (obj);

            ExcelQuery query = new ExcelQuery(filePath, sheetName);
            if (query != null && query.IsValid())
            {
                data.dataArray = query.Deserialize<TranslateExcelData>().ToArray();
                ScriptableObject obj = AssetDatabase.LoadAssetAtPath (assetFilePath, typeof(ScriptableObject)) as ScriptableObject;
                EditorUtility.SetDirty (obj);
            }
        }
    }
}
