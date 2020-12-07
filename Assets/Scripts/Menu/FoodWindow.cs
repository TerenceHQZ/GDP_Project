using UnityEngine;

public class FoodWindow : MonoBehaviour
{
    public int HawkerCost = 20;
    public int FastFoodCost = 50;
    public int RestaurantCost = 100;

    public void Hawker()
    {
        if(GameManager.GetMoney() >= HawkerCost)
        {
            GameManager.SetMoney(GameManager.GetMoney() - HawkerCost);
            Tasks.dailyMoneySpent += HawkerCost;
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
            Tasks.dailyMoneySpent += FastFoodCost;
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
            Tasks.dailyMoneySpent += RestaurantCost;
        }
        else
        {
            // NOT ENOUGH MONEY
        }
    }
}