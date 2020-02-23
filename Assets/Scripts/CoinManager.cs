using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System; 
public class CoinManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int coins;
    public int lastBid = 0;
    public TextMeshProUGUI CoinDisplay_text;
    void Start()
    {
        coins = Constants.coinStart;
    }

    // Update is called once per frame
    void Update()
    {
        CoinDisplay_text.text = coins.ToString();
    }

    public void changeAmt(int x){
        coins += x;
        // coins = Math.Min(coins, Constants.coinStart); // in case you saved extra, can have more than initial count
        coins = Math.Max(coins, 0);
    }
}
