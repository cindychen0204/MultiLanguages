using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using GDataDB;
using GDataDB.Linq;

using UnityQuickSheet;

///
/// !!! Machine generated code !!!
///
[CustomEditor(typeof(Table1))]
public class Table1Editor : BaseGoogleEditor<Table1>
{	    
    public override bool Load()
    {        
        Table1 targetData = target as Table1;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<Table1Data>(targetData.WorksheetName) ?? db.CreateTable<Table1Data>(targetData.WorksheetName);
        
        List<Table1Data> myDataList = new List<Table1Data>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            Table1Data data = new Table1Data();
            
            data = Cloner.DeepCopy<Table1Data>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
}
