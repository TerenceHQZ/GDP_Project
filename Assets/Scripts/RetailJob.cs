using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetailJob : MonoBehaviour
{
    public Material OutlineMaterial, CollectionMaterial, OriginalMaterial;
    Renderer bRenderer;
    float retailTimer = 120f;
    float timer = 0f;
    int retailTasks = 4;
    int tasksCount = 0;
    bool readyForTap = false;
    public bool retailJob = false;
    public float retailMoney;
    public float retailHappiness;

    void Start()
    {
        bRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        RetailerJob();
    }

    void FixedUpdate()
    {
        if (retailJob)
        {
            if (readyForTap)
            {
                bRenderer.material = CollectionMaterial;
            }
            else
            {
                bRenderer.material = OutlineMaterial;
                timer += Time.fixedDeltaTime;
                if (timer >= retailTimer)
                {
                    readyForTap = true;
                    timer = 0f;
                }
            }
        }
    }

    void RetailerJob()
    {
        if (tasksCount >= retailTasks) // completed the job
        {
            retailJob = false;
            bRenderer.material = OriginalMaterial;
            tasksCount = 0;
            JobManager.SetJob(0);
        }

        if (Input.GetMouseButtonDown(0))  // checks whether the player clicks on the F&B building 
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform) // sets playerJob int to 3, outlines the building so that the player knows that he has the job
                {
                    JobManager.SetJob(4);  
                    bRenderer.material = OutlineMaterial;
                    if (readyForTap == true) 
                    {
                        readyForTap = false;
                        tasksCount++;
                    }
                }
            }
        }
    }
}

