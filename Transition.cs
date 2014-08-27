using UnityEngine;
using System.Collections;

public class Transition : MonoBehaviour {

    private dfPanel trans;
	// Use this for initialization
	void Start () {
        trans = GameObject.Find("TransPanel").GetComponent<dfPanel>();
	}
	
	// Update is called once per frame
	void Update () 
    {

	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {

                trans.Show();
                Destroy(trans.gameObject, 3f);
        }
    }
}
