using UnityEngine;
using System.Collections;

public class GroundDetection : MonoBehaviour
{

    public LayerMask mask;
    private bool hasHit = false;
    private RaycastHit2D ground;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!hasHit)
        {
            ground = Physics2D.Raycast(rigidbody2D.position, new Vector2(0, -.05f), .05f, mask);
        }

        else if (ground.collider != null)
        {
            hasHit = true;
            Destroy(rigidbody2D);
        }
    }
}
