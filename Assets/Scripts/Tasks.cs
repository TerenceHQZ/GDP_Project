using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tasks : MonoBehaviour
{
    public float itemsBought = 0f;

    private float time = 0.0f;
    public float interpolationPeriod = 0.1f;
    public float dailyMoneySpent = 0f;
    int jobsCompleted = 0;
    public static Tasks Instance;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        Debug.Log(time);

        if (time >= interpolationPeriod)
        {
            time = 0.0f;

            if(dailyMoneySpent <= 20f)
            {
                //savingComplete();
                Debug.Log("You have saved less than $20 today.");
            }
            else
            {
                Debug.Log("You have spent more than $20 in a day. Try to budget out your spenditure in a day.");
            }
            
            dailyMoneySpent = 0f; //reset the daily money spent every day
        }
    }

     void jobTaskComplete()
    {
        if (jobsCompleted == 3)
        {
            Debug.Log("Great Job on completing 3 jobs. Continue to earn more money!");
        }
        else
        {
            Debug.Log("Completed" + jobsCompleted + "jobs");
        }
    }

    void moneySpent()
    {
        dailyMoneySpent = 0f;
    }

    
    void buyShop(int price)
    {
        int x = price;
        dailyMoneySpent += price;
    }
}
