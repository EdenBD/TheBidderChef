using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLogic : MonoBehaviour
{

    // Keeping state
    public MainCard mainCard;
    public RecipeManager recipeManager;
    public BidController bc;
    
    // Who's playing
    public static bool playerPlaying;  
    [SerializeField] private GameObject playing_side_enemy;
    [SerializeField] private GameObject playing_side_player;

    void Start()
    {
       // randomly choose starting player, true for player, false for enemy.
        playerPlaying = (Random.value > 0.5f);
        switchPlayer();

    }

    // Update is called once per frame
    void Update()
    {
        
        // mainCard.FlyOff(playerPlaying);//detect whether player has enough resources to finish a recipe
    }

    public void switchPlayer()
    {   
        playerPlaying = !playerPlaying;
        playing_side_player.SetActive(playerPlaying);
        playing_side_enemy.SetActive(!playerPlaying);
    }
}
