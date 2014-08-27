using UnityEngine;
using System.Collections;


public class PlayerInfo : MonoBehaviour
{

    public static int lives = 5;
    public static float health = .5f;
    public static int crystals = 0;
    public bool isHurt = false;
    public int invisibleBlink = 0;

    private PlayerMovement movement;
    private MeshRenderer sprite;
    // Use this for initialization
    void Start()
    {
        lives = 5;
        movement = GetComponent<PlayerMovement>();
        sprite = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerMovement.isAlive)
        {
            return;
        }
        if (!isHurt && !sprite.enabled)
        {
            sprite.enabled = true;
        }

        if (lives <= 0 || InfoPanel.timeLeft < 0)
        {
            Application.LoadLevel("GameOver");
        }

        if (health <= 0)
        {
            GetComponent<PlayerMovement>().Death();
        }


    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy" && !isHurt)
        {
            if (rigidbody2D.velocity.y > -.001f)
            {
                HurtSequence();
            }
        }
        else if (col.gameObject.tag == "Fire" && !isHurt)
        {
            HurtSequence();
        }
    }

    private void HurtSequence()
    {
        health -= .5f;
        GetComponent<AudioSource>().PlayOneShot(movement.sfx[0]);
        if (health > 0 && !isHurt)
        {
            isHurt = true;
            SpriteBlink();
        }
    }


    private void SpriteBlink()
    {
        invisibleBlink++;
        sprite.enabled = !sprite.enabled;
        if (invisibleBlink < 10)
        {
            Invoke("SpriteBlink", .3f);
        }
        else
        {
            isHurt = false;
            invisibleBlink = 0;
        }
    }



}
