using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public WeaponDataSO weaponData;

    public AudioSource audioSource;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            audioSource.Play();

            other.gameObject.GetComponent<Enemy>().Healt -= weaponData.damage;
        }
    }
}
