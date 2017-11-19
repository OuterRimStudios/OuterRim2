using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public GameObject gun1;
    public GameObject gun2;
    public Transform aimPosition;

    public GameObject laser;

    public float fireFrequency;

    bool isFiring;

    public void Fire()
    {

        if (!isFiring)
        {
            isFiring = true;

            GameObject laser1 = Instantiate(laser, gun1.transform.position, gun1.transform.rotation);
            GameObject laser2 = Instantiate(laser, gun2.transform.position, gun2.transform.rotation);

            StartCoroutine(FireFrequency());
        }

    }

    IEnumerator FireFrequency()
    {
        yield return new WaitForSeconds(fireFrequency);
        isFiring = false;
    }
}
