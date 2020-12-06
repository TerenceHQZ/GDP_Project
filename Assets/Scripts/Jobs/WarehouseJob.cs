using UnityEngine;

public class WarehouseJob : MonoBehaviour
{
    public float taskCoolDown = 45f;
    public static bool WarehouseTaskReady;
    private float timer;

    public GameObject character;
    public GameObject floatingSprite;

    private void Start()
    {
        timer = PlayerPrefs.GetFloat("TaskCooldown", 0f);
        Debug.Log("Warehouse cooldown: " + timer);

        if(timer > 0f)
        {
            Invoke("ResetCooldown", timer);
        }
        else
        {
            WarehouseTaskReady = true;

            if(JobManager.GetJob() == 1)
                floatingSprite.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetFloat("TaskCooldown", timer);
    }

    private void Update()
    {
        if (WarehouseTaskReady && floatingSprite.activeSelf)
        {
            floatingSprite.transform.position = new Vector3(floatingSprite.transform.position.x,
            floatingSprite.transform.position.y + (Mathf.Sin(Time.time) * 0.001f),
            floatingSprite.transform.position.z);

            floatingSprite.transform.Rotate(0, 0.25f, 0);
        }
        else if (!WarehouseTaskReady && !floatingSprite.activeSelf && JobManager.GetJob() == 1 && timer <= 0f)
        {
            floatingSprite.SetActive(true);
        }

        if (Input.GetMouseButtonDown(0) && JobManager.GetJob() == 1 && WarehouseTaskReady)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "Warehouse")
                {
                    Vector3 buildingPos = hit.transform.position;
                    Vector3 characterPos = character.transform.position;

                    Debug.Log((buildingPos - characterPos).magnitude);

                    if ((buildingPos - characterPos).magnitude <= 2.25f)
                    {
                        //GameObject hitGameObject = hit.collider.gameObject;

                        GameManager.SetHappiness(GameManager.GetHappiness() - JobManager.happinessLossPerTask);

                        JobManager.SetTaskDone(JobManager.GetTaskDone() + 1);

                        Debug.Log(JobManager.GetTaskDone());

                        // HIDE PROMPTS UI ON THE WAREHOUSE BUILDING
                        floatingSprite.SetActive(false);

                        Invoke("ResetCooldown", taskCoolDown);

                        WarehouseTaskReady = false;

                        timer = taskCoolDown;
                    }
                }
            }
        }

        if (!WarehouseTaskReady && timer >= 0f)
        {
            timer -= Time.deltaTime;
        }

        if (!WarehouseTaskReady && timer <= 0.5f)
        {
            // ResetCooldown();
        }
    }

    private void ResetCooldown()
    {
        WarehouseTaskReady = true;

        timer = 0f;
        PlayerPrefs.SetFloat("TaskCooldown", 0f);

        Debug.Log("Warehouse: Cooldown over");

        if (JobManager.GetJob() == 1)
        {
            // SHOW PROMPTS UI ON THE WAREHOUSE BUILDING
            floatingSprite.SetActive(true);
        }
    }
}
