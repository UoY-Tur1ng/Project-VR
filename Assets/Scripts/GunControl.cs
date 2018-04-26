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
    private AudioSource Source;
    public AudioClip FireClip;
    public AudioClip ReloadClip;
    public Text AmmoText;

    public Camera P1Cam;


    private void Start()
    {
        Source = GetComponent<AudioSource>();
        RoundsInClip = ClipSize;
        Reloading = false;
        SetAmmoText();
    }


    // Update is called once per frame
    void Update () {
	    

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
                    Source.PlayOneShot(ReloadClip, 1);
                    RoundsInClip = ClipSize;
                    SetAmmoText();
                }
            }
            else if (Time.time > LastShot + 0.45f && Input.GetButtonDown("Fire1"))
            {
                Shoot();
                LastShot = Time.time;
            }



	}

    void Shoot()
    {

        RaycastHit hit;
        if (Physics.Raycast(P1Cam.transform.position, P1Cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            if (hit.transform.tag == "NPC")
            {
                Destroy(hit.transform.gameObject);
            }
        }
        RoundsInClip--;

        Source.PlayOneShot(FireClip, Random.Range(0.7f,0.8f));
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
