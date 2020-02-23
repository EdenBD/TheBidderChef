using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeCard : MonoBehaviour
{
    // Start is called before the first frame update
    public RecipeCard myCard;
    public Recipe[] recipes;
    public int currentRecipe;
    public bool done;
    public bool init_done = false;
    [SerializeField] private GameObject Card_Back;

    void Start()
    {
        currentRecipe = Random.Range(0, recipes.Length);
        myCard.ChangeSprite(currentRecipe, recipes[currentRecipe].sprite);
        done = false;
        init_done = true;
    }

    public void OnMouseDown()
    {
        if(Card_Back.activeSelf)
        {
            Card_Back.SetActive(false);
        }
        else
        {
            Card_Back.SetActive(true);
        }
    }

    // to randomize chosen card and check comparisons 
    private int _id;
    public int id
    {
        get { return _id;}
    }

    public bool isPlayer
    {
        get { return isPlayer;}
        set {isPlayer = value;}
    }

    public void ChangeSprite(int id, Sprite image)
    {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image; // change sprite image 
    }
}
