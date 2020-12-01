using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buy : MonoBehaviour
{
    public void buy(int price)
    {
        GameManager.SetMoney(-price);
    }
}
