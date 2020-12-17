using TMPro;
using UnityEngine;

public class FoodWindow : MonoBehaviour
{
    public int HawkerCost = 20;
    public int FastFoodCost = 50;
    public int RestaurantCost = 100;

    public TextMeshProUGUI UIPrompt;

    public void Hawker()
    {
        if(GameManager.GetMoney() >= HawkerCost)
        {
            GameManager.SetMoney(GameManager.GetMoney() - HawkerCost);
            GameManager.SetFoodBought(GameManager.GetFoodBought() + 1);
            Tasks.dailyMoneySpent += HawkerCost;

            UIPrompt.text = "John bought hawker food for $20.";
        }
        else
        {
            UIPrompt.text = "John does not have enough money.";
        }

        UIPrompt.gameObject.SetActive(true);

        Invoke("HideUIPrompt", 3f);
    }

    public void FastFood()
    {
        if(GameManager.GetMoney() >= FastFoodCost)
        {
            GameManager.SetMoney(GameManager.GetMoney() - FastFoodCost);
            GameManager.SetHappiness(GameManager.GetHappiness() + 5);
            GameManager.SetFoodBought(GameManager.GetFoodBought() + 1);
            Tasks.dailyMoneySpent += FastFoodCost;

            UIPrompt.text = "John bought fast food for $50. (Happiness +5)";
        }
        else
        {
            UIPrompt.text = "John does not have enough money.";
        }

        UIPrompt.gameObject.SetActive(true);

        Invoke("HideUIPrompt", 3f);
    }

    public void Restaurant()
    {
        if (GameManager.GetMoney() >= RestaurantCost)
        {
            GameManager.SetMoney(GameManager.GetMoney() - RestaurantCost);
            GameManager.SetHappiness(GameManager.GetHappiness() + 12);
<<<<<<< HEAD
            GameManager.SetFoodBought(GameManager.GetFoodBought() + 1);
=======
>>>>>>> parent of b8bad14... -
            Tasks.dailyMoneySpent += RestaurantCost;

            UIPrompt.text = "John bought fast food for $100. (Happiness +12)";
        }
        else
        {
            UIPrompt.text = "John does not have enough money.";
        }

        UIPrompt.gameObject.SetActive(true);

        Invoke("HideUIPrompt", 3f);
    }

    void HideUIPrompt()
    {
        UIPrompt.gameObject.SetActive(false);
    }
}