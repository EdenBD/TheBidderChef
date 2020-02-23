using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour
{
    // Start is called before the first frame update
    public string name;
    public Sprite sprite;
    public Dictionary<string, int> dict;

    public string[] ingrs;
    public int[]  num_need;

    public int bonus;

    void Start()
    {
        dict = new Dictionary<string, int>();
        for(int i = 0; i < ingrs.Length; i++){
            dict[ingrs[i]] = num_need[i];
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
