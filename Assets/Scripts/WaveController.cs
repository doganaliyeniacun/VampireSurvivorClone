using TMPro;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public static WaveController instance;

    public int? mobCount;

    public TextMeshProUGUI waveScoreText;

    public int waveScore = 1;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        waveScoreText.text = $"Wave {this.waveScore}";
    }

    private void Update()
    {
        if (mobCount == null)
        {
            mobCount = EnemySpawner.instance._spawnWave;
        }

        if (mobCount <= 0)
        {
            GameObject boss = EnemySpawner.instance.BossSpawn();
            mobCount = EnemySpawner.instance.spawnWave * (waveScore + 1);
            IncrementWave();
        }

        print ("mobCount :" +mobCount);
    }

    public void NextWave(int waveScore)
    {
        WaveText (waveScore);
    }

    private void WaveText(int waveScore)
    {
        this.waveScore += waveScore;
        waveScoreText.text = $"Wave {this.waveScore}";
    }

    private void IncrementWave()
    {
        EnemySpawner.instance._spawnWave =
            EnemySpawner.instance.spawnWave * (waveScore + 1);
    }
}
