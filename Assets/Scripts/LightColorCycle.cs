using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightColorCycle : MonoBehaviour
{
    public Color[] colors;
    public float smooth;
    float time;
    int colorIndex = 0;
    Light theLight;

    void Start()
    {
        theLight = GetComponent<Light>();
    }

    void Update()
    {
        if (colorIndex < colors.Length)
        {
            theLight.color = Color.Lerp(theLight.color, colors[colorIndex], smooth * Time.deltaTime);

            time = Mathf.Lerp(time, 1f, smooth * Time.deltaTime);

            if (time > 0.9f)
            {
                time = 0f;
                colorIndex++;
                colorIndex = (colorIndex >= colors.Length) ? 0 : colorIndex;
            }
        }
    }
}
