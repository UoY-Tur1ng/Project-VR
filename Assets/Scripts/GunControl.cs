using UnityEngine;

public class GunControl : MonoBehaviour {

    public float damage = 10.0f;
    public float range = 100f;

    public Camera P1Cam;

	
	// Update is called once per frame
	void Update () {
	    
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

	}

    void Shoot()
    {

        RaycastHit hit;
        if (Physics.Raycast(P1Cam.transform.position, P1Cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
        }
    }
}
