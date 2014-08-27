using UnityEngine;
using System.Collections;


public class PlayerMovement : MonoBehaviour
{

    public LayerMask mask;
    public bool jump = false;
    public static bool isAlive = true;
    public AudioClip[] sfx;

    public static  Vector2 checkpoint;
    private tk2dSpriteAnimator playerAnimation;
    private float xSpeed = 2f;


    // Use this for initialization
    void Start()
    {
        playerAnimation = GetComponent<tk2dSpriteAnimator>();
        checkpoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");

        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x * .85f, rigidbody2D.velocity.y);
        
        
        
        var ground = Physics2D.Raycast(rigidbody2D.position, new Vector2(0, -.25f), .25f, mask);
        // var sideRay = Physics2D.Raycast(new Vector2(rigidbody2D.position.x - .15f, rigidbody2D.position.y + .05f), new Vector2(.20f, 0), .35f, mask);

        //Debug.DrawRay(rigidbody2D.position, new Vector2(0, -.20f), Color.red);
       // Debug.DrawRay(new Vector2(rigidbody2D.position.x - .15f, rigidbody2D.position.y + .05f), new Vector2(.35f, 0), Color.blue);


        //animation
        if (Mathf.Abs(x) > .05f)
        {
            playerAnimation.Play("Walk");
        }
        else
        {
            playerAnimation.Play("Still");
            playerAnimation.Stop();
        }

        if (x != 0 && Mathf.Abs(rigidbody2D.velocity.x) < xSpeed && isAlive)
        {

            if (x > 0)
            {
                playerAnimation.Sprite.FlipX = false;
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x + 1.1f * xSpeed, rigidbody2D.velocity.y);
            }
            if (x < 0 && transform.position.x > 2f)
            {
                playerAnimation.Sprite.FlipX = true;
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x + 1.1f * -xSpeed, rigidbody2D.velocity.y);
            }

        }

        if (Input.GetButtonDown("Jump") && !jump)
        {
            jump = true;
            GetComponent<AudioSource>().PlayOneShot(sfx[1]);
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 6f);
        }

        if (rigidbody2D.velocity.y > 0)
        {
            Physics2D.IgnoreLayerCollision(22, 23, true);
        }

        else
        {
            Physics2D.IgnoreLayerCollision(22, 23, false);
        }

        //Debug.DrawRay( new Vector2(rigidbody2D.position.x, rigidbody2D.position.y + .05f), new Vector2(-.20f, 0), Color.blue);




        if (ground.collider != null && Mathf.Abs(rigidbody2D.velocity.y) < .02f)
        {
            jump = false;
        }

        if (transform.position.y < -2 && isAlive)
        {
            Death();
        }



    }

    public void Death()
    {
        --PlayerInfo.lives;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        isAlive = false;
        Invoke("Respawn", 3f);
    }
    private void Respawn()
    {
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;
        transform.position = checkpoint;
        isAlive = true;
        PlayerInfo.health = 1;
    }


}
