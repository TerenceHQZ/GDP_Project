using System.Collections;
using UnityEngine;

[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    //Scene References
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPreset Preset;
    //Variables
    //[SerializeField, Range(7, 23)] public float TimeOfDay;
    public static float TimeOfDay;

    private float UpdateAmount = 0.00166667f;

    private void Start()
    {
        TimeOfDay = PlayerPrefs.GetFloat("LightingTime", 7f);

        StartCoroutine(ChangeLighting());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            SetLightingTime(Random.Range(7, 24));
        }
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

            PlayerPrefs.SetFloat("LightingTime", TimeOfDay);

            TimeOfDay %= 24;

            UpdateLighting(TimeOfDay / 24);
        }
        else
        {
            UpdateLighting(TimeOfDay / 24);
        }

        yield return StartCoroutine(ChangeLighting());
    }

    public static void SetLightingTime(float targetTime)
    {
        TimeOfDay = targetTime;
        //UpdateLighting(TimeOfDay / 24);
    }

    public static float GetLightingTIme()
    {
        return TimeOfDay;
    }
     

    private void UpdateLighting(float timePercent)
    {
        if (DirectionalLight != null)
        {
            DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent);

            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
        }

    }

    private void OnValidate()
    {
        if (DirectionalLight != null)
            return;


        if (RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;
        }
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
