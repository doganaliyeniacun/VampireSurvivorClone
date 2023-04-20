using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField]
    Transform playerPos;

    [SerializeField]
    GameObject[] itemPrefabs;

    [SerializeField]
    float secondSpawn = 0.5f;

    [SerializeField]
    private Vector2

            minSize,
            maxSize;

    [SerializeField]
    int spawnWave = 10;

    private void Start()
    {
        StartCoroutine(ItemSpawn());
    }

    private IEnumerator ItemSpawn()
    {
        while (0 < spawnWave)
        {
        
            int item = Random.Range(0, itemPrefabs.Length);

            Vector2 position =
                new Vector3(Random.Range(-minSize.x, maxSize.x),
                    Random.Range(-minSize.y, maxSize.y));

            Instantiate(itemPrefabs[item], position, Quaternion.identity);

            --spawnWave;

            yield return new WaitForSeconds(secondSpawn);
        }
    }
}
