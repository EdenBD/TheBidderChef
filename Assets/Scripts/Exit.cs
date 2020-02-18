using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class Exit : MonoBehaviour
{
    public void QuitGame() 
    {
        if(UnityEditor.EditorApplication.isPlaying){
            // when running within the editor
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit ();
            
        }
    }
}
