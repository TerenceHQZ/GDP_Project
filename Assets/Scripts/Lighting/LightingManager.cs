using System.Collections;
using UnityEngine;

[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    //Scene References
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPreset Preset;
    //Variables
    [SerializeField, Range(7, 23)] private float TimeOfDay;

    private float UpdateAmount = 0.00166667f;

    private void Start()
    {
        TimeOfDay = PlayerPrefs.GetFloat("LightingTime", 7f);

        StartCoroutine(ChangeLighting());
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetFloat("LightingTime", TimeOfDay);
    }

    IEnumerator ChangeLighting()
    {
        yield return new WaitForSeconds(0.1f);

        if (Preset == null)
            yield return null;

        if (Application.isPlaying)
        {
            TimeOfDay += UpdateAmount;

            if (DayTimeManager.GetHour() >= 22 && DayTimeManager.GetMinute() >= 59)
            {
                yield return new WaitForSeconds(0.95f);
                TimeOfDay = 7f;
            }

            TimeOfDay %= 24; //Modulus to ensure always between 0-24

            UpdateLighting(TimeOfDay / 24);
        }
        else
        {
            UpdateLighting(TimeOfDay / 24);
        }

        yield return StartCoroutine(ChangeLighting());
    }

    private void UpdateLighting(float timePercent)
    {
        //If the directional light is set then rotate and set it's color, I actually rarely use the rotation because it casts tall shadows unless you clamp the value
        if (DirectionalLight != null)
        {
            DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent);

            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
        }

    }

    //Try to find a directional light to use if we haven't set one
    private void OnValidate()
    {
        if (DirectionalLight != null)
            return;

        //Search for lighting tab sun
        if (RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;
        }
        //Search scene for light that fits criteria (directional)
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach (Light light in lights)
            {
                if (light.type == LightType.Directional)
                {
                    DirectionalLight = light;
                    return;
                }
            }
        }
    }
}
