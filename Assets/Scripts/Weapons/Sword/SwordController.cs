using UnityEngine;


public class SwordController : MonoBehaviour
{
    [SerializeField]
    private GameObject swordPos;

    [SerializeField]
    private float swordCooldown = 5f;

    [SerializeField]
    private float rotateSpeed = 500f;

    private float timer = 0f;

    

    private void Update()
    {
        SwordRotation();
    }

    private void SwordRotation()
    {
        timer += Time.deltaTime;

        if (timer < swordCooldown)
        {
            swordPos.SetActive(false);
        }
        else if (timer > swordCooldown)
        {
            swordPos.SetActive(true);
            swordPos.transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        }

        if (timer > swordCooldown * 2)
        {
            timer = 0;
        }
    }
}
