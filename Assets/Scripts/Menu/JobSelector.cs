using UnityEngine;

public class JobSelector : MonoBehaviour
{
    public GameObject WarehouseSprite;
    public GameObject DeliverySprite;
    public GameObject RetailSprite;
    public GameObject FoodBeverageSprite;

    public void WarehouseJobSelect()
    {
        if(JobManager.GetJob() == 0)
        {
            JobManager.SetJob(1);
            WarehouseSprite.SetActive(true);
            Debug.Log("Warehouse selected");
        }
        else
        {
            // ALREADY HAVE A JOB
            Debug.Log("Already have a job");
        }
    }

    public void DeliveryJobSelect()
    {
        if (JobManager.GetJob() == 0)
        {
            JobManager.SetJob(2);
            DeliverySprite.SetActive(true);
            Debug.Log("Delivery selected");
        }
        else
        {
            // ALREADY HAVE A JOB
            Debug.Log("Already have a job");
        }
    }

    public void FoodBeverageJobSelect()
    {
        if (JobManager.GetJob() == 0)
        {
            JobManager.SetJob(3);
            FoodBeverageSprite.SetActive(true);
            Debug.Log("FoodBeverage selected");
        }
        else
        {
            // ALREADY HAVE A JOB
            Debug.Log("Already have a job");
        }
    }

    public void RetailJobSelect()
    {
        if (JobManager.GetJob() == 0)
        {
            JobManager.SetJob(4);
            RetailSprite.SetActive(true);
            Debug.Log("Retail selected");
        }
        else
        {
            // ALREADY HAVE A JOB
            Debug.Log("Already have a job");
        }
    }
}
