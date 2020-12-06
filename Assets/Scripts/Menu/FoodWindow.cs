using UnityEngine;

public class FoodWindow : MonoBehaviour
{
    public int HawkerCost = 5;
    public int FastFoodCost = 12;
    public int RestaurantCost = 25;

    public void Hawker()
    {
        if(GameManager.GetMoney() >= HawkerCost)
        {
            GameManager.SetMoney(GameManager.GetMoney() - HawkerCost);
        }
        else
        {
            // NOT ENOUGH MONEY
        }
    }

    public void FastFood()
    {
        if(GameManager.GetMoney() >= FastFoodCost)
        {
            GameManager.SetMoney(GameManager.GetMoney() - FastFoodCost);
            GameManager.SetHappiness(GameManager.GetHappiness() + 5);
        }
        else
        {
            // NOT ENOUGH MONEY
        }
    }

    public void Restaurant()
    {
        if (GameManager.GetMoney() >= RestaurantCost)
        {
            GameManager.SetMoney(GameManager.GetMoney() - RestaurantCost);
            GameManager.SetHappiness(GameManager.GetHappiness() + 10);
        }
        else
        {
            // NOT ENOUGH MONEY
        }
    }
}