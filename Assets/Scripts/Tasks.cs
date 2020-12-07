using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tasks : MonoBehaviour
{
    public static int dailyMoneySpent;
    public GameObject[] CheckedBox;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(attendSchool());
    }

    IEnumerator attendSchool()
    {
        yield return new WaitForSeconds(1f);
        if (School.wentToSchool)
        {
            CheckedBox[2].SetActive(true);
        }
        else
        {
            CheckedBox[2].SetActive(false);
        }

        if (JobManager.GetTaskDone() > 0)
        {
            CheckedBox[0].SetActive(true);
        }
        else
        {
            CheckedBox[0].SetActive(false);
        }

        if (dailyMoneySpent <= 100)
        {
            CheckedBox[1].SetActive(true);
        }
        else
        {
            CheckedBox[1].SetActive(false);
        }
        StartCoroutine(attendSchool());
    }
}
