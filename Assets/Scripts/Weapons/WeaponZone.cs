using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZone : MonoBehaviour
{
    public static event Action<GameObject> onTriggerStay2DEvents;

    public static event Action<GameObject> onTriggerExit2DEvents;

    private void OnTriggerStay2D(Collider2D other)
    {
        onTriggerStay2DEvents?.Invoke(other.gameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        onTriggerExit2DEvents?.Invoke(other.gameObject);
    }
}
