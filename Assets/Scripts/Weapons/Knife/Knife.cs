using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using Unity.VisualScripting;

public class Knife : MonoBehaviour
{
    public Transform enemy { get; set; }

    private Transform playerPos;

    private Rigidbody2D rb;

    public float

            force = 5f,
            distanceBetween = 10;

    public WeaponDataSO WeaponData;

    public GameObject poolObject { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        WeaponDistance();
        WeaponMovement();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().Healt -= WeaponData.damage;

            gameObject.SetActive(false);
        }
    }

    private void WeaponMovement()
    {
        Vector3 direction = enemy.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    private void WeaponDistance()
    {
        float distance =
            Vector2.Distance(transform.position, playerPos.transform.position);

        if (distance > distanceBetween)
        {
            gameObject.SetActive(false);
        }
    }
}
