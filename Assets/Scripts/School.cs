using System.Collections;
using UnityEngine;
using TMPro;

public class School : MonoBehaviour
{
    public GameObject character;
    public GameObject schoolFade;
    public GameObject floatingSprite;
    public TextMeshProUGUI UIPrompt;
    public static int loseHappinessAmount = 20;
    public static bool wentToSchool = false;

    void Update()
    {
        if (!wentToSchool && DayTimeManager.GetHour() <= 12)
        {
            floatingSprite.SetActive(true);

            floatingSprite.transform.position = new Vector3(floatingSprite.transform.position.x,
            floatingSprite.transform.position.y + (Mathf.Sin(Time.time) * 0.001f),
            floatingSprite.transform.position.z);

            floatingSprite.transform.Rotate(0, 0.25f, 0);
        }
        else
        {
            floatingSprite.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "School")
                {
                    Vector3 buildingPos = hit.transform.position;
                    Vector3 characterPos = character.transform.position;

                    if ((buildingPos - characterPos).magnitude <= 3f)
                    {
                        if ((DayTimeManager.GetHour() <= 8 && DayTimeManager.GetMinute() <= 59) && !wentToSchool)
                        {
                            UIPrompt.text = "John went to school at " + DayTimeManager.GetHour().ToString("D2")
                                + ":" + DayTimeManager.GetMinute().ToString("D2") + ".";

                            UIPrompt.gameObject.SetActive(true);

                            StartCoroutine(SchoolFade());
                            StartCoroutine(GoToSchool());
                            
                        }
                        else if ((DayTimeManager.GetHour() >= 9 && DayTimeManager.GetHour() <= 12) && !wentToSchool)
                        {
                            UIPrompt.text = "John went to school at" + DayTimeManager.GetHour()
                                + ":" + DayTimeManager.GetMinute()
                                + ".\nHe was late... (-10 happiness).";

                            UIPrompt.gameObject.SetActive(true);

                            GameManager.SetHappiness(GameManager.GetHappiness() - 10);

                            floatingSprite.SetActive(false);
                            StartCoroutine(SchoolFade());
                            StartCoroutine(GoToSchool());
                        }
                    }
                }
            }
        }
    }

    IEnumerator GoToSchool()
    {
        yield return new WaitForSeconds(1f);
        wentToSchool = true;
        DayTimeManager.SetHour(15);
        DayTimeManager.SetMinute(0);
        LightingManager.SetLightingTime(15);
    }

    IEnumerator SchoolFade()
    {
        schoolFade.SetActive(true);
        yield return new WaitForSeconds(3f);
        schoolFade.SetActive(false);
        UIPrompt.gameObject.SetActive(false);
    }
}
