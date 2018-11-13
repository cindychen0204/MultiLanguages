using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using GDataDB;
using GDataDB.Linq;
using MultiLanguageTK;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
///
[CustomEditor(typeof(Translation))]
public class TranslationEditor : BaseGoogleEditor<Translation>
{	    
    public override bool Load()
    {        
        Translation targetData = target as Translation;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<TranslationData>(targetData.WorksheetName) ?? db.CreateTable<TranslationData>(targetData.WorksheetName);
        
        List<TranslationData> myDataList = new List<TranslationData>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            TranslationData data = new TranslationData();
            
            data = Cloner.DeepCopy<TranslationData>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
}
