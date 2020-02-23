using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCard : MonoBehaviour
{
    public Sprite[] ingredientsWithText;
    public Sprite[] ingredientsSymbols;
    public const float offsetX = 1f;
    public const float offsetY = 4f;
    public const float scaling = 0.4f;

    public bool isRando;
    public int ingredientCountPlayer = 0;
    public int ingredientCountAgent = 0;
    public int currentIngredient = 0;

    public RecipeManager rec_man;

    // for testing -- remove -- WHY DOESN'T CHANGE IMAGE TO INGREDIENT + CORRECT ONE??
    // private void OnMouseDown(){
    //     this.FlyOff(1); 
    // }
    
    private void Start()
    {
        //currentIngredient = Random.Range(0, ingredientsWithText.Length);
        //this.ChangeSprite(currentIngredient, ingredientsWithText[currentIngredient]);   
        if(isRando){
            currentIngredient = randomizeMe();
        }
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

    public void FlyOff(bool player, bool noOne=false) 
    {
        Vector3 initPos = this.transform.position;
        Vector3 newPos = new Vector3(0,0,0);
        

        const float rightbound = 6f;

        //calculate new position of newCard
        MainCard ingredientCard = null;

        if (player && !noOne) // player got it
        {
            newPos = new Vector3(rightbound - offsetX*ingredientCountPlayer, initPos.y - offsetY, initPos.z);
            ingredientCountPlayer += 1;
        }
        else if (!player && !noOne) //enemy got it
        {
            newPos = new Vector3(-1*rightbound + offsetX*ingredientCountAgent, initPos.y + offsetY, initPos.z);
            ingredientCountAgent += 1;
        }
        else{ // noOne
            currentIngredient = randomizeMe();
        }

        if (!noOne){
            //now, create a new maincard at newpos (the small ingredient) only if player != 0
            ingredientCard = Instantiate(this, newPos, Quaternion.identity) as MainCard;
            ingredientCard.ChangeSprite(currentIngredient, ingredientsSymbols[currentIngredient]);
            ingredientCard.isRando = false;
            ingredientCard.currentIngredient = currentIngredient;

            //finally, change scale
            ingredientCard.transform.localScale = new Vector3(scaling, scaling, 1);

            //randomize the main card again
            currentIngredient = randomizeMe();

            //finally, add it to appropriate player's inventory
            if(player){
                rec_man.playerIngredients.Add(ingredientCard);
            }
            else{
                rec_man.enemyIngredients.Add(ingredientCard);
            }
        }
    }

    
    int randomizeMe(){
        int random = Random.Range(0, ingredientsWithText.Length);
        this.ChangeSprite(random, ingredientsWithText[random]);
        return random;
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
