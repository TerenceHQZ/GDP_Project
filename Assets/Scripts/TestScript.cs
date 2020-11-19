using System.Collections;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.GetPlayerMoney() <= 0)
        {
            StartCoroutine(ReduceHappiness());
        }
    }

    IEnumerator ReduceHappiness()
    {
        yield return new WaitForSeconds(1.0f);

        GameManager.SetHappiness(-1);

        Debug.Log(GameManager.GetPlayerHappiness());

        if (GameManager.GetPlayerHappiness() <= 0)
        {
            PlayerPrefs.SetInt("AccountExist", 0);
            Debug.Log("Lose");
            yield return null;
        }
        else
        {
            yield return StartCoroutine(ReduceHappiness());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
