using UnityEngine;

public class JobSelector : MonoBehaviour
{
    public void WarehouseJobSelect()
    {
        JobManager.SetJob(1);
    }

    public void DeliveryJobSelect()
    {
        JobManager.SetJob(2);
    }

    public void FoodBeverageJobSelect()
    {
        JobManager.SetJob(3);
    }

    public void RetailJobSelect()
    {
        JobManager.SetJob(4);
    }
}
