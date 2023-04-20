using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeObjectPool : MonoBehaviour
{
    public static KnifeObjectPool instance;

    private List<GameObject> pooledObjects = new List<GameObject>();

    public int poolAmount = 20;

    [SerializeField]
    private GameObject objectPrefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        for (int i = 0; i < poolAmount; i++)
        {
            GameObject obj = Instantiate(objectPrefab);
            obj.SetActive(false);
            pooledObjects.Add (obj);
        }
    }

    public GameObject GetPoolObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
