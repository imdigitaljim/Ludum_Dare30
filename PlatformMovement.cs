using UnityEngine;
using System.Collections;

public class PlatformMovement : MonoBehaviour
{

    private float initX;
    private float initY;
    private bool direction = true;
    public bool upDown = true;
    public float platformSpeed = .02f;
    public int platformDistance= 2;
    // Use this for initialization
    void Start()
    {
        initX = transform.position.x;
        initY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (upDown)
        {
            if (transform.position.y > initY + platformDistance)
            {
                direction = false;
            }
            else if (transform.position.y < initY - platformDistance)
            {
                direction = true;
            }
            if (direction)
            {
                transform.position = new Vector3(initX, transform.position.y + platformSpeed, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(initX, transform.position.y - platformSpeed, transform.position.z);
            }
        }

        if (!upDown)
        {
            if (transform.position.x > initX + platformDistance)
            {
                direction = false;
            }
            else if (transform.position.x < initX - platformDistance)
            {
                direction = true;
            }
            if (direction)
            {
                transform.position = new Vector3(transform.position.x + platformSpeed, initY, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x - platformSpeed, initY, transform.position.z);
            }
        }
    }
}
