using System.Collections;
using TMPro;
using UnityEngine;

public class DayTimeManager : MonoBehaviour
{
    public static int day;
    public static int hours;
    public static int minutes;

    public int startingDay = 1;
    public int startingHour = 7;
    public int startingMinute = 0;

    public static int taskBaseMoney = 25;

    public TextMeshProUGUI dayTimeText;

    public static DayTimeManager Instance;

    public GameObject[] streetLights;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("AccountExist") == 0)
        {
            SetDay(startingDay);
            SetHour(startingHour);
            SetMinute(startingMinute);
        }
        else
        {
            SetDay(PlayerPrefs.GetInt("Day"));
            SetHour(PlayerPrefs.GetInt("Hours"));
            SetMinute(PlayerPrefs.GetInt("Minutes"));
        }
        
        SetHour(17);
        SetMinute(55);

        Instance.dayTimeText.text = "Day: " + GetDay() + " | " + GetHour().ToString("D2") + ":" + GetMinute().ToString("D2");

        StartCoroutine(AddMinutes());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerPrefs.SetInt("AccountExist", 1);

            SetDay(startingDay);
            SetHour(startingHour);
            SetMinute(startingMinute);
        }

        if (hours >= 18)
        {
            for (int i = 0; i < streetLights.Length; i++)
            {
                streetLights[i].SetActive(true);
            }
        }

        else if (hours < 18)
        {
            for (int i = 0; i < streetLights.Length; i++)
            {
                streetLights[i].SetActive(false);
            }
        }
    }

    public void OnDestroy()
    {
        PlayerPrefs.SetInt("Day", day);
        PlayerPrefs.SetInt("Hours", hours);
        PlayerPrefs.SetInt("Minutes", minutes);
    }

    IEnumerator AddMinutes()
    {
        yield return new WaitForSeconds(1f);

        SetMinute(GetMinute() + 1);

        yield return StartCoroutine(AddMinutes());
    }

    public static void SetDay(int setDay)
    {
        day = setDay;
        PlayerPrefs.SetInt("Day", day);
        Instance.dayTimeText.text = "Day: " + GetDay() + " | " + GetHour().ToString("D2") + ":" + GetMinute().ToString("D2");
    }

    public static int GetDay()
    {
        return day;
    }

    public static void SetHour(int cHours)
    {
        hours = cHours;

        if (hours >= 23)
        {
            SetHour(7);
            SetDay(GetDay() + 1);

            GameManager.SetMoney(GameManager.GetMoney() + (JobManager.tasksDone * taskBaseMoney));
            GameManager.SetHappiness(GameManager.GetHappiness() + JobManager.happinessLossBase);

            if (!School.wentToSchool)
            {
                GameManager.SetHappiness(GameManager.GetHappiness() - School.loseHappinessAmount);
            }
            School.wentToSchool = false;
        }
        
        PlayerPrefs.SetInt("Hours", hours);
        Instance.dayTimeText.text = "Day: " + GetDay() + " | " + GetHour().ToString("D2") + ":" + GetMinute().ToString("D2");
    }

    public static void SetMinute(int cMinutes)
    {
        minutes = cMinutes;

        if (minutes >= 60f)
        {
            SetMinute(0);
            SetHour(GetHour() + 1);
        }

        PlayerPrefs.SetInt("Minutes", minutes);
        Instance.dayTimeText.text = "Day: " + GetDay() + " | " + GetHour().ToString("D2") + ":" + GetMinute().ToString("D2");

        // Debug.Log("Day:" + day + " | " + hours + ":" + minutes);
    }

    public static int GetHour()
    {
        return hours;
    }

    public static int GetMinute()
    {
        return minutes;
    }

    
}