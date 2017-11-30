using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCollider : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            Destroy(other.gameObject);
        }        
    }
    // Update is called once per frame
    void Update () {
		
	}
}
