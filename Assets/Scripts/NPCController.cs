using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour {

    public float speed = 6.0f;
    private GameObject target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("NPC Target");
        GetComponent<NavMeshAgent>().destination = (target.transform.position - this.transform.position).normalized;
    }
    
    //void OnCollisionEnter(Collision coll)
    //{
    //    //Cover has been hit
    //}


    
    void Update()
    {



    }
}
