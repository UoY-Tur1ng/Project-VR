using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveControl : MonoBehaviour {

    public GameObject[] targets;
    private int RoundNum = 0;
    public Text WaveText;
    public Text VictoryText;

    // Use this for initialization
    void Start () {
        SetWaveText();
        VictoryText.text = "";
    }
	
	// Update is called once per frame
	void Update () {
		if (targets[0].activeSelf == false && targets[1].activeSelf == false && targets[2].activeSelf == false && targets[3].activeSelf == false)
        {
            if (RoundNum < 10)
            {
             
                StartRound();
                RoundNum++;
                SetWaveText();
            }
            else
            {
                VictoryText.text = "YOU SURVIVED!";
            }
        }
	}

    void StartRound()
    {
        if (RoundNum == 0 || RoundNum == 1 || RoundNum == 2 || RoundNum == 3 || RoundNum == 6 || RoundNum == 7 || RoundNum == 8 || RoundNum == 9) targets[0].SetActive(true);
        if (RoundNum == 2 || RoundNum == 4 || RoundNum == 5 || RoundNum == 7 || RoundNum == 8 || RoundNum == 9) targets[1].SetActive(true);
        if (RoundNum == 3 || RoundNum == 4 || RoundNum == 6 || RoundNum == 7 || RoundNum == 8 || RoundNum == 9) targets[2].SetActive(true);
        if (RoundNum == 6 || RoundNum == 5 || RoundNum == 6 || RoundNum == 8 || RoundNum == 9) targets[3].SetActive(true);
    }

    void SetWaveText()
    {
        WaveText.text = "Wave: " + RoundNum.ToString();
    }
}
