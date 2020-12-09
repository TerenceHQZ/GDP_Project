using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Player's money & happiness
    private static int playerMoney;
    private static int playerHappiness;
    private static int FoodBought;

    public int startingMoney = 300;
    public int startingHappiness = 70;

    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI happinessText;

    public static GameManager Instance;
    public GameObject LoseWindow;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {

        if (PlayerPrefs.GetInt("AccountExist") == 0)
        {
            PlayerPrefs.SetInt("AccountExist", 1);

            SetHappiness(startingHappiness);
            SetMoney(startingMoney);
            SetFoodBought(0);

            DayTimeManager.SetDay(1);
            DayTimeManager.SetHour(7);
            DayTimeManager.SetMinute(0);

            JobManager.SetJob(0);
            JobManager.SetTaskDone(0);

            PlayerPrefs.SetInt("OwnedFan", 0);
            PlayerPrefs.SetInt("OwnedPC", 0);
            PlayerPrefs.SetInt("OwnedTable", 0);
            PlayerPrefs.SetInt("OwnedChair", 0);
            PlayerPrefs.SetInt("OwnedBed", 0);

            PlayerPrefs.SetFloat("TaskCooldown", 0f);

            Tutorial.SetTutorialProgress(0);
        }
        else
        {
            SetHappiness(PlayerPrefs.GetInt("PlayerHappiness"));
            SetMoney(PlayerPrefs.GetInt("PlayerMoney"));
            SetFoodBought(PlayerPrefs.GetInt("FoodBought"));

            DayTimeManager.SetDay(PlayerPrefs.GetInt("Day", 1));
            DayTimeManager.SetHour(PlayerPrefs.GetInt("Hours", 7));
            DayTimeManager.SetMinute(PlayerPrefs.GetInt("Minutes", 0));

            JobManager.SetJob(PlayerPrefs.GetInt("PlayerJob"));
            JobManager.SetTaskDone(PlayerPrefs.GetInt("TasksDone"));
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

            SetHappiness(startingHappiness);
            SetMoney(startingMoney);
            SetFoodBought(0);

            LightingManager.SetLightingTime(7);

            PlayerPrefs.SetInt("OwnedFan", 0);
            PlayerPrefs.SetInt("OwnedPC", 0);
            PlayerPrefs.SetInt("OwnedTable", 0);
            PlayerPrefs.SetInt("OwnedChair", 0);
            PlayerPrefs.SetInt("OwnedBed", 0);

            JobManager.SetJob(0);
            JobManager.SetTaskDone(0);
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

        if (Input.GetKeyDown(KeyCode.T))
        {
            DayTimeManager.SetHour(DayTimeManager.GetHour() - 1);
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            DayTimeManager.SetHour(DayTimeManager.GetHour() + 1);
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
            playerHappiness = 0;
            PlayerPrefs.SetInt("AccountExist", 0);
            Instance.LoseWindow.SetActive(true);
        }
    }

    public static void SetHappiness(int amount)
    {
        playerHappiness = amount;

        if (playerHappiness > 100)
        {
            playerHappiness = 100;
        }

        PlayerPrefs.SetInt("PlayerHappiness", playerHappiness);

        Instance.moneyText.text = "$" + playerMoney;
        Instance.happinessText.text = playerHappiness + "/100";

        if (playerHappiness <= 0)
        {
            // show lose screen
            // end the game
            playerHappiness = 0;
            PlayerPrefs.SetInt("AccountExist", 0);
            Instance.LoseWindow.SetActive(true);
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

    public static void SetFoodBought(int amount)
    {
        FoodBought = amount;
        PlayerPrefs.SetInt("FoodBought", FoodBought);
    }

    public static int GetFoodBought()
    {
        return FoodBought;
    }
}