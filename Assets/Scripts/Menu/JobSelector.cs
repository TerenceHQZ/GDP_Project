using UnityEngine;

public class JobSelector : MonoBehaviour
{
    public GameObject WarehouseSprite;
    public GameObject DeliverySprite;
    public GameObject RetailSprite;
    public GameObject FoodBeverageSprite;
    public GameObject jobSelected;
    public GameObject alreadyJob;

    public void WarehouseJobSelect()
    {
        jobSelected.SetActive(false);
        alreadyJob.SetActive(false);

        if (JobManager.GetJob() == 0)
        {
            JobManager.SetJob(1);
            GameManager.SetHappiness(GameManager.GetHappiness() - JobManager.happinessLossBase);
            WarehouseSprite.SetActive(true);
            Debug.Log("Warehouse selected");
            jobSelected.SetActive(true);
        }
        else
        {
            // ALREADY HAVE A JOB
            Debug.Log("Already have a job");
            alreadyJob.SetActive(true);
        }
        Invoke("HideText", 2f);
    }

    public void DeliveryJobSelect()
    {
        jobSelected.SetActive(false);
        alreadyJob.SetActive(false);

        if (JobManager.GetJob() == 0)
        {
            JobManager.SetJob(2);
            GameManager.SetHappiness(GameManager.GetHappiness() - JobManager.happinessLossBase);
            DeliverySprite.SetActive(true);
            Debug.Log("Delivery selected");
            jobSelected.SetActive(true);
        }
        else
        {
            // ALREADY HAVE A JOB
            Debug.Log("Already have a job");
            alreadyJob.SetActive(true);
        }
        Invoke("HideText", 2f);
    }

    public void FoodBeverageJobSelect()
    {
        jobSelected.SetActive(false);
        alreadyJob.SetActive(false);

        if (JobManager.GetJob() == 0)
        {
            JobManager.SetJob(3);
            GameManager.SetHappiness(GameManager.GetHappiness() - JobManager.happinessLossBase);
            FoodBeverageSprite.SetActive(true);
            Debug.Log("FoodBeverage selected");
            jobSelected.SetActive(true);
        }
        else
        {
            // ALREADY HAVE A JOB
            Debug.Log("Already have a job");
            alreadyJob.SetActive(true);
        }
        Invoke("HideText", 2f);
    }

    public void RetailJobSelect()
    {
        jobSelected.SetActive(false);
        alreadyJob.SetActive(false);

        if (JobManager.GetJob() == 0)
        {
            JobManager.SetJob(4);
            GameManager.SetHappiness(GameManager.GetHappiness() - JobManager.happinessLossBase);
            RetailSprite.SetActive(true);
            Debug.Log("Retail selected");
            jobSelected.SetActive(true);
        }
        else
        {
            // ALREADY HAVE A JOB
            Debug.Log("Already have a job");
            alreadyJob.SetActive(true);
        }
        Invoke("HideText", 2f);
    }

    public void HideText()
    {
        jobSelected.SetActive(false);
        alreadyJob.SetActive(false);
    }
}
