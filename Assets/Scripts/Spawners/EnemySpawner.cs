using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;

    [SerializeField]
    Transform playerPos;

    [SerializeField]
    float

            secondSpawn = 0.5f,
            nextLevelCooldown = 5;

    [SerializeField]
    private Vector2

            minSize,
            maxSize;

    [SerializeField]
    int

            minGroupSize = 3,
            maxGroupSize = 6;

    public int _spawnWave { get; set; }

    [SerializeField]
    public int spawnWave = 10;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        _spawnWave = spawnWave;
    }

    private void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    private IEnumerator EnemySpawn()
    {
        while (0 <= _spawnWave)
        {
            int enemyGroupSize = Random.Range(minGroupSize, maxGroupSize);

            Vector2 position =
                new Vector3(Random.Range(-minSize.x, maxSize.x),
                    Random.Range(-minSize.y, maxSize.y));

            GameObject enemy = EnemyObjectPool.instance.GetPoolObject();
            if (enemy != null)
            {
                enemy.transform.position = position;
                enemy.SetActive(true);
            }

            _spawnWave--;

            print("spawnWave " + _spawnWave);

            yield return new WaitForSeconds(secondSpawn);
        }
    }

    public GameObject BossSpawn()
    {
        GameObject boss = BossObjectPool.instance.GetPoolObject();
        Vector2 position =
            new Vector3(Random.Range(-minSize.x, maxSize.x),
                Random.Range(-minSize.y, maxSize.y));

        if (boss != null)
        {
            print("boss spawned");
            boss.transform.position = position;
            boss.SetActive(true);

            return boss;
        }
        return null;
    }
}
