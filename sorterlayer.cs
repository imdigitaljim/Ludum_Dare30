using UnityEngine;
using System.Collections;

public class sorterlayer : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
        GetComponent<ParticleRenderer>().renderer.sortingLayerName = "Sprites 3";
	}
	
	// Update is called once per frame
	void Update () 
    {

	}
}
