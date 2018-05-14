using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public Transform[] SpawnLocs;
    public GameObject[] Prefab;
    public GameObject[] Clone;
    public int WaveSize;
    private int CloneNum;

    private void Start()
    {
        StartWave();
    }

    private void OnEnable()
    {
        StartWave();
    }

    void StartWave()
    {
        WaveSize = 10;
        System.Random rand = new System.Random((int)Time.time);
        float spawnTime = rand.Next(4, 5);

        InvokeRepeating("Spawn", spawnTime + 3, spawnTime);
    }

    void Spawn()
    {
        WaveSize--;
        int spawnPointIndex = Random.Range(0, SpawnLocs.Length);
        Transform Location = SpawnLocs[spawnPointIndex];
        System.Random rand = new System.Random();
        CloneNum = rand.Next(1, 2);
        Clone[0] = Instantiate(Prefab[CloneNum], Location.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        Clone[0].transform.parent = gameObject.transform;
        if (WaveSize == 0)
        {
            CancelInvoke("Spawn");
        }

    }

    void Update()
    {
        if (WaveSize == 0 && WaveDead() == true)
        {
            gameObject.SetActive(false);
        }
    }

    bool WaveDead()
    {
        if (this.transform.childCount == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
}


