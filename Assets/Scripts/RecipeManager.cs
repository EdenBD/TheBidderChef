using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<MainCard> playerIngredients;
    public List<MainCard> enemyIngredients;

    public RecipeCard[] playerRecipes;
    public RecipeCard[] enemyRecipes;

    void Start()
    {
        playerIngredients = new List<MainCard>();
        enemyIngredients = new List<MainCard>();
    }
    bool canFinish(Recipe rec, bool isPlayer){
        int dairyLeft = rec.dict["Dairy"];
        int fruitLeft = rec.dict["Fruit"];
        int grainLeft = rec.dict["Grain"];
        int meatLeft = rec.dict["Meat"];

        List<MainCard> cpylist;
        if(isPlayer){
            //can player finish?
            cpylist = playerIngredients;
        }
        else{
            cpylist = enemyIngredients;
        }
        foreach(MainCard mc in cpylist){
            switch(mc.currentIngredient){
                case 0:
                    dairyLeft--;
                    break;
                case 1:
                    fruitLeft--;
                    break;
                case 2:
                    grainLeft--;
                    break;
                case 3:
                    meatLeft--;
                    break;
            }
        }

        if(dairyLeft <=0 && fruitLeft <=0 && grainLeft <=0 && meatLeft <=0){
            return true;
        }else{
            return false;
        }
    }
    void placeCheckmark(RecipeCard rec_card){
        // print("ok");
        Vector3 pos = rec_card.transform.position;
        pos = new Vector3(pos.x - .5f, pos.y - .5f, pos.z);
        GameObject go = new GameObject();
        SpriteRenderer renderer = go.AddComponent<SpriteRenderer>();

        renderer.sprite =  Resources.Load("Sprites/checkmark", typeof(Sprite)) as Sprite;
        go.transform.localScale = new Vector3(.1f, .1f, 1);
        go.transform.position = pos;
    }
    // Update is called once per frame
    void Update()
    {
        //has player/enemy finished a recipe?
        bool isPlayer = MainLogic.playerPlaying;
        // Debug.Log("Receipt isPlayer=" + isPlayer);
        RecipeCard[] currentlyPlayingReceipts;
        if (isPlayer)  currentlyPlayingReceipts = playerRecipes; else currentlyPlayingReceipts = enemyRecipes; 

        foreach(RecipeCard rec_card in currentlyPlayingReceipts){
            if(!rec_card.done && rec_card.init_done){
                //can we finish this recipe?
                if(canFinish(rec_card.recipes[rec_card.currentRecipe],isPlayer)){
                    //mark as done
                    rec_card.done = true;
                    

                    //remove relevant ingredients
                    // remove_ingredients(rec_card, isPlayer);
                    
                    //place a checkmark!
                    placeCheckmark(rec_card);
                }


            }
        }

    }

}
