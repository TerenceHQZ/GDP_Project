using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseUpgrades : MonoBehaviour
{
    public static GameObject bed;
    public static GameObject upgradedBed;
    public static GameObject table;
    public static GameObject upgradedTable;
    public static GameObject chair;
    public static GameObject upgradedChair;
    public static GameObject pc;
    public static GameObject fan;


    void Start()
    {
        bed = GameObject.Find("Bed");
        UpdateHouse();
    }

    void Update()
    {
        
    }

    public static void UpdateHouse()
    {
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
    }
}
