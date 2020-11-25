using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Player's money & happiness
    private static int playerMoney;
    private static int playerHappiness;

    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI happinessText;

    public static GameManager Instance;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {

        if (PlayerPrefs.GetInt("AccountExist") == 0)
        {
            PlayerPrefs.SetInt("AccountExist", 1);
        
            playerMoney = 1000;
            playerHappiness = 70;

            PlayerPrefs.SetInt("PlayerMoney", playerMoney);
            PlayerPrefs.SetInt("PlayerHappiness", playerHappiness);
        }
        else
        {
            playerMoney = PlayerPrefs.GetInt("PlayerMoney");
            playerHappiness = PlayerPrefs.GetInt("PlayerHappiness");
        }

        moneyText.text = "$" + playerMoney;
        happinessText.text = playerHappiness + "/100";

        if (GetPlayerMoney() <= 0)
        {
            StartCoroutine(ReduceHappiness());
        }
    }

    IEnumerator ReduceHappiness()
    {
        yield return new WaitForSeconds(1.0f);

        SetHappiness(-1);

        Debug.Log(GetPlayerHappiness());

        if (GetPlayerHappiness() <= 0)
        {
            PlayerPrefs.SetInt("AccountExist", 0);
            Debug.Log("Lose");
            yield return null;
        }
        else
        {
            yield return StartCoroutine(ReduceHappiness());
        }
    }

    public static void SetMoney(int amount)
    {
        playerMoney += amount;
        PlayerPrefs.SetInt("PlayerMoney", playerMoney);

        Instance.moneyText.text = "$" + playerMoney;
        Instance.happinessText.text = playerHappiness + "/100";

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

        Instance.moneyText.text = "$" + playerMoney;
        Instance.happinessText.text = playerHappiness + "/100";

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
