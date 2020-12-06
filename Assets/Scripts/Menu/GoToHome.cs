using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToHome : MonoBehaviour
{
    public GameObject fadeAnimation;
    public GameObject mainCamera;
    public GameObject homeCamera;
    public GameObject quitButton;

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
        yield return new WaitForSeconds(1f);
        mainCamera.SetActive(false);
        homeCamera.SetActive(true);
        quitButton.SetActive(true);
    }

    IEnumerator SwapToMainView()
    {
        StartCoroutine(HomeFadeAnimation());
        yield return new WaitForSeconds(1f);
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
