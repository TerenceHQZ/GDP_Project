using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseConditions : MonoBehaviour
{
    void Update()
    {
        Lose();
    }

    void Lose()
    {
        // get playermoney and happiness variable from other script 

        if(playerMoney <= 0 && playerHappiness <= 0)
        {
            // show lose screen
            // end the game
        }
    }
}
