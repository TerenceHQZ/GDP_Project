using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Player's money & happiness
    private static int playerMoney;
    private static int playerHappiness;

    void Start()
    {

        if (PlayerPrefs.GetInt("AccountExist") == 0)
        {
            PlayerPrefs.SetInt("AccountExist", 1);
        
            playerMoney = 0;
            playerHappiness = 70;

            PlayerPrefs.SetInt("PlayerMoney", playerMoney);
            PlayerPrefs.SetInt("PlayerHappiness", playerHappiness);
        }
        else
        {
            playerMoney = PlayerPrefs.GetInt("PlayerMoney");
            playerHappiness = PlayerPrefs.GetInt("PlayerHappiness");
        }
    }

    public static void SetMoney(int amount)
    {
        playerMoney += amount;
        PlayerPrefs.SetInt("PlayerMoney", playerMoney);

        if (playerMoney <= 0 && playerHappiness <= 0)
        {
            // show lose screen
            // end the game
        }
    }

    public static void SetHappiness(int amount)
    {
        playerHappiness += amount;
        PlayerPrefs.SetInt("PlayerHappiness", playerHappiness);

        if (playerMoney <= 0 && playerHappiness <= 0)
        {
            // show lose screen
            // end the game
        }
    }

    public static int GetPlayerMoney()
    {
        return playerMoney;
    }

    public static int GetPlayerHappiness()
    {
        return playerHappiness;
    }
}
