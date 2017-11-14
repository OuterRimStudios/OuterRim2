using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShootTriggerable : MonoBehaviour {

	[HideInInspector]
	public Rigidbody projectile;
	public Transform projectileSpawn;
	[HideInInspector]
	public float projectileForce = 250f;

	public void Fire()
	{
		Rigidbody projectileClone = Instantiate (projectile, projectileSpawn.position, transform.rotation) as Rigidbody;
	}
}
