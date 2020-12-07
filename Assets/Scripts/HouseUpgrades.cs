using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseUpgrades : MonoBehaviour
{
    public GameObject bed;
    public GameObject upgradedBed;
    public GameObject table;
    public GameObject upgradedTable;
    public GameObject chair;
    public GameObject upgradedChair;
    public GameObject pc;
    public GameObject fan;

    void Start()
    {
        StartCoroutine(UpdateHouse());
    }

    IEnumerator UpdateHouse()
    {
        yield return new WaitForSeconds(1f);

        if (PlayerPrefs.GetInt("OwnedBed") == 1)
        {
            upgradedBed.SetActive(true);
            bed.SetActive(false);
        }
        else
        {
            upgradedBed.SetActive(false);
            bed.SetActive(true);
        }

        if (PlayerPrefs.GetInt("OwnedChair") == 1)
        {
            upgradedChair.SetActive(true);
            chair.SetActive(false);
        }
        else
        {
            upgradedChair.SetActive(false);
            chair.SetActive(true);
        }

        if (PlayerPrefs.GetInt("OwnedTable") == 1)
        {
            upgradedTable.SetActive(true);
            table.SetActive(false);
        }
        else
        {
            upgradedTable.SetActive(false);
            table.SetActive(true);
        }

        if (PlayerPrefs.GetInt("OwnedPC") == 1)
        {
            pc.SetActive(true);
        }
        else
        {
            pc.SetActive(false);
        }

        if (PlayerPrefs.GetInt("OwnedFan") == 1)
        {
            fan.SetActive(true);
        }
        else
        {
            fan.SetActive(false);
        }

        StartCoroutine(UpdateHouse());
    }
}
