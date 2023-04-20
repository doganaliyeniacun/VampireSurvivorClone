using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    CharacterDataSO enemyData;

    private float healt;

    public bool boss;

    private void Start()
    {
        if (boss)
        {
            healt = enemyData.Health * (WaveController.instance.waveScore + Random.Range(3,6));
            print($"Boss healt : {healt}");
        }
        else
        {
            healt = enemyData.Health;
        }
    }

    public float Healt
    {
        get
        {
            return healt;
        }
        set
        {
            healt = value;

            if (healt <= 0)
            {
                gameObject.SetActive(false);
                healt = enemyData.Health;

                if (boss)
                {
                    EnemySpawner.instance.StartCoroutine("EnemySpawn");
                    WaveController.instance.NextWave(1);
                }
                else
                {
                    WaveController.instance.mobCount -= 1;
                }
            }
        }
    }
}
