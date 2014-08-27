using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    private Transform player;
    private Color color;
    private tk2dCamera cameraObject;
    // Use this for initialization
    void Start()
    {
        cameraObject = GetComponent<tk2dCamera>();
        color = cameraObject.camera.backgroundColor;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x > 4.5f)
        {
            transform.position = new Vector3(player.position.x, GetYValue(), transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, GetYValue(), transform.position.z);
        }
        if (player.transform.position.x <= 125f)
        {
            cameraObject.camera.backgroundColor = color;
        }
        else if (player.transform.position.x <= 215f)
        {
            GetComponent<tk2dCamera>().camera.backgroundColor = Color.cyan;
        }
        else
        {
            GetComponent<tk2dCamera>().camera.backgroundColor = Color.black;
        }
    }

    private float GetYValue()
    {
        float yPos;
        if (player.position.y < 3)
        {
            yPos = 3;
        }
        else
        {
            yPos = player.position.y;
        }
        return yPos;

    }



}
