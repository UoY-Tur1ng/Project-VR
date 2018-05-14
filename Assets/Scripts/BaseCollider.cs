using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseCollider : MonoBehaviour {

    public int BaseHP;
    public Text HPText1;
	public Text HPText2;
	public Text HPText3;
	public Text HPText4;
    public Text GameOverText1;
	public Text GameOverText2;
	public Text GameOverText3;
	public Text GameOverText4;

    private void Start()
    {
        SetHPText();
        GameOverText1.text = "";
		GameOverText2.text = "";
		GameOverText3.text = "";
		GameOverText4.text = "";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            Destroy(other.transform.gameObject);
            BaseHP--;
            SetHPText();
            if (BaseHP <= 0) GameOver();
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    void GameOver()
    {
        GameOverText1.text = "GAME OVER";
		GameOverText2.text = "GAME OVER";
		GameOverText3.text = "GAME OVER";
		GameOverText4.text = "GAME OVER";
    }

    void SetHPText()
    {
        HPText1.text = "Health: " + BaseHP.ToString();
		HPText2.text = "Health: " + BaseHP.ToString();
		HPText3.text = "Health: " + BaseHP.ToString();
		HPText4.text = "Health: " + BaseHP.ToString();
    }
}
