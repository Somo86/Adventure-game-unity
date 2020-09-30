using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// *****************
// Load data JSON from Resources 
// *****************
public class LoadResource
{
    public static string GetData() {
        TextAsset jsonString = Resources.Load<TextAsset>("insults_uoc");
        return jsonString.text;
    }
}
