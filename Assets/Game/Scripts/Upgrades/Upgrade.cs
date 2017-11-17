using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrade")]
public class Upgrade : ScriptableObject {

	public Sprite uiIcon;
	public bool bForwardSpeed;
	public float forwardSpeedPercent;
	public bool bMaxHealth;
	public float maxHealthPercent;
	public bool bMaxComponents;
	public int componentCount;
	public bool bMaxLives;
	public int lifeCount;
	public bool bTurningSpeed;
	public float turningSpeedPercent;
	public bool bWeaponDamage;
	public float weaponDamagePercent;
	public bool bAbilityCooldowns;
	public float abilityCooldownPercent;
	public bool bAimZoom;
	public float aimZoomValue;
	public bool bStartingComponent;
	public ShipComponent startingComponent;

}