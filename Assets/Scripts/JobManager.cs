using UnityEngine;

public class JobManager : MonoBehaviour
{
    public Material OutlineMaterial;
    public GameObject[] buildings;
    public GameObject character;

    public Renderer[] bRenderer;
    public Material[] originalMaterial;

    public static int playerJob;

    public static int happinessLossBase = 10;
    public static int happinessLossPerTask = 2;

    public static int tasksDone;

    // Start is called before the first frame update
    void Start()
    {
        //Invoke("RandomJob", 7.5f);

        playerJob = PlayerPrefs.GetInt("PlayerJob", 0);
    }

    // Update is called once per frame
    /*void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "JobSelection")
                {
                    Vector3 buildingPos = hit.transform.position;
                    Vector3 characterPos = character.transform.position;

                    if ((buildingPos - characterPos).magnitude <= 1.5f)
                    {
                        if(GetJob() == 0)
                        {
                            GameObject hitGameObject = hit.collider.gameObject;

                            hitGameObject.GetComponent<Renderer>().material = originalMaterial[0];

                            playerJob = Random.Range(1, 5);
                            SetJob(1);

                            GameManager.SetHappiness(-15);

                            WarehouseJob.WarehouseTaskReady = true;

                            Debug.Log("You accepted a warehouse job!");
                            Invoke("JobComplete", 5f);
                            Tasks.jobTaskComplete();
                        }
                        else
                        {
                            Debug.Log("You already have a job!");
                        }
                    }
                }
            }
        }
    }*/

    public static void SetJob(int amount)
    {
        playerJob = amount;
        PlayerPrefs.SetInt("PlayerJob", amount);
    }

    public static int GetJob()
    {
        return playerJob;
    }

    public static void SetTaskDone(int amount)
    {
        tasksDone = amount;
        PlayerPrefs.SetInt("TasksDone", amount);
    }

    public static int GetTaskDone()
    {
        return tasksDone;
    }
}
