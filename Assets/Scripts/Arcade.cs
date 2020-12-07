using UnityEngine;

public class Arcade : MonoBehaviour
{
    public int arcadeCost;
    public GameObject character;

    void Update()
    {
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
        }
    }
}
