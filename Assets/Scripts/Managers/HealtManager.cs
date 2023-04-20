using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealtManager : MonoBehaviour
{
    public static event Action decrementHealt;

    public static event Action incrementHealt;

    public static event Func<bool> isDie;

    public static event Func<bool> needHealt;

    float timer = 0;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            timer += 0.1f;
            if (timer > 1)
            {
                decrementHealt?.Invoke();
                timer = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Healt") && (bool)(needHealt?.Invoke()))
        {
            incrementHealt?.Invoke();

            Destroy(other.gameObject);
        }
    }

    private void Update()
    {
        bool? _isDie = isDie?.Invoke();

        if ((bool) _isDie)
        {
            SceneManagement.instance.ChangeScene(Scenes.LEVEL1);
        }
    }
}
