﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public static int tutorialProgress;

    public GameObject storyText;
    public GameObject controlsText;
    public GameObject UIP1Text;
    public GameObject UIP2Text;
    public GameObject UIP3Text;
    public GameObject rulesP1Text;
    public GameObject rulesP2Text;
    public GameObject slideScreenToRotate;
    public GameObject slideIcon;

    private bool iconMovement;

    // Start is called before the first frame update
    void Start()
    {
        tutorialProgress = PlayerPrefs.GetInt("TutorialProgress", 0);

        if (tutorialProgress == 0)
        {
            storyText.SetActive(true);
        }
        else if (tutorialProgress == 1)
        {
            controlsText.SetActive(true);
        }
        else if (tutorialProgress == 2)
        {
            UIP1Text.SetActive(true);
        }
        else if (tutorialProgress == 3)
        {
            UIP2Text.SetActive(true);
        }
        else if (tutorialProgress == 4)
        {
            UIP3Text.SetActive(true);
        }
        else if (tutorialProgress == 5)
        {
            rulesP1Text.SetActive(true);
        }
        else if (tutorialProgress == 6)
        {
            rulesP2Text.SetActive(true);
        }
        else if (tutorialProgress == 7)
        {
            slideScreenToRotate.SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GetTutorialProgress() == 0)
            {
                SetTutorialProgress(1);
                storyText.SetActive(false);
                controlsText.SetActive(true);
            }
            else if(GetTutorialProgress() == 1)
            {
                SetTutorialProgress(2);
                controlsText.SetActive(false);
                UIP1Text.SetActive(true);
            }
            else if (GetTutorialProgress() == 2)
            {
                SetTutorialProgress(3);
                UIP1Text.SetActive(false);
                UIP2Text.SetActive(true);
            }
            else if (GetTutorialProgress() == 3)
            {
                SetTutorialProgress(4);
                UIP2Text.SetActive(false);
                UIP3Text.SetActive(true);
            }
            else if (GetTutorialProgress() == 4)
            {
                SetTutorialProgress(5);
                UIP3Text.SetActive(false);
                rulesP1Text.SetActive(true);
            }
            else if (GetTutorialProgress() == 5)
            {
                SetTutorialProgress(6);
                rulesP1Text.SetActive(false);
                rulesP2Text.SetActive(true);
            }
            else if (GetTutorialProgress() == 6)
            {
                SetTutorialProgress(7);
                rulesP2Text.SetActive(false);
                slideScreenToRotate.SetActive(true);

                slideIcon.transform.TransformDirection(new Vector3(1.5f,
                    slideIcon.transform.localPosition.y,
                    slideIcon.transform.localPosition.z));
            }
            else if (GetTutorialProgress() == 7)
            {
                SetTutorialProgress(8);
                slideScreenToRotate.SetActive(false);
            }
        }

        if (GetTutorialProgress() == 7)
        {
            Debug.Log(slideIcon.transform.position.x);
            if (slideIcon.transform.position.x <= 1150f)
            {
                iconMovement = true;
            }
            else if (slideIcon.transform.position.x >= 1950f)
            {
                iconMovement = false;
            }

            if (iconMovement)
            {
                slideIcon.transform.position = new Vector3(
                slideIcon.transform.position.x + (Time.deltaTime * 500),
                slideIcon.transform.position.y,
                slideIcon.transform.position.z);
            }
            else
            {
                slideIcon.transform.position = new Vector3(
                slideIcon.transform.position.x - (Time.deltaTime * 500),
                slideIcon.transform.position.y,
                slideIcon.transform.position.z);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetTutorialProgress(0);
        }
    }

    public static void SetTutorialProgress(int progress)
    {
        tutorialProgress = progress;
        PlayerPrefs.SetInt("TutorialProgress", tutorialProgress);
    }

    public static int GetTutorialProgress()
    {
        return tutorialProgress;
    }
}