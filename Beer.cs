using UnityEngine;
using System.Collections;

public class Beer : MonoBehaviour
{
    // Use this for initialization
    private ParticleSystem particle;
    void Start()
    {
        particle = GetComponentInChildren<ParticleSystem>();
        particle.enableEmission = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            if (PlayerInfo.health < 1)
            {
                PlayerInfo.health += .5f;
            }
            GetComponent<AudioSource>().Play();
            GetComponent<MeshRenderer>().enabled = false;
            particle.enableEmission = true;
            particle.particleSystem.renderer.sortingLayerName = "Sprites 3";
            Destroy(gameObject,1f);
        }
    }

}
