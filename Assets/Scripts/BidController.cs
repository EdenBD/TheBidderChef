using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System; 
public class BidController : MonoBehaviour
{
    // Start is called before the first frame update
	public int amt;
	public TextMeshProUGUI BidCtrl_text;

    public CoinManager player_coins;
    public CoinManager enemy_coins;

    void Start()
    {
    	amt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //BidControllerTxt = GameObject.FindWithTag("BidController");

        BidCtrl_text.text = amt.ToString();
    }

    public void changeAmt(int x, bool isPlayer){

        amt += x;
        amt = Math.Min(amt, Constants.coinStart); // no more than 10
        amt = Math.Max(amt, 0); // no less than 0
        
        if (isPlayer) {
            int change;
            if (enemy_coins.lastBid >  player_coins.lastBid) change = enemy_coins.lastBid - player_coins.lastBid + x; else change = x;
            player_coins.lastBid = amt;
            player_coins.changeAmt(-change);
        }
        else{
            int change;
            if (player_coins.lastBid > enemy_coins.lastBid) change = player_coins.lastBid - enemy_coins.lastBid + x; else change = x;
            enemy_coins.lastBid = amt;
            enemy_coins.changeAmt(-change);
        }
    }
}
