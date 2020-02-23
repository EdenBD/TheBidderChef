using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Confirm : MonoBehaviour
{
    public MainLogic ml;

    public void OnMouseDown()
    {
        Debug.Log("Confirm pressed");
        ml.switchPlayer();
    }
}
