using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour
{

    public static bool playerWins = false;
    public static bool missingCrystal = false;
    private dfPanel missing;
    private Transform player;
    private bool isPaused;
    // Use this for initialization
    void Start()
    {
        missing = GameObject.Find("MissingPanel").GetComponent<dfPanel>();
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused)
        {
            if (Input.anyKeyDown)
            {
                missing.Hide();
                Time.timeScale = 1;
                player.transform.position = new Vector2(player.position.x - 5, player.position.y);
                isPaused = false;

            }
            if (playerWins)
            {
                Application.LoadLevel("WinGame");
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Time.timeScale = 0;
            isPaused = true;
            if (PlayerInfo.crystals == 6)
            {
                playerWins = true;
            }
            else
            {
                missing.Show();
                GetComponent<AudioSource>().Play();
            }
        }
    }






}
