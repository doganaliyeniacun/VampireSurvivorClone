using System;
using System.Threading;
using UnityEngine;

public class HealtBarController : MonoBehaviour
{
    private Healt[] healts;

    private bool needHealt = false;

    private void OnEnable()
    {
        HealtManager.decrementHealt += DecrementHealt;
        HealtManager.incrementHealt += IncrementHealt;
        HealtManager.needHealt += NeedHealt;
        HealtManager.isDie += Die;
    }

    private void OnDisable()
    {
        HealtManager.decrementHealt -= DecrementHealt;
        HealtManager.incrementHealt -= IncrementHealt;
        HealtManager.needHealt -= NeedHealt;
        HealtManager.isDie -= Die;
    }

    // Start is called before the first frame update
    private void Start()
    {
        healts = GetComponentsInChildren<Healt>();
    }

    private bool NeedHealt() => needHealt;

    private void IncrementHealt()
    {
        int activeHealtCount = 0;

        for (int i = 0; i < healts.Length; i++)
        {
            if (healts[i].healtStatus == false)
            {
                healts[i].healtStatus = true;
                return;
            }

            if (healts[i].healtStatus == true)
            {
                activeHealtCount++;
            }
        }

        if (activeHealtCount == healts.Length)
        {
            needHealt = false;
        }
    }

    private void DecrementHealt()
    {
        for (int i = healts.Length - 1; i > -1; i--)
        {
            if (healts[i].healtStatus == true)
            {
                needHealt = true;
                healts[i].healtStatus = false;
                return;
            }
        }
    }

    private bool Die()
    {
        int dectiveHealtCount = 0;

        for (int i = 0; i < healts.Length; i++)
        {
            if (healts[i].healtStatus == false)
            {
                dectiveHealtCount++;
            }
        }

        if (dectiveHealtCount == healts.Length)
        {
            return true;
        }

        return false;
    }
}
