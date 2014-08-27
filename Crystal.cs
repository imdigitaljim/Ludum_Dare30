using UnityEngine;
using System.Collections;

public class Crystal : MonoBehaviour
{
    // Use this for initialization
    public bool isFirst = true;
    private dfPanel panel;
    private bool isPaused = false;
    private bool isUsed = false;
    void Start()
    {
        panel = GameObject.Find("CrystalPanel").GetComponent<dfPanel>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused)
        {
            if (Input.anyKeyDown)
            {
                panel.Hide();
                Time.timeScale = 1;
                Destroy(gameObject);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            GetComponent<AudioSource>().Play();
            GetComponent<MeshRenderer>().enabled = false;
            if (isFirst)
            {
                PlayerInfo.crystals++;
                panel.Show();
                Time.timeScale = 0;
                isPaused = true;
            }
            else
            {
                if (!isUsed)
                {
                    PlayerInfo.crystals++;
                    isUsed = true;
                }
                else
                {
                    Destroy(gameObject, .5f);
                }
            }
        }
    }

}
