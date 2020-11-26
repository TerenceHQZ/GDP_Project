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
        Invoke("RandomJob", 7.5f);
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.J))
        {
            RandomJob();
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Buildings")
                {
                    Vector3 buildingPos = hit.transform.position;
                    Vector3 characterPos = character.transform.position;

                    if ((buildingPos - characterPos).magnitude <= 1.5f)
                    {
                        if(playerJob == 0)
                        {
                            GameObject hitGameObject = hit.collider.gameObject;

                            hitGameObject.GetComponent<Renderer>().material = originalMaterial[0];

                            playerJob = Random.Range(0, 4);

                            Debug.Log("You accepted an part-time office job!");
                            Invoke("jobComplete", 5f);
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

    void RandomJob()
    {
        int randomValue = Random.Range(0, 2);
        bRenderer[randomValue].material = OutlineMaterial;
    }
    void jobComplete()
    {
        Debug.Log("You have completed a job! You have earned $100!");
        GameManager.SetMoney(100);
        GameManager.SetHappiness(-20);
    }
}
