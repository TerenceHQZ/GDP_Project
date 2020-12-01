using UnityEngine;

public class JobManager : MonoBehaviour
{
    public Material OutlineMaterial;
    public GameObject[] buildings;
    public GameObject character;

    public Renderer[] bRenderer;
    public Material[] originalMaterial;

    public static int playerJob;

    float Timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //Invoke("RandomJob", 7.5f);
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.J))
        {
            JobAvailable();
        }

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
                        if(playerJob == 0)
                        {
                            GameObject hitGameObject = hit.collider.gameObject;

                            hitGameObject.GetComponent<Renderer>().material = originalMaterial[0];

                            playerJob = Random.Range(1, 5);
                            playerJob = 1;
                            PlayerPrefs.SetInt("PlayerJob", playerJob);

                            WarehouseJob.WarehouseTaskReady = true;

                            Debug.Log("You accepted a warehouse job!");
                            //Invoke("jobComplete", 5f);
                            //Tasks.jobTaskComplete(); 
                        }
                        else
                        {
                            Debug.Log("You already have a job!");
                        }
                    }
                }
            }
        }
    }

    void JobAvailable()
    {
        bRenderer[0].material = OutlineMaterial;
    }

    void jobComplete()
    {
        Debug.Log("You have completed a job! You have earned $100!");
        GameManager.SetMoney(100);
        GameManager.SetHappiness(-20);
        //Tasks.jobsCompleted += 1;
    }

    public static void SetJob(int amount)
    {
        playerJob = amount;
        PlayerPrefs.SetInt("PlayerJob", amount);
    }

    public static int GetJob()
    {
        return playerJob;
    }
}
