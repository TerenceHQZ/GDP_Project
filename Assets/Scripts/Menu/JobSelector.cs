using UnityEngine;
using UnityEngine.UI;

public class JobSelector : MonoBehaviour
{
    public void WarehouseJobSelect()
    {
        if(JobManager.GetJob() != 0)
        {
            JobManager.SetJob(1);
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
        if (JobManager.GetJob() != 0)
        {
            JobManager.SetJob(2);
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
        if (JobManager.GetJob() != 0)
        {
            JobManager.SetJob(3);
            Debug.Log("Delivery selected");
        }
        else
        {
            // ALREADY HAVE A JOB
            Debug.Log("Already have a job");
        }
    }

    public void RetailJobSelect()
    {
        if (JobManager.GetJob() != 0)
        {
            JobManager.SetJob(4);
            Debug.Log("Delivery selected");
        }
        else
        {
            // ALREADY HAVE A JOB
            Debug.Log("Already have a job");
        }
    }
}
