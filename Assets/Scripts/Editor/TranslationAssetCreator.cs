using UnityEditor;
using MultiLanguageTK;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/Translation")]
    public static void CreateTranslationAssetFile()
    {
        Translation asset = CustomAssetUtility.CreateAsset<Translation>();
        asset.SheetName = "Holo_MultiLanguages";
        asset.WorksheetName = "Translation";
        EditorUtility.SetDirty(asset);        
    }
    
}