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

    private void Start()
    {
        System.Random rand = new System.Random();

        //while (NPCsAlive < Clone.Length)
        for(int i = 0; i<Clone.Length;i++)
        {
            //int SpawnRand = rand.Next(0, 100000);
            //if (SpawnRand < SpawnRate)
            //{
                Spawn(i, 0, SpawnLocs[rand.Next(0, 3)]);
                //NPCsAlive += 1;
            //}


        }
    }

    
    void Spawn(int CloneIndex, int PrefabIndex, Transform Location)
    {
        Clone[CloneIndex] = Instantiate(Prefab[PrefabIndex], Location.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
    }
}
