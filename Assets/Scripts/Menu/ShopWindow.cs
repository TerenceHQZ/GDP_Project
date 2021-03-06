﻿using UnityEngine;

public class ShopWindow : MonoBehaviour
{
    public int bedCost = 300;
    public int chairCost = 200;
    public int tableCost = 200;
    public int pcCost = 3000;
    public int fanCost = 100;

    public void bed()
    {
        int playerMoney = GameManager.GetMoney();
        int ownedBed = PlayerPrefs.GetInt("OwnedBed", 0);

        if (playerMoney >= bedCost && ownedBed == 0)
        {
            GameManager.SetMoney(playerMoney - bedCost);
            PlayerPrefs.SetInt("OwnedBed", 1);
        }
        else if (playerMoney < bedCost)
        {
            // NOT ENOUGH MONEY
            Debug.Log("NO $ - BED");
        }
        else if (ownedBed == 1)
        {
            // PLAYER ALREADY PURCHASED BED
            Debug.Log("ALREADY OWNED");
        }
    }

    public void chair()
    {
        int playerMoney = GameManager.GetMoney();
        int ownedChair = PlayerPrefs.GetInt("OwnedChair", 0);

        if (playerMoney >= chairCost && ownedChair == 0)
        {
            GameManager.SetMoney(playerMoney - chairCost);
            PlayerPrefs.SetInt("OwnedChair", 1);
        }
        else if (playerMoney < chairCost)
        {
            // NOT ENOUGH MONEY
            Debug.Log("NO $ - CHAIR");
        }
        else if (ownedChair == 1)
        {
            // PLAYER ALREADY PURCHASED CHAIR
            Debug.Log("ALREADY OWNED");
        }
    }
    public void table()
    {
        int playerMoney = GameManager.GetMoney();
        int ownedTable = PlayerPrefs.GetInt("OwnedTable", 0);

        if (playerMoney >= tableCost && ownedTable == 0)
        {
            GameManager.SetMoney(playerMoney - tableCost);
            PlayerPrefs.SetInt("OwnedTable", 1);
        }
        else if (playerMoney < tableCost)
        {
            // NOT ENOUGH MONEY
            Debug.Log("NO $ - TABLE");
        }
        else if (ownedTable == 1)
        {
            // PLAYER ALREADY PURCHASED TABLE
            Debug.Log("ALREADY OWNED");
        }
    }

    public void pc()
    {
        int playerMoney = GameManager.GetMoney();
        int ownedPc = PlayerPrefs.GetInt("OwnedPC", 0);

        if (playerMoney >= pcCost && ownedPc == 0)
        {
            GameManager.SetMoney(playerMoney - pcCost);
            PlayerPrefs.SetInt("OwnedPC", 1);
        }
        else if (playerMoney < pcCost)
        {
            // NOT ENOUGH MONEY
            Debug.Log("NO $ - PC");
        }
        else if (ownedPc == 1)
        {
            // PLAYER ALREADY OWNED PC
            Debug.Log("ALREADY OWNED");
        }
    }

    public void fan()
    {
        int playerMoney = GameManager.GetMoney();
        int ownedFan = PlayerPrefs.GetInt("OwnedFan", 0);

        if (playerMoney >= fanCost && ownedFan == 0)
        {
            GameManager.SetMoney(playerMoney - fanCost);
            PlayerPrefs.SetInt("OwnedFan", 1);
        }
        else if (playerMoney < fanCost)
        {
            // NOT ENOUGH MONEY
            Debug.Log("NO $ - FAN");
        }
        else if (ownedFan == 1)
        {
            // PLAYER ALREADY OWNED FAN
            Debug.Log("ALREADY OWNED");
        }
    }
}
