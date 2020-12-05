using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Player's money & happiness
    private static int playerMoney;
    private static int playerHappiness;

    public int startingMoney = 1000;
    public int startingHappiness = 70;

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

            SetMoney(startingMoney);
            SetHappiness(startingHappiness);

            JobManager.SetJob(0);
        }
        else
        {
            SetMoney(PlayerPrefs.GetInt("PlayerMoney"));
            SetHappiness(PlayerPrefs.GetInt("PlayerHappiness"));

            JobManager.SetJob(PlayerPrefs.GetInt("PlayerJob"));
        }

        moneyText.text = "$" + playerMoney;
        happinessText.text = playerHappiness + "/100";

        StartCoroutine(ReduceHappiness());
    }

    void Update()
    {
        /*
         Game testing purposes
         */
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerPrefs.SetInt("AccountExist", 1);

            SetMoney(startingMoney);
            SetHappiness(startingHappiness);

            JobManager.SetJob(0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if(GetMoney() > 0)
                SetMoney(GetMoney() - 1);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            SetMoney(GetMoney() + 1);
        }
    }

    IEnumerator ReduceHappiness()
    {
        yield return new WaitForSeconds(1.0f);

        if (GetMoney() > 0)
        {
            yield return StartCoroutine(ReduceHappiness());
        }

        SetHappiness(GetHappiness() - 1);

        if (GetHappiness() <= 0)
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
        playerMoney = amount;
        PlayerPrefs.SetInt("PlayerMoney", playerMoney);

        Instance.moneyText.text = "$" + playerMoney;
        Instance.happinessText.text = playerHappiness + "/100";

        if (playerHappiness <= 0)
        {
            // show lose screen
            // end the game
        }
    }

    public static void SetHappiness(int amount)
    {
        playerHappiness = amount;
        PlayerPrefs.SetInt("PlayerHappiness", playerHappiness);

        Instance.moneyText.text = "$" + playerMoney;
        Instance.happinessText.text = playerHappiness + "/100";

        if (playerHappiness <= 0)
        {
            // show lose screen
            // end the game
        }
    }

    public static int GetMoney()
    {
        return playerMoney;
    }

    public static int GetHappiness()
    {
        return playerHappiness;
    }
}
