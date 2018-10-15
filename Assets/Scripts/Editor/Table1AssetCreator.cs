using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/Table1")]
    public static void CreateTable1AssetFile()
    {
        Table1 asset = CustomAssetUtility.CreateAsset<Table1>();
        asset.SheetName = "Holo_MultiLanguages";
        asset.WorksheetName = "Table1";
        EditorUtility.SetDirty(asset);        
    }
    
}