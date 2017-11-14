using System.Collections;
using UnityEngine;

public abstract class Weapon : ScriptableObject {

	public string wName = "New Weapon";
	public AudioClip fireSound;
	public float wBaseCooldown = 1f;
	public int wBaseDamage;

	public abstract void Initialize (GameObject[] objs);
	public abstract void FireWeapon();
}