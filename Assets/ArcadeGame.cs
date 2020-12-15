using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeGame : MonoBehaviour
{
    public bool playedGame;
    public float timer;
    public float rotateSpeed;
    public float happinessGained;
    public float tapRange;
    public Transform sprite;
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
    }

    void PlayGame()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log((hit.transform.position - player.position).magnitude < tapRange);

            if (hit.transform == sprite && !playedGame && (hit.transform.position - player.position).magnitude < tapRange)
            {
                Debug.Log((hit.transform.position - player.position).magnitude);
                playedGame = true;
                sprite.gameObject.SetActive(false);
                ArcadeManager.arcadeManager.happinessGained += happinessGained;
            }
        }
    }
}
