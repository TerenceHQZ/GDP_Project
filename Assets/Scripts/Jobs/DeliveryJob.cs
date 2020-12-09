using TMPro;
using UnityEngine;

public class DeliveryJob : MonoBehaviour
{
    public float taskCoolDown = 45f;
    public static bool DeliveryTaskReady;
    private float timer;
    private int randomBuilding;

    public GameObject character;
    public GameObject floatingSprite;
    public TextMeshProUGUI UIPrompt;

    public GameObject[] DeliveryBuildings;
    public GameObject[] floatingDeliverSprite;

    private void Start()
    {
        timer = PlayerPrefs.GetFloat("TaskCooldown", 0f);

        Debug.Log("Delivery cooldown: " + timer);

        if (timer > 0f)
        {
            Invoke("ResetCooldown", timer);
        }
        else
        {
            DeliveryTaskReady = true;

            if(JobManager.GetJob() == 2)
                floatingSprite.SetActive(true);
        }

        //JobManager.SetJob(2);
    }

    private void Update()
    {
        if (DeliveryTaskReady && floatingSprite.activeSelf)
        {
            floatingSprite.transform.position = new Vector3(floatingSprite.transform.position.x,
            floatingSprite.transform.position.y + (Mathf.Sin(Time.time) * 0.001f),
            floatingSprite.transform.position.z);

            floatingSprite.transform.Rotate(0, 0.25f, 0);
        }
        else if (!DeliveryTaskReady && !floatingSprite.activeSelf && JobManager.GetJob() == 2 && timer <= 0f)
        {
            floatingSprite.SetActive(true);
        }

        if (DeliveryTaskReady && floatingDeliverSprite[0].activeSelf)
        {
            floatingDeliverSprite[0].transform.position = new Vector3(floatingDeliverSprite[0].transform.position.x,
            floatingDeliverSprite[0].transform.position.y + (Mathf.Sin(Time.time) * 0.001f),
            floatingDeliverSprite[0].transform.position.z);

            floatingDeliverSprite[0].transform.Rotate(0, 0.25f, 0);
        }
        else if (DeliveryTaskReady && floatingDeliverSprite[1].activeSelf)
        {
            floatingDeliverSprite[1].transform.position = new Vector3(floatingDeliverSprite[1].transform.position.x,
            floatingDeliverSprite[1].transform.position.y + (Mathf.Sin(Time.time) * 0.001f),
            floatingDeliverSprite[1].transform.position.z);

            floatingDeliverSprite[1].transform.Rotate(0, 0.25f, 0);
        }
        else if (DeliveryTaskReady && floatingDeliverSprite[2].activeSelf)
        {
            floatingDeliverSprite[2].transform.position = new Vector3(floatingDeliverSprite[2].transform.position.x,
            floatingDeliverSprite[2].transform.position.y + (Mathf.Sin(Time.time) * 0.001f),
            floatingDeliverSprite[2].transform.position.z);

            floatingDeliverSprite[2].transform.Rotate(0, 0.25f, 0);
        }

        if (Input.GetMouseButtonDown(0) && JobManager.GetJob() == 2 && DeliveryTaskReady)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "MadEx")
                {
                    Vector3 buildingPos = hit.transform.position;
                    Vector3 characterPos = character.transform.position;

                    Debug.Log((buildingPos - characterPos).magnitude);

                    if ((buildingPos - characterPos).magnitude <= 3.8f)
                    {
                        randomBuilding = Random.Range(0, 3);
                        Debug.Log(DeliveryBuildings[randomBuilding].name);

                        floatingDeliverSprite[randomBuilding].SetActive(true);

                        // HIDE PROMPTS UI ON THE WAREHOUSE BUILDING
                        floatingSprite.SetActive(false);
                    }
                }
                else if (hit.transform.name == "HDB 1")
                {
                    Vector3 buildingPos = hit.transform.position;
                    Vector3 characterPos = character.transform.position;

                    Debug.Log((buildingPos - characterPos).magnitude);

                    if ((buildingPos - characterPos).magnitude <= 2.5f)
                    {
                        floatingDeliverSprite[randomBuilding].SetActive(false);

                        GameManager.SetHappiness(GameManager.GetHappiness() - JobManager.happinessLossPerTask);

                        JobManager.SetTaskDone(JobManager.GetTaskDone() + 1);

                        UIPrompt.text = "Task completed.\nTotal tasks done for the day: " + JobManager.GetTaskDone();

                        UIPrompt.gameObject.SetActive(true);

                        Invoke("HideUIPrompt", 3f);

                        Invoke("ResetCooldown", taskCoolDown);

                        DeliveryTaskReady = false;

                        timer = taskCoolDown;
                    }
                }
                else if (hit.transform.name == "HDB 2")
                {
                    Vector3 buildingPos = hit.transform.position;
                    Vector3 characterPos = character.transform.position;

                    Debug.Log((buildingPos - characterPos).magnitude);

                    if ((buildingPos - characterPos).magnitude <= 2.5f)
                    {
                        floatingDeliverSprite[randomBuilding].SetActive(false);

                        GameManager.SetHappiness(GameManager.GetHappiness() - JobManager.happinessLossPerTask);

                        JobManager.SetTaskDone(JobManager.GetTaskDone() + 1);

                        UIPrompt.text = "Task completed.\nTotal tasks done for the day: " + JobManager.GetTaskDone();

                        UIPrompt.gameObject.SetActive(true);

                        Invoke("HideUIPrompt", 3f);

                        Invoke("ResetCooldown", taskCoolDown);

                        DeliveryTaskReady = false;

                        timer = taskCoolDown;
                    }
                }
                else if (hit.transform.name == "HDB 3")
                {
                    Vector3 buildingPos = hit.transform.position;
                    Vector3 characterPos = character.transform.position;

                    Debug.Log((buildingPos - characterPos).magnitude);

                    if ((buildingPos - characterPos).magnitude <= 2.5f)
                    {
                        floatingDeliverSprite[randomBuilding].SetActive(false);

                        GameManager.SetHappiness(GameManager.GetHappiness() - JobManager.happinessLossPerTask);

                        JobManager.SetTaskDone(JobManager.GetTaskDone() + 1);

                        UIPrompt.text = "Task completed.\nTotal tasks done for the day: " + JobManager.GetTaskDone();

                        UIPrompt.gameObject.SetActive(true);

                        Invoke("HideUIPrompt", 3f);

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
            PlayerPrefs.SetFloat("TaskCooldown", timer);
        }

        if (!DeliveryTaskReady && timer <= 0.5f)
        {
            timer = 0f;
            PlayerPrefs.SetFloat("TaskCooldown", 0f);
        }
    }

    void HideUIPrompt()
    {
        UIPrompt.gameObject.SetActive(false);
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
            floatingSprite.SetActive(true);
        }
    }
}
