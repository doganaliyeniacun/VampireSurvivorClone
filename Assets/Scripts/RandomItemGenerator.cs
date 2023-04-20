using UnityEngine;

public class RandomItemGenerator : MonoBehaviour
{
    public GameObject[] items;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            RandomItemGenerate();
        }
    }

    private void RandomItemGenerate()
    {
        if (items.Length != 0)
        {
            int randomValue = Random.Range(0, items.Length);

            Instantiate(items[randomValue],
            transform.position,
            Quaternion.identity);

            Destroy (gameObject);
        }
    }
}
