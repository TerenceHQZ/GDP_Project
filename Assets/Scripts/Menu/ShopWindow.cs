using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopWindow : MonoBehaviour
{
    public int bedCost = 300;
    public int chairCost = 200;
    public int tableCost = 200;
    public int pcCost = 3000;
    public int fanCost = 100;

    public void bed()
    {
        if (GameManager.GetMoney() >= bedCost)
        {
            GameManager.SetMoney(GameManager.GetMoney() - bedCost);
        }
        else
        {
            // NOT ENOUGH MONEY
        }
    }

    public void chair()
    {
        if (GameManager.GetMoney() >= chairCost)
        {
            GameManager.SetMoney(GameManager.GetMoney() - chairCost);
        }
        else
        {
            // NOT ENOUGH MONEY
        }
    }
    public void table()
    {
        if (GameManager.GetMoney() >= tableCost)
        {
            GameManager.SetMoney(GameManager.GetMoney() - tableCost);
        }
        else
        {
            // NOT ENOUGH MONEY
        }
    }

    public void pc()
    {
        if (GameManager.GetMoney() >= pcCost)
        {
            GameManager.SetMoney(GameManager.GetMoney() - pcCost);
        }
        else
        {
            // NOT ENOUGH MONEY
        }
    }

    public void fan()
    {
        if (GameManager.GetMoney() >= fanCost)
        {
            GameManager.SetMoney(GameManager.GetMoney() - fanCost);
        }
        else
        {
            // NOT ENOUGH MONEY
        }
    }
}
