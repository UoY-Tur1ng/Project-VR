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
    public Text AmmoText1;
	public Text AmmoText2;
	public Text AmmoText3;
	public Text AmmoText4;

	
	private SteamVR_TrackedObject trackedObj;
	// 2
	private SteamVR_Controller.Device Controller
	{
		get { return SteamVR_Controller.Input((int)trackedObj.index); }
	}


    private void Start()
    {
        Source = GetComponent<AudioSource>();
        RoundsInClip = ClipSize;
        Reloading = false;
        SetAmmoText();
    }
	
	void Awake()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}


    // Update is called once per frame
    void Update () {
	    

            if (RoundsInClip == 0 && Reloading == false)
            {
                Reloading = true;
                AmmoText1.text = "Ammo: Reloading";
				AmmoText2.text = "Ammo: Reloading";
				AmmoText3.text = "Ammo: Reloading";
				AmmoText4.text = "Ammo: Reloading";
                Source.PlayOneShot(ReloadClip, 1);
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
            else if (Time.time > LastShot + 0.45f && Controller.GetHairTriggerDown())
            {
                Shoot();
                LastShot = Time.time;
            }



	}

    void Shoot()
    {

        RaycastHit hit;
		if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit, range))
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
        AmmoText1.text = "Ammo: " + RoundsInClip.ToString();
		AmmoText2.text = "Ammo: " + RoundsInClip.ToString();
		AmmoText3.text = "Ammo: " + RoundsInClip.ToString();
		AmmoText4.text = "Ammo: " + RoundsInClip.ToString();
    }
}
