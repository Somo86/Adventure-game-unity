using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//******************************
// Keeps data through all scenes
// *****************************

public static class CrossData
{
    private static string winner;

    public static string Winner 
    {
        get 
        {
            return winner;
        }
        set 
        {
            winner = value;
        }
    }
}
