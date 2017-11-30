using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour {

    public float speed = 6.0f;
    public GameObject target;

    private CharacterController _charCont;

    private void Start()
    {
        _charCont = GetComponent<CharacterController>();
    }
    
    //void OnCollisionEnter(Collision coll)
    //{
    //    //Cover has been hit
    //}


    
    void Update()
    {
        //I want to calculate the x/z direction to the centre first then handle the delta transforms later
        Vector3 Position = _charCont.transform.position;

        float fullDeltaX = Position.z;
        float fullDeltaZ = Position.x;

        float normalisedDeltaX = fullDeltaZ / fullDeltaX;
        float normalisedDeltaZ = 1;

        float deltaX = -1f * normalisedDeltaX * speed;
        float deltaZ = -1f * normalisedDeltaZ * speed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);

        _charCont.Move(movement);


    }
}
