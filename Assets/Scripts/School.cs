using System.Collections;
using UnityEngine;

public class School : MonoBehaviour
{
    public GameObject character;
    public GameObject schoolFade;
    public static int loseHappinessAmount = 25;
    public static bool wentToSchool = false;

    void Update()
    {
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
                        else
                        {
                            Debug.Log("u r late for school");
                        }
                    }
                }
            }
        }
    }

    IEnumerator GoToSchool()
    {
        yield return new WaitForSeconds(1.2f);
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
