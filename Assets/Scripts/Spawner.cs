using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    //[System.Serializable]
    //public class Wave
    //{
    //    public string name;
    //    public int number;

    //    public int Spawncount;
    //    public float Spawnrate;
    //}

    //public Wave waves;
    //public int nextWave = 0;
    //public int numWaves;

    //public int NPCsAlive = 0;
    //public int SpawnRate = 10;

    public Transform[] SpawnLocs;
    public GameObject[] Prefab;
    public GameObject[] Clone;
    private int WaveSize;

    private void Start()
    {
        WaveSize = 10;
        System.Random rand = new System.Random();

        float spawnTime = rand.Next(1, 4);
        InvokeRepeating("Spawn", spawnTime+4, spawnTime);
    }

    private void OnEnable()
    {
        WaveSize = 10;
        System.Random rand = new System.Random();

        float spawnTime = rand.Next(1, 4);
        InvokeRepeating("Spawn", spawnTime + 5, spawnTime);
    }


    void Spawn()
    {
        WaveSize--;
        int spawnPointIndex = Random.Range(0, SpawnLocs.Length);
        Transform Location = SpawnLocs[spawnPointIndex];
        Clone[0] = Instantiate(Prefab[0], Location.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        if (WaveSize == 0)
        {
            CancelInvoke("Spawn");
            gameObject.SetActive(false);
        }
    }
}
