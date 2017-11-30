using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 6.0f;

    private float verticalVelocity;
    private float jumpForce = 4.2f;
    private float gravity = 14f;

    private CharacterController _charCont;

	// Use this for initialization
	void Start () {
        _charCont = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);

        if (_charCont.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        movement.y = verticalVelocity * Time.deltaTime;

        _charCont.Move(movement);
	}
}
