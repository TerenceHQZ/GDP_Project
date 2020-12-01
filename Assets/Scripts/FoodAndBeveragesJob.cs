using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodAndBeveragesJob : MonoBehaviour
{
    public Material OutlineMaterial, CollectionMaterial, OriginalMaterial;
    int playerJob;
    Renderer bRenderer;
    public bool readyForTap = false;
    public bool foodBeverageJob = false;
    int tasks = 3;
    public int tasksCount = 0;
    public float timer = 0f;

    void Start()
    {
        bRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        foodNBeverageJob();
    }

    void FixedUpdate()
    {
        if (foodBeverageJob)
        {
            if (readyForTap)
            {
                bRenderer.material = CollectionMaterial;
            }
            else
            {
                bRenderer.material = OutlineMaterial;
                timer += Time.fixedDeltaTime;
                if (timer >= 10f)
                {
                    readyForTap = true;
                    timer = 0f;
                }
            }
        }
    }

    void foodNBeverageJob()
    {
        if (tasksCount >= tasks) // completed the job
        {
            foodBeverageJob = false;
            bRenderer.material = OriginalMaterial;
            tasksCount = 0;
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    playerJob = 3;
                    bRenderer.material = OutlineMaterial;
                    if (readyForTap == true)
                    {
                        readyForTap = false;
                        tasksCount++;
                        Debug.Log(tasksCount);
                    }
                }
            }
        }
    }
}
