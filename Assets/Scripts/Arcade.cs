using TMPro;
using System.Collections;
using UnityEngine;

public class Arcade : MonoBehaviour
{
    public int arcadeCost;
    public GameObject character;
    public GameObject floatingSprite;
    public Transform fadeAnimation;
    public TextMeshProUGUI UIPrompt;

    void Update()
    {
        floatingSprite.transform.position = new Vector3(floatingSprite.transform.position.x,
        floatingSprite.transform.position.y + (Mathf.Sin(Time.time) * 0.001f),
        floatingSprite.transform.position.z);

        floatingSprite.transform.Rotate(0, 0.25f, 0);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "Arcade")
                {
                    Vector3 buildingPos = hit.transform.position;
                    Vector3 characterPos = character.transform.position;

                    Debug.Log((buildingPos - characterPos).magnitude);

                    if ((buildingPos - characterPos).magnitude <= 3f)
                    {
                        UseArcade();
                    }
                }
            }
        }
    }

    void UseArcade()
    {
        if (GameManager.GetMoney() >= arcadeCost)
        {
            GameManager.SetMoney(GameManager.GetMoney() - arcadeCost);

            GameManager.SetHappiness(GameManager.GetHappiness() + 5);

            UIPrompt.text = "John played the arcade for $60. (Happiness +5)";

            UIPrompt.gameObject.SetActive(true);

            Invoke("HideUIPrompt", 3f);
        }
        else
        {
            UIPrompt.text = "John does not have enough money.";

            UIPrompt.gameObject.SetActive(true);

            Invoke("HideUIPrompt", 3f);
        }
    }

    void HideUIPrompt()
    {
        UIPrompt.gameObject.SetActive(false);
    }

    IEnumerator GoToArcade()
    {
        fadeAnimation.gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);

        
    }
}
