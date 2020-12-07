using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Office : MonoBehaviour
{
    public GameObject floatingSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (JobManager.GetJob() == 0)
        {
            if(!floatingSprite.activeSelf)
                floatingSprite.SetActive(true);

            floatingSprite.transform.position = new Vector3(floatingSprite.transform.position.x,
            floatingSprite.transform.position.y + (Mathf.Sin(Time.time) * 0.001f),
            floatingSprite.transform.position.z);

            floatingSprite.transform.Rotate(0, 0.25f, 0);
        }
        else
        {
            floatingSprite.SetActive(false);
        }
        
    }
}
