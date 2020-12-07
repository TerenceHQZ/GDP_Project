using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToHome : MonoBehaviour
{
    public GameObject fadeAnimation;
    public GameObject mainCamera;
    public GameObject homeCamera;
    public GameObject quitButton;
    public GameObject character;
    public static bool atHome;

    public void SwapViews()
    {
        if (!fadeAnimation.activeInHierarchy)
        {
            if (mainCamera.activeInHierarchy)
                StartCoroutine(SwapToHomeView());

            else
                StartCoroutine(SwapToMainView());
        }
    }

    IEnumerator SwapToHomeView()
    {
        StartCoroutine(HomeFadeAnimation());
        atHome = true;
        yield return new WaitForSeconds(1f);
        character.transform.position = new Vector3(104.19352f, 2.52999997f, 11.6938114f);
        mainCamera.SetActive(false);
        homeCamera.SetActive(true);
        quitButton.SetActive(true);
    }

    IEnumerator SwapToMainView()
    {
        StartCoroutine(HomeFadeAnimation());
        atHome = false;
        yield return new WaitForSeconds(1f);
        character.transform.position = new Vector3(-0.639999986f, 0.400000006f, -9.47000027f);
        mainCamera.SetActive(true);
        homeCamera.SetActive(false);
        quitButton.SetActive(false);
    }

    IEnumerator HomeFadeAnimation()
    {
        fadeAnimation.SetActive(true);

        yield return new WaitForSeconds(3f);

        fadeAnimation.SetActive(false);
    }
}
