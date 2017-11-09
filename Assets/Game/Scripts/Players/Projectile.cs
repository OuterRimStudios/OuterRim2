using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed;

    Rigidbody rb;
    Vector3 target;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 1);

        target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100));
    }

	void Update ()
    {
        transform.LookAt(target);
        rb.velocity = transform.forward * projectileSpeed;
    }
}
