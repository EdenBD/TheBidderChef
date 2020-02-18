using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCard : MonoBehaviour
{
    public MainCard originalCard;
    public Sprite[] ingredientsWithText;
    public Sprite[] ingredientsSymbols;
    public const float offsetX = 1f;
    public const float offsetY = 4f;
    public const float scaling = 0.4f;
    public int ingredientCountPlayer = 0;
    public int ingredientCountAgent = 0;
    public int currentIngredient = 0;


    // for testing -- remove -- WHY DOESN'T CHANGE IMAGE TO INGREDIENT + CORRECT ONE??
    private void OnMouseDown(){
        originalCard.FlyOff(true); 
    }
    
    private void Start()
    {
        currentIngredient = Random.Range(0, ingredientsWithText.Length - 1);
        originalCard.ChangeSprite(currentIngredient, ingredientsWithText[currentIngredient]);       
    }

    // to randomize chosen card and check comparisons 
    private int _id;
    public int id
    {
        get { return _id;}
    }

    public void ChangeSprite(int id, Sprite image)
    {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image; // change sprite image 
    }

    public void FlyOff(bool player)
    {
        // Change small ingredient card accroding to MainCard ingredient
        Vector3 startPos = originalCard.transform.position;
        startPos.x = 6; 
        // MainCard ingredientCard = Instantiate(originalCard) as MainCard;
        // ingredientCard.ChangeSprite(currentIngredient, ingredientsSymbols[currentIngredient]);

        // // Change MainCard ingredient
        

        if (player)
        {
            originalCard.transform.position = new Vector3(startPos.x - offsetX*ingredientCountPlayer, startPos.y - offsetY, startPos.z);
            originalCard.transform.localScale = new Vector3(scaling, scaling, 1);
            ingredientCountPlayer += 1;
        }
        else
        {
            originalCard.transform.position = new Vector3(-1*startPos.x + offsetX*ingredientCountAgent, startPos.y + offsetY, startPos.z);
            originalCard.transform.localScale = new Vector3(scaling, scaling, 1);
            ingredientCountAgent += 1;
        }

        originalCard.ChangeSprite(currentIngredient, ingredientsSymbols[currentIngredient]);
        int random = Random.Range(0, ingredientsWithText.Length - 1);
        MainCard ingredientCard = Instantiate(originalCard,  new Vector3(0, 0, 0), Quaternion.identity) as MainCard;
        ingredientCard.ChangeSprite(random, ingredientsSymbols[random]);

    }

    // IEnumerator Wait(float seconds)
    // {
    // yield return new WaitForSeconds(seconds);
    // }

    //     public void FlyOff(bool player)
    // {
    //     // Change small ingredient card accroding to MainCard ingredient
    //     Vector3 startPos = originalCard.transform.position;
    //     startPos.x = 6; 
    //     MainCard ingredientCard = Instantiate(originalCard) as MainCard;
    //     ingredientCard.ChangeSprite(currentIngredient, ingredientsSymbols[currentIngredient]);

    //     // Change MainCard ingredient
    //     currentIngredient = Random.Range(0, ingredientsWithText.Length - 1);
    //     originalCard.ChangeSprite(currentIngredient, ingredientsWithText[currentIngredient]);

    //     if (player)
    //     {
    //         ingredientCard.transform.position = new Vector3(startPos.x - offsetX*ingredientCountPlayer, startPos.y - offsetY, startPos.z);
    //         ingredientCard.transform.localScale = new Vector3(scaling, scaling, 1);
    //         ingredientCountPlayer += 1;
    //     }
    //     else
    //     {
    //         ingredientCard.transform.position = new Vector3(-1*startPos.x + offsetX*ingredientCountAgent, startPos.y + offsetY, startPos.z);
    //         ingredientCard.transform.localScale = new Vector3(scaling, scaling, 1);
    //         ingredientCountAgent += 1;
    //     }
    // }
 
}
