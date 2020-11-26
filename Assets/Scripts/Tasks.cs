using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tasks : MonoBehaviour
{
    public float itemsBought = 0f;

    private float time = 0.0f;
    public float interpolationPeriod = 0.1f;
    public float dailyMoneySpent = 0f;

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
            }
            else
            {

            }
            
            dailyMoneySpent = 0f; //reset the daily money spent every day
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
    /*void taskHappiness ()
    {
        if (taskDone)
        {
            taskHappiness += 15;
        }
    }*/

    

    /*void spendLess()
    {
        if (dailySpend < 20)
        {
            taskHappiness += 15;
        }
    }*/
}
