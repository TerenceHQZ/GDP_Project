using UnityEngine;

public class School : MonoBehaviour
{
    public GameObject character;

    bool inSchool = false;

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

                    Debug.Log((buildingPos - characterPos).magnitude);

                    if ((buildingPos - characterPos).magnitude <= 3f)
                    {
                        GoToSchool();
                    }
                }
            }
        }
    }

    void GoToSchool()
    {
        inSchool = true;

        DayTimeManager.SetHour(16);
        DayTimeManager.SetMinute(0);
        //LightingManager.ChangeLightingTime(16f);
    }
}
