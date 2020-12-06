using UnityEngine;
using UnityEngine.UI;

public class JobSelector : MonoBehaviour
{
    public void WarehouseJobSelect()
    {
        if(JobManager.GetJob() != 0)
            JobManager.SetJob(1);
        else
        {
            // ALREADY HAVE A JOB
        }
    }

    public void DeliveryJobSelect()
    {
        if (JobManager.GetJob() != 0)
            JobManager.SetJob(2);
        else
        {
            // ALREADY HAVE A JOB
        }
    }

    public void FoodBeverageJobSelect()
    {
        if (JobManager.GetJob() != 0)
            JobManager.SetJob(3);
        else
        {
            // ALREADY HAVE A JOB
        }
    }

    public void RetailJobSelect()
    {
        if (JobManager.GetJob() != 0)
            JobManager.SetJob(4);
        else
        {
            // ALREADY HAVE A JOB
        }
    }
}
