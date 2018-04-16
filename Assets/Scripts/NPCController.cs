using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour {

    //public float Speed = 6.0f;
    private GameObject Target;
    public GameObject CoverChoice;
    private GameObject[] CoverArray;
    private bool CoverReached;

    private void Start()
    {
        Target = GameObject.FindGameObjectWithTag("NPC Target");
        if (gameObject.transform.parent.tag == "++")
        {
            CoverArray = GameObject.FindGameObjectsWithTag("++Locs");
        }
        else if (gameObject.transform.parent.tag == "+-")
        {
            CoverArray = GameObject.FindGameObjectsWithTag("+-Locs");
        }
        else if (gameObject.transform.parent.tag == "-+")
        {
            CoverArray = GameObject.FindGameObjectsWithTag("-+Locs");
        }
        else if (gameObject.transform.parent.tag == "--")
        {
            CoverArray = GameObject.FindGameObjectsWithTag("--Locs");
        }

        System.Random rand = new System.Random((int)Time.time);
        CoverChoice = CoverArray[rand.Next(1, 6)];


        //go to CoverChoice
        GetComponent<NavMeshAgent>().destination = CoverChoice.transform.position;


    }
    
   void OnCollisionEnter(Collision coll)
    {
        coll
    }
    
    
    void Update()
    {
        if (CoverReached==true)
        {
            GetComponent<NavMeshAgent>().destination = (Target.transform.position - this.transform.position).normalized;
        }
    }

}
