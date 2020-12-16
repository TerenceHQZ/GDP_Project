using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ArcadeGame : MonoBehaviour
{
    public bool playedGame;
    public float timer;
    public float rotateSpeed;
    public int happinessGained;
    public float tapRange;
    public Transform sprite;
    public Transform text;
    Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        timer = Random.Range(1, 5);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlayGame();
        }

        if (playedGame)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                playedGame = false;
                sprite.gameObject.SetActive(true);
                timer = Random.Range(1, 5);
            }
        }

        else
            sprite.Rotate(0, rotateSpeed * Time.deltaTime, 0);

        if (text.gameObject.activeInHierarchy)
            text.position = new Vector3(text.position.x, text.transform.position.y + 0.2f * (Time.deltaTime), text.position.z);
    }

    void PlayGame()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform == sprite && !playedGame && (hit.transform.position - player.position).magnitude < tapRange)
            {
                playedGame = true;
                sprite.gameObject.SetActive(false);
                happinessGained = (Random.Range(1, 4) == 3 ? 2 : 1);
                StartCoroutine(DisplayText());
                ArcadeManager.arcadeManager.happinessGained += happinessGained;
            }
        }
    }

    IEnumerator DisplayText()
    {
        Vector3 textOriginalPos = text.position;
        text.gameObject.SetActive(true);
        text.GetComponent<TextMesh>().text = "Happiness + " + happinessGained.ToString();
        yield return new WaitForSeconds(1f);
        text.position = textOriginalPos;
        text.gameObject.SetActive(false);
    }
}
