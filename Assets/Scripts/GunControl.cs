using UnityEngine;
using UnityEngine.UI;

public class GunControl : MonoBehaviour {

    //public float damage = 10.0f;
    private float range = 100.0f;
    private int RoundsInClip;
    public int ClipSize;
    private bool Reloading;
    private float ReloadComnplete;
    private float LastShot;
    public Text AmmoText;

    public Camera P1Cam;


    private void Start()
    {
        RoundsInClip = ClipSize;
        Reloading = false;
        SetAmmoText();
    }


    // Update is called once per frame
    void Update () {
	    
        if (Input.GetButtonDown("Fire1"))
        {
            if (RoundsInClip == 0 && Reloading == false)
            {
                Reloading = true;
                AmmoText.text = "Ammo: Reloading";
                ReloadComnplete = Time.time + 3f;
            }
            else if (Reloading == true)
            {
                if (Time.time > ReloadComnplete)
                {
                    Reloading = false;
                    RoundsInClip = ClipSize;
                    SetAmmoText();
                }
            }
            else if (Time.time > LastShot + 0.45f)
            {
                Shoot();
                LastShot = Time.time;
            }
        }


	}

    void Shoot()
    {

        RaycastHit hit;
        if (Physics.Raycast(P1Cam.transform.position, P1Cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            if (hit.transform.name == "NPC Body")
            {
                Destroy(hit.transform.gameObject);
            }
        }
        RoundsInClip--;
        SetAmmoText();
    }

    void Reload()
    {
        RoundsInClip = ClipSize;
    }

    void SetAmmoText()
    {
        AmmoText.text = "Ammo:   " + RoundsInClip.ToString();
    }
}
