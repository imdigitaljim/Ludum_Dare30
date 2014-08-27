using UnityEngine;
using System.Collections;


public class InfoPanel : MonoBehaviour
{
    // Use this for initialization

    public float maxTime = 400;
    public static float timeLeft = 400;
    private dfLabel timeUpdate, livesUpdate, timeOut, crystals;
    private dfPanel crystalText, missingText, trans;
    private dfTiledSprite healthUpdate;
    void Start()
    {
        timeLeft = maxTime;
        livesUpdate = GameObject.Find("LivesCNT").GetComponent<dfLabel>();
        timeUpdate = GameObject.Find("TimeCNT").GetComponent<dfLabel>();
        crystals = GameObject.Find("CrystalCNT").GetComponent<dfLabel>();
        healthUpdate = GameObject.Find("BuzzBarFill").GetComponent<dfTiledSprite>();
        timeOut = GameObject.Find("TimeOut").GetComponent<dfLabel>();
        crystalText = GameObject.Find("CrystalPanel").GetComponent<dfPanel>();
        missingText = GameObject.Find("MissingPanel").GetComponent<dfPanel>();
        trans = GameObject.Find("TransPanel").GetComponent<dfPanel>();
        trans.Hide();
        missingText.Hide();
        timeOut.Hide();
        crystalText.Hide();

    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft < 100)
        {
            timeOut.Show();
        }

        crystals.Text = PlayerInfo.crystals.ToString();
        timeUpdate.Text = (timeLeft).ToString("0");
        livesUpdate.Text = PlayerInfo.lives.ToString();
        healthUpdate.FillAmount = PlayerInfo.health;
        //score.Text = playerScore.ToString("00000");

    }
}
