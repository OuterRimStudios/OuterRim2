using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCoolDown : MonoBehaviour {

	[SerializeField]
	Weapon weapon;
	[SerializeField]
	GameObject[] weaponHolder;

	public List<AudioSource> weaponSources;
	float coolDownDuration;
	float nextReadyTime;
	float coolDownTimeLeft;

	void Start () {
		Initialize (weapon, weaponHolder);
	}

	public void Fire () {
		bool coolDownComplete = (Time.time > nextReadyTime);

		if (coolDownComplete)
			ButtonTriggered ();
		else
			CoolDown ();
	}

	public void Initialize(Weapon selectedWeapon, GameObject[] weaponHolder)
	{
		weapon = selectedWeapon;
		foreach (GameObject weapon in weaponHolder)
			weaponSources.Add (weapon.GetComponent<AudioSource> ());
		coolDownDuration = weapon.wBaseCooldown;
		weapon.Initialize (weaponHolder);
	}

	void CoolDown()
	{
		coolDownTimeLeft -= Time.deltaTime;
	}
	
	void ButtonTriggered()
	{
		nextReadyTime = coolDownDuration + Time.time;
		coolDownTimeLeft = coolDownDuration;

		foreach (AudioSource source in weaponSources) 
		{
			source.clip = weapon.fireSound;
			source.Play ();
		}

		weapon.FireWeapon ();
	}
}
