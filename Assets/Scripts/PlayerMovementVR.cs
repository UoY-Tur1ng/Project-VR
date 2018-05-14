using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementVR : MonoBehaviour {

    public float speed = 4.5f;

    private float verticalVelocity;
    private float jumpForce = 4.2f;
    private float gravity = 14f;

    public SteamVR_Controller.Device controller;
	
	[SerializeField]
	SteamVR_TrackedObject controllerObject;

	IEnumerator DoPulse(SteamVR_Controller.Device controller) { 
		for(float i = 0; i < 0.1f; i += Time.deltaTime) { 
			controller.TriggerHapticPulse((ushort)(2000)); 
		yield return null; } 
	}

	// Use this for initialization
	void Start () {
        controller = SteamVR_Controller.Input ((int)controllerObject.index);
	}
	
	// Update is called once per frame
	void Update () {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);

        if (controller.GetHairTrigger ())
		{
			StartCoroutine (DoPulse (controller));
		}
		

	}
}

