using UnityEngine;

public class WarehouseJob : MonoBehaviour
{
    public float taskCoolDown = 192f;
    public int taskMoney = 25;
    public static bool WarehouseTaskReady;
    private float timer;

    public GameObject character;

    private void Start()
    {
        timer = PlayerPrefs.GetFloat("TaskCooldown", 0f);

        if(timer >= 0f)
        {
            Invoke("ResetCooldown", 0f);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "Warehouse")
                {
                    Vector3 buildingPos = hit.transform.position;
                    Vector3 characterPos = character.transform.position;

                    if ((buildingPos - characterPos).magnitude <= 1.5f)
                    {
                        if (JobManager.GetJob() == 1 && WarehouseTaskReady)
                        {
                            GameObject hitGameObject = hit.collider.gameObject;

                            GameManager.SetHappiness(GameManager.GetHappiness() - JobManager.happinessLossPerTask);

                            JobManager.tasksDone++;

                            Invoke("ResetCooldown", taskCoolDown);

                            WarehouseTaskReady = false;
                        }
                    }
                }
            }
        }
    }

    private void ResetCooldown()
    {
        WarehouseTaskReady = true;
    }

    /*
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
    */
}
