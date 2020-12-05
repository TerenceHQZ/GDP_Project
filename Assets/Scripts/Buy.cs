using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buy : MonoBehaviour
{
    public void buy(int price)
    {
        GameManager.SetMoney(GameManager.GetMoney() -price);
    }
    public void happiness(int amount)
    {
        GameManager.SetHappiness(GameManager.GetHappiness() + amount);
    }
}
