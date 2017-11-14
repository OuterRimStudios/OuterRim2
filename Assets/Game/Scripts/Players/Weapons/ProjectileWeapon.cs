using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/ProjectileWeapon")]
public class ProjectileWeapon : Weapon {

	public float projectileForce = 500f;
	public Rigidbody projectile;

	private ProjectileShootTriggerable[] guns;

	public override void Initialize(GameObject[] objs)
	{
		guns = new ProjectileShootTriggerable[objs.Length];
		for (int i = 0; i < objs.Length; i++) 
		{
			guns[i] = objs[i].GetComponent<ProjectileShootTriggerable> ();
			guns[i].projectileForce = projectileForce;
			guns[i].projectile = projectile;
		}
	}

	public override void FireWeapon()
	{
		foreach(ProjectileShootTriggerable gun in guns)
			gun.Fire ();
	}
}
