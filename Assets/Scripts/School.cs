using System.Collections;
using UnityEngine;

public class School : MonoBehaviour
{
    public GameObject character;
    public GameObject schoolFade;
    public GameObject floatingSprite;
    public static int loseHappinessAmount = 20;
    public static bool wentToSchool = false;

    void Update()
    {
        if (!wentToSchool)
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
                            
                            StartCoroutine(SchoolFade());
                            StartCoroutine(GoToSchool());
                        }
                        else if ((DayTimeManager.GetHour() >= 9 && DayTimeManager.GetHour() <= 12) && !wentToSchool)
                        {
                            Debug.Log("u r late for school");

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
    }
}
