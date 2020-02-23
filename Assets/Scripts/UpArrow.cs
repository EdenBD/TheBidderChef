using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpArrow : MonoBehaviour
{
    // Start is called before the first frame update
    public BidController bc;

    private void OnMouseDown(){
        bool isPlayer = MainLogic.playerPlaying;

        // make sure player has enough coins
        int playingCoins;
        if (isPlayer) playingCoins = bc.player_coins.coins; else playingCoins = bc.enemy_coins.coins;
        if (playingCoins > 0)
        {
            bc.changeAmt(1, isPlayer);
        }
    }
}
