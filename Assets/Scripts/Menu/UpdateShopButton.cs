using System.Collections;
using UnityEngine;

public class UpdateShopButton : MonoBehaviour
{
    public GameObject[] BuyButton;
    public GameObject[] ClaimedButton;

    void Start()
    {
        if (PlayerPrefs.GetInt("OwnedFan") == 1)
        {
            BuyButton[0].SetActive(false);
            ClaimedButton[0].SetActive(true);
        }

        if (PlayerPrefs.GetInt("OwnedTable") == 1)
        {
            BuyButton[1].SetActive(false);
            ClaimedButton[1].SetActive(true);
        }

        if (PlayerPrefs.GetInt("OwnedChair") == 1)
        {
            BuyButton[2].SetActive(false);
            ClaimedButton[2].SetActive(true);
        }

        if (PlayerPrefs.GetInt("OwnedBed") == 1)
        {
            BuyButton[3].SetActive(false);
            ClaimedButton[3].SetActive(true);
        }

        if (PlayerPrefs.GetInt("OwnedPC") == 1)
        {
            BuyButton[4].SetActive(false);
            ClaimedButton[4].SetActive(true);
        }

        StartCoroutine(SetButton());
    }

    IEnumerator SetButton()
    {
        yield return new WaitForSeconds(0.25f);

        if (PlayerPrefs.GetInt("OwnedFan") == 1)
        {
            BuyButton[0].SetActive(false);
            ClaimedButton[0].SetActive(true);
        }

        if (PlayerPrefs.GetInt("OwnedTable") == 1)
        {
            BuyButton[1].SetActive(false);
            ClaimedButton[1].SetActive(true);
        }

        if (PlayerPrefs.GetInt("OwnedChair") == 1)
        {
            BuyButton[2].SetActive(false);
            ClaimedButton[2].SetActive(true);
        }

        if (PlayerPrefs.GetInt("OwnedBed") == 1)
        {
            BuyButton[3].SetActive(false);
            ClaimedButton[3].SetActive(true);
        }

        if (PlayerPrefs.GetInt("OwnedPC") == 1)
        {
            BuyButton[4].SetActive(false);
            ClaimedButton[4].SetActive(true);
        }

        yield return StartCoroutine(SetButton());
    }
}
