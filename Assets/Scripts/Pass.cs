using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pass : MonoBehaviour
{
    public MainLogic ml;
    public BidController bc;
    public MainCard mainCard;
    public bool onePassed = false;


    public void OnMouseDown()
    {
        bool isPlayer = MainLogic.playerPlaying;
        int otherLastBid;
        int myLastBid;

        if (isPlayer) 
        {
            otherLastBid = bc.enemy_coins.lastBid;
            myLastBid = bc.player_coins.lastBid;
        }
        else 
        {
            otherLastBid = bc.player_coins.lastBid;
            myLastBid = bc.enemy_coins.lastBid;
        }

        if (otherLastBid > 0) {
            // Whoever passed gets his bid back
            if (isPlayer) bc.player_coins.coins += bc.player_coins.lastBid; else bc.enemy_coins.coins += bc.enemy_coins.lastBid;

            bc.enemy_coins.lastBid = 0;
            bc.player_coins.lastBid = 0;
            bc.amt = 0;

            mainCard.FlyOff(!isPlayer);
            ml.switchPlayer();
        }

        else if (myLastBid == 0 && bc.amt == 0)
        {
            if (otherLastBid ==0 && onePassed){
                // change mainCard, indgredient doesn't go to anyone
                mainCard.FlyOff(isPlayer, true);
                onePassed = false;
            }
            else
            {
                onePassed = true;
            }
            
            ml.switchPlayer();
        }

    }
}
