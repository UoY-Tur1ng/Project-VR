using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseCollider : MonoBehaviour {

    public int BaseHP;
    public Text HPText;
    public Text GameOverText;

    private void Start()
    {
        SetHPText();
        GameOverText.text = "";
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
        GameOverText.text = "GAME OVER";
    }

    void SetHPText()
    {
        HPText.text = "Health: " + BaseHP.ToString();
    }
}
