using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour {

    //public float Speed = 6.0f;
    private GameObject Target;
    public GameObject CoverChoice;
    private GameObject[] CoverArray;
    public bool CoverReached;
    public string SectorTag;

    private void Start()
    {
        Target = GameObject.FindGameObjectWithTag("NPC Target");
        if (gameObject.transform.parent.tag == "++")
        {
            SectorTag = "++Locs";
        }
        else if (gameObject.transform.parent.tag == "+-")
        {
            SectorTag = "+-Locs";
        }
        else if (gameObject.transform.parent.tag == "-+")
        {
            SectorTag = "-+Locs";
        }
        else if (gameObject.transform.parent.tag == "--")
        {
            SectorTag = "--Locs";
        }

        CoverArray = GameObject.FindGameObjectsWithTag(SectorTag);
        System.Random rand = new System.Random((int)Time.time);
        CoverChoice = CoverArray[rand.Next(1, 6)];

        //go to CoverChoice
        GetComponent<NavMeshAgent>().destination = CoverChoice.transform.position;
    }

    private void OnTriggerEnter(Collider coll)
    {
        Debug.Log("Cover Reached");
        if (coll.gameObject.tag == SectorTag)
        {

            CoverReached = true;
            Debug.Log("start Waiting");
            GetComponent<NavMeshAgent>().destination = this.transform.position;
            waitfor2();
            Debug.Log("Waiting over");
            GetComponent<NavMeshAgent>().destination = (Target.transform.position - this.transform.position).normalized;
            Debug.Log("new destination set + " + GetComponent<NavMeshAgent>().destination.ToString());

        }

    }
    IEnumerator waitfor2()
    {
        yield return new WaitForSeconds(2);
    }
    
    void Update()
    {
        Debug.Log(GetComponent<NavMeshAgent>().destination.ToString());
    }

}
