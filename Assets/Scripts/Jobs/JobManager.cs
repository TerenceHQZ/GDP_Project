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
    /*void Start()
    {
        playerJob = PlayerPrefs.GetInt("PlayerJob", 0);
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
