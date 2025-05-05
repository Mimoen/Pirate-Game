using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public List<GameObject> pooledObjects;
    public GameObject prefab; // Vad som finns i poolen.
    public int amountToPool; // Hur många objekt som finns i poolen.

    public static ObjectPool instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject temp;
        for (int i = 0; i < amountToPool; i++)
        {
            temp = Instantiate(prefab);
            temp.SetActive(false);
            pooledObjects.Add(temp);
        }
    }

    void Update()
    {

    }

    public GameObject GetPooledObject(Vector3 position, Quaternion rotation)
    {
        for (int i = 0; i < pooledObjects.Count; i++) // Create and turn off initial prefabs
        {
            if (pooledObjects[i].activeInHierarchy == false) // Looks for inactive prefabs
            {
                pooledObjects[i].transform.position = position;
                pooledObjects[i].transform.rotation = rotation;
                pooledObjects[i].SetActive(true);
                return pooledObjects[i];
                // Turns on and places bullets in front of ship
            }
        }
        GameObject temp = Instantiate(prefab);
        temp.transform.position = position;
        temp.transform.rotation = rotation;
        pooledObjects.Add(temp);
        return temp;
        // Creates and turns off bullets if more are needed
    }
}
