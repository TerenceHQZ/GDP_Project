using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ArcadeManager : MonoBehaviour
{
    public bool atArcade;
    public float happinessGained;
    public float time;
    public Animator fadeAnim;
    public TextMeshProUGUI timer, happiness;
    public static ArcadeManager arcadeManager;

    void Start()
    {
        atArcade = true;

        if (arcadeManager && arcadeManager != this)
            Destroy(gameObject);

        else
        {
            arcadeManager = this;
            DontDestroyOnLoad(gameObject);
        }

        if (atArcade)
        {
            GoToHome.atHome = false;
        }
    }

    void Update()
    {
        if (time < 0)
        {
            time = 0;
            StartCoroutine(GoBackToMain());
        }

        time -= Time.deltaTime;
        timer.text = time.ToString("F0");

        happiness.text = "Happiness Gained: " + happinessGained.ToString("F0");
    }

    IEnumerator GoBackToMain()
    {
        fadeAnim.SetTrigger("timer");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Gameplay");
        Destroy(gameObject);
    }
}
