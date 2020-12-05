using UnityEngine;

public class FoodAndBeveragesJob : MonoBehaviour
{
    public float taskCoolDown = 192f;
    public static bool FoodBeverageTaskReady;
    private float timer;

    public GameObject character;

    private void Start()
    {
        timer = PlayerPrefs.GetFloat("TaskCooldown", 0f);

        if(timer > 0f)
        {
            Invoke("ResetCooldown", timer);
        }
        else
        {
            FoodBeverageTaskReady = true;
        }

        JobManager.SetJob(3);
    }

    private void Update()
    {

        Debug.Log(JobManager.GetJob());

        if (Input.GetMouseButtonDown(0) && JobManager.GetJob() == 3 && FoodBeverageTaskReady)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "WcDonalds")
                {
                    Vector3 buildingPos = hit.transform.position;
                    Vector3 characterPos = character.transform.position;

                    Debug.Log((buildingPos - characterPos).magnitude);

                    if ((buildingPos - characterPos).magnitude <= 2.25f)
                    {
                        //GameObject hitGameObject = hit.collider.gameObject;

                        GameManager.SetHappiness(GameManager.GetHappiness() - JobManager.happinessLossPerTask);

                        JobManager.SetTaskDone(JobManager.GetTaskDone() + 1);

                        // HIDE PROMPTS UI ON THE WAREHOUSE BUILDING

                        Invoke("ResetCooldown", taskCoolDown);

                        FoodBeverageTaskReady = false;

                        timer = taskCoolDown;
                    }
                }
            }
        }

        if (!FoodBeverageTaskReady && timer >= 0f)
        {
            timer -= Time.deltaTime;
        }

        if (!FoodBeverageTaskReady && timer <= 0.5f)
        {
            timer = 0f;
            PlayerPrefs.SetFloat("TaskCooldown", 0f);
        }
    }

    private void ResetCooldown()
    {
        FoodBeverageTaskReady = true;

        timer = 0f;
        PlayerPrefs.SetFloat("TaskCooldown", 0f);

        Debug.Log("Warehouse: Cooldown over");

        if (JobManager.GetJob() == 3)
        {
            // SHOW PROMPTS UI ON THE WAREHOUSE BUILDING
        }
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

