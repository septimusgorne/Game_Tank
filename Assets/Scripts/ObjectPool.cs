using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
  [System.Serializable]
  public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    //----for Singletone
    public static ObjectPool Instance;
    //static accept get throw class , no object!

    public void Awake()
    {
        Instance = this;
        //Instance who this script!(Singletone)
    }

    //-----for Singletone

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDict;
    private void Start()
    {
        poolDict = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
                //add Queue
            }
            poolDict.Add(pool.tag, objectPool);
            //add Dictionary
        }
    }
    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if(!poolDict.ContainsKey(tag))
        //if tag no Dictionary
            return null;
        //return null for return GameObject

        GameObject objectToSpawn = poolDict[tag].Dequeue();
        //delete Queue and add objectToSpawn
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        //position and rotation

        poolDict[tag].Enqueue(objectToSpawn);
        //return Queue

        return objectToSpawn;
        //return object SPAWN
    }
}
