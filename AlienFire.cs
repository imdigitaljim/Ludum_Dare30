using UnityEngine;
using System.Collections;

public class AlienFire : MonoBehaviour {

    private GameObject player;
    public GameObject fire;
    private bool isInRange = false;
    public float cooldown = 0;
    private float cooldownInit;
	// Use this for initialization
	void Start () 
    {
        cooldownInit = cooldown;
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Mathf.Abs(player.GetComponent<Transform>().position.x - transform.position.x) < 7)
        {
            isInRange = true;
        }
        else
        {
            isInRange = false;
        }
        if (isInRange)
        {
            if (cooldown < 0)
            {
                Instantiate(fire, new Vector3(transform.position.x, transform.position.y -1f, transform.position.z), transform.rotation);
                cooldown = cooldownInit;
            }
            else
            {
                cooldown -= Time.deltaTime;
            }
        }
 
	}
}
