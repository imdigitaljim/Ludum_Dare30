using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour
{

    // Use this for initialization

    public bool canDestroy = false;
    void Start()
    {
        GetComponent<ParticleSystem>().particleSystem.renderer.sortingLayerName = "Sprites 3";
    }

    // Update is called once per frame
    void Update()
    {

        if (canDestroy)
        {
            Destroy(transform.parent.gameObject, 5f);
        }
    }
}
