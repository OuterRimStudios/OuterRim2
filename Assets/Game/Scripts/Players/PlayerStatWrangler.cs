using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatWrangler : MonoBehaviour {

	/*
	 * This script should:
	 *	- grab the list of selected upgrades
	 *	- cycle through the upgrades and send the stat changes to the necessary scripts
	 */

	public List<Upgrade> activeUpgrades;

	// Use this for initialization
	void Start () {
		foreach(Upgrade upgrade in activeUpgrades)
		{
			print(upgrade.name + '\n' +
				"ability cooldown percent: " + upgrade.abilityCooldownPercent + '\n' +
				"aim zoom value: " + upgrade.aimZoomValue + '\n' +
				"component count: " + upgrade.componentCount + '\n' +
				"forward speed percent: " + upgrade.forwardSpeedPercent + '\n' +
				"life count: " + upgrade.lifeCount + '\n' +
				"max health percent: " + upgrade.maxHealthPercent + '\n' +
				"turning speed percent: " + upgrade.turningSpeedPercent + '\n' +
				"weapon damage percent: " + upgrade.weaponDamagePercent);
		}
	}
}
