using UnityEngine;

public class DeliveryJob : MonoBehaviour
{
    public float taskCoolDown = 96f;
    public static bool DeliveryTaskReady;
    private float timer;
    private int randomBuilding;

    public GameObject character;

    public GameObject[] DeliveryBuildings;

    private void Start()
    {
        DeliveryBuildings = GameObject.FindGameObjectsWithTag("DeliveryBuildings");

        randomBuilding = Random.Range(0, 3);
        Debug.Log(DeliveryBuildings[randomBuilding].name);

        timer = PlayerPrefs.GetFloat("TaskCooldown", 0f);

        if (timer > 0f)
        {
            Invoke("ResetCooldown", timer);
        }
        else
        {
            DeliveryTaskReady = true;
        }

        JobManager.SetJob(2);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && JobManager.GetJob() == 2 && DeliveryTaskReady)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == DeliveryBuildings[randomBuilding].name)
                {
                    Vector3 buildingPos = hit.transform.position;
                    Vector3 characterPos = character.transform.position;

                    Debug.Log((buildingPos - characterPos).magnitude);

                    if ((buildingPos - characterPos).magnitude <= 2.25f)
                    {
                        GameManager.SetHappiness(GameManager.GetHappiness() - JobManager.happinessLossPerTask);

                        JobManager.SetTaskDone(JobManager.GetTaskDone() + 1);

                        // HIDE PROMPTS UI ON THE WAREHOUSE BUILDING

                        Invoke("ResetCooldown", taskCoolDown);

                        DeliveryTaskReady = false;

                        timer = taskCoolDown;
                    }
                }
            }
        }

        if (!DeliveryTaskReady && timer >= 0f)
        {
            timer -= Time.deltaTime;
        }

        if (!DeliveryTaskReady && timer <= 0.5f)
        {
            timer = 0f;
            PlayerPrefs.SetFloat("TaskCooldown", 0f);
        }
    }

    private void ResetCooldown()
    {
        DeliveryTaskReady = true;

        Debug.Log("Delivery: Cooldown over");

        timer = 0f;
        PlayerPrefs.SetFloat("TaskCooldown", 0f);

        if (JobManager.GetJob() == 1)
        {
            // SHOW PROMPTS UI ON THE WAREHOUSE BUILDING
        }
    }
}
