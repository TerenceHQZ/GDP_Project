using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreeetLight : MonoBehaviour
{
    public GameObject light;

    void Update()
    {
        
    }

    void TurnOn()
    {
        if (DayTimeManager.GetHour() >= 18)
            light.SetActive(true);

        if (DayTimeManager.GetHour() <= 18)
            light.SetActive(false);
    }
}
