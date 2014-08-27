using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {

	// Use this for initialization
    private ParticleSystem particle;
    private bool isChecked = false;
	void Start () 
    {
        particle = GetComponentInChildren<ParticleSystem>();
        particle.enableEmission = false;
        particle.particleSystem.renderer.sortingLayerName = "Sprites 3";
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            if (!isChecked)
            {
                GetComponent<AudioSource>().Play();
                isChecked = true;
                PlayerInfo.health = 1;
            }
            particle.enableEmission = true;
            PlayerMovement.checkpoint = GetComponent<Transform>().position;
        }
    }
}
