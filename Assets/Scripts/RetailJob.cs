using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetailJob : MonoBehaviour
{
    public Material OutlineMaterial, CollectionMaterial, OriginalMaterial;
    Renderer bRenderer;
    int retailTasks = 4;
    int tasksCount = 0;
    bool readyForTap = false;
    public bool retailJobActive = false;
    public float retailMoney;
    public float retailHappiness;

    void Start()
    {
        bRenderer = GetComponent<MeshRenderer>();
        StartCoroutine(RetailTasks());
        StartCoroutine(UpdateMaterial());
    }

    void Update()
    {
        RetailerJob();
    }

    void RetailerJob()
    {
        if (tasksCount >= retailTasks) // completed the job
        {
            retailJobActive = false;
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

    IEnumerator RetailTasks()
    {
        yield return new WaitForSeconds(100f);
        
        if (retailJobActive)
        {
            readyForTap = true;
            StartCoroutine(RetailTasks());
        }
    }

    IEnumerator UpdateMaterial()
    {
        yield return new WaitForSeconds(1f);

        if(retailJobActive)
        {
            if (readyForTap)
            {
                bRenderer.material = CollectionMaterial;
            }
            
            else
            {
                bRenderer.material = OutlineMaterial;
            }
            StartCoroutine(UpdateMaterial());
        }
    }
}

