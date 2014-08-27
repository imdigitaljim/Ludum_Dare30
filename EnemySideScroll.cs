using UnityEngine;
using System.Collections;

public class EnemySideScroll : MonoBehaviour
{

    private bool goLeft = false;
    private float moveSpeed = 2f;
    private GameObject player;
    private bool isInRange = false;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(player.GetComponent<Transform>().position.x - transform.position.x) < 7)
        {
            isInRange = true;
        }
        else
        {
            isInRange = false;
            rigidbody2D.velocity = Vector2.zero;
        }
        if (isInRange)
        {
            if (Mathf.Abs(rigidbody2D.velocity.x) < moveSpeed * .9f)
            {
                goLeft = !goLeft;
            }

            if (goLeft)
            {
                rigidbody2D.velocity = new Vector2(-moveSpeed, rigidbody2D.velocity.y);
            }
            else
            {
                rigidbody2D.velocity = new Vector2(moveSpeed, rigidbody2D.velocity.y);
            }
        }

    }
    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            if (col.gameObject.rigidbody2D.velocity.y <= -.001f)
            {

                gameObject.collider2D.enabled = false;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                GetComponent<tk2dSprite>().SetSprite("splat");
                GetComponent<AudioSource>().Play();
                Destroy(gameObject, 1f);
            }
        }
    }
}
