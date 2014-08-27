using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Application.loadedLevelName != "Title" && Input.anyKey)
        {
            Application.LoadLevel("Title");
        }

    }


    public void StartClick(dfControl control, dfMouseEventArgs mouseEvent)
    {
        Application.LoadLevel("BigCity");
    }



}
