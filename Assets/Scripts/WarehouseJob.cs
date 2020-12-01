using UnityEngine;

public class WarehouseJob : MonoBehaviour
{
    public float taskCoolDown = 30f;
    public static bool WarehouseTaskReady;

    void OnCollisionEnter(Collision collision)
    {
        if(JobManager.playerJob == 1)
        {
            if (WarehouseTaskReady)
            {
                Debug.Log("Task completed");
                GameManager.SetMoney(100);
                WarehouseTaskReady = false;
                Invoke("ResetCooldown", taskCoolDown);
            }
            else
            {
                Debug.Log("There is no task yet!");
            }
        }
        else
        {
            Debug.Log("You do not have the warehouse job!");
        }
    }

    private void ResetCooldown()
    {
        Debug.Log("Warehouse task available");
        WarehouseTaskReady = true;
    }
}
