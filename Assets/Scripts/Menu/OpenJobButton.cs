using UnityEngine;

public class OpenJobButton : MonoBehaviour
{
    public GameObject character;
    public GameObject JobWindow;

    private void Update()
    {
        // Debug.Log(JobManager.GetJob());

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "Office")
                {
                    Vector3 buildingPos = hit.transform.position;
                    Vector3 characterPos = character.transform.position;

                    Debug.Log((buildingPos - characterPos).magnitude);

                    if ((buildingPos - characterPos).magnitude <= 2.5f)
                    {
                        JobWindow.SetActive(true);
                    }
                }
            }
        }
    }
}
