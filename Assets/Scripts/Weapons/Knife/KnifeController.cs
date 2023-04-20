using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class KnifeController : MonoBehaviour
{
    public GameObject knifePrefab;

    public Transform knifePos;

    private bool canShoot;

    private float timer;
    private Transform enemyTransform;

    private void OnEnable()
    {
        WeaponZone.onTriggerStay2DEvents += InWeaponZone;
        WeaponZone.onTriggerExit2DEvents += OutWeaponZone;
    }

    private void OnDisable()
    {
        WeaponZone.onTriggerStay2DEvents -= InWeaponZone;
        WeaponZone.onTriggerExit2DEvents -= OutWeaponZone;
    }

    private void Update()
    {
        if (canShoot)
        {
            timer += Time.deltaTime;

            if (timer > 2)
            {
                timer = 0;

                Shoot();
            }
        }
    }

    private void InWeaponZone(GameObject gameObject)
    {
        if (gameObject.CompareTag("Enemy"))
        {
            canShoot = true;

            enemyTransform = gameObject.transform;
        }
    }

    private void OutWeaponZone(GameObject gameObject)
    {
        if (gameObject.CompareTag("Enemy"))
        {
            canShoot = false;
        }
    }

    private void Shoot()
    {
        // Instantiate(knifePrefab, knifePos.position, Quaternion.identity);
        
        GameObject knife = KnifeObjectPool.instance.GetPoolObject();

        if (knife != null)
        {
            knife.transform.position = knifePos.transform.position;
            knife.gameObject.GetComponent<Knife>().enemy = enemyTransform;
            knife.SetActive(true);
        }
    }
}
