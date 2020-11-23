using UnityEngine;

public class JobManager : MonoBehaviour
{
    public Material OutlineMaterial;
    public GameObject[] buildings;

    public Renderer[] bRenderer;
    public Material[] originalMaterial;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
                    GameObject hitGameObject = hit.collider.gameObject;

                    hitGameObject.GetComponent<Renderer>().material = originalMaterial[0];
                }
            }
        }
    }

    void RandomJob()
    {
        bRenderer[Random.Range(0, 2)].material = OutlineMaterial;
    }
}
