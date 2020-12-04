using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodAndBeveragesJob : MonoBehaviour
{
    public Material OutlineMaterial, CollectionMaterial, OriginalMaterial;
    Renderer bRenderer;
    int foodBeverageTasks = 6;
    int tasksCount = 0;
    bool readyForTap = false;
    public bool foodBeverageJobActive = false;
    public float fBMoney;
    public float fBHappiness;

    void Start()
    {
        bRenderer = GetComponent<MeshRenderer>();

        StartCoroutine(FoodBeverageTasks());
        StartCoroutine(UpdateMaterial());
    }

    void Update()
    {
        FoodBeverageJob();
    }

    void FoodBeverageJob()
    {
        if (tasksCount >= foodBeverageTasks) // completed the job
        {
            foodBeverageJobActive = false;
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
                    JobManager.SetJob(3);
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

    IEnumerator FoodBeverageTasks()
    {
        yield return new WaitForSeconds(120f);

        if (foodBeverageJobActive)
        {
            readyForTap = true;
            StartCoroutine(FoodBeverageTasks());
        }
    }

    IEnumerator UpdateMaterial()
    {
        yield return new WaitForSeconds(1f);

        if (foodBeverageJobActive)
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
