using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Upgrade))]
public class UpgradeEditor : Editor {

	public SerializedProperty
		uiIcon_Prop,
		bForwardSpeed_Prop,
		forwardSpeedPercent_Prop,
		bMaxHealth_Prop,
		maxHealthPercent_Prop,
		bMaxComponents_Prop,
		componentCount_Prop,
		bMaxLives_Prop,
		lifeCount_Prop,
		bTurningSpeed_Prop,
		turningSpeedPercent_Prop,
		bWeaponDamage_Prop,
		weaponDamagePercent_Prop,
		bAbilityCooldowns_Prop,
		abilityCooldownPercent_Prop,
		bAimZoom_Prop,
		aimZoomValue_Prop,
		bStartingComponent_Prop,
		startingComponent_Prop;

	void OnEnable()
	{
		uiIcon_Prop = serializedObject.FindProperty ("uiIcon");
		bForwardSpeed_Prop = serializedObject.FindProperty ("bForwardSpeed");
		forwardSpeedPercent_Prop = serializedObject.FindProperty ("forwardSpeedPercent");
		bTurningSpeed_Prop = serializedObject.FindProperty ("bTurningSpeed");
		turningSpeedPercent_Prop = serializedObject.FindProperty ("turningSpeedPercent");
		bMaxHealth_Prop = serializedObject.FindProperty ("bMaxHealth");
		maxHealthPercent_Prop = serializedObject.FindProperty ("maxHealthPercent");
		bMaxLives_Prop = serializedObject.FindProperty ("bMaxLives");
		lifeCount_Prop = serializedObject.FindProperty ("lifeCount");
		bMaxComponents_Prop = serializedObject.FindProperty ("bMaxComponents");
		componentCount_Prop = serializedObject.FindProperty ("componentCount");
		bWeaponDamage_Prop = serializedObject.FindProperty ("bWeaponDamage");
		weaponDamagePercent_Prop = serializedObject.FindProperty ("weaponDamagePercent");
		bAbilityCooldowns_Prop = serializedObject.FindProperty ("bAbilityCooldowns");
		abilityCooldownPercent_Prop = serializedObject.FindProperty ("abilityCooldownPercent");
		bAimZoom_Prop = serializedObject.FindProperty ("bAimZoom");
		aimZoomValue_Prop = serializedObject.FindProperty ("aimZoomValue");
		bStartingComponent_Prop = serializedObject.FindProperty ("bStartingComponent");
		startingComponent_Prop = serializedObject.FindProperty ("startingComponent");
	}

	public override void OnInspectorGUI()
	{
		serializedObject.Update ();

		EditorGUILayout.PropertyField (uiIcon_Prop, new GUIContent ("UI Icon"));

		//Forward Speed
		EditorGUILayout.PropertyField (bForwardSpeed_Prop, new GUIContent ("Forward Speed"));
		if(bForwardSpeed_Prop.boolValue)
			EditorGUILayout.PropertyField (forwardSpeedPercent_Prop, new GUIContent ("Forward Speed Percent"));

		//Turning Speed
		EditorGUILayout.PropertyField (bTurningSpeed_Prop, new GUIContent ("Turning Speed"));
		if(bTurningSpeed_Prop.boolValue)
			EditorGUILayout.PropertyField (turningSpeedPercent_Prop, new GUIContent ("Turning Speed Percent"));

		//Max Health
		EditorGUILayout.PropertyField (bMaxHealth_Prop, new GUIContent ("Max Health"));
		if(bMaxHealth_Prop.boolValue)
			EditorGUILayout.PropertyField (maxHealthPercent_Prop, new GUIContent ("Max Health Percent"));

		//Max Lives
		EditorGUILayout.PropertyField (bMaxLives_Prop, new GUIContent ("Max Lives"));
		if(bMaxLives_Prop.boolValue)
			EditorGUILayout.PropertyField (lifeCount_Prop, new GUIContent ("Max Life Count"));

		//Max Components
		EditorGUILayout.PropertyField (bMaxComponents_Prop, new GUIContent ("Max Components"));
		if(bMaxComponents_Prop.boolValue)
			EditorGUILayout.PropertyField (componentCount_Prop, new GUIContent ("Max Component Count"));

		//Weapon Damage
		EditorGUILayout.PropertyField (bWeaponDamage_Prop, new GUIContent ("Weapon Damage"));
		if(bWeaponDamage_Prop.boolValue)
			EditorGUILayout.PropertyField (weaponDamagePercent_Prop, new GUIContent ("Weapon Damage Percent"));

		//Ability Cooldowns
		EditorGUILayout.PropertyField (bAbilityCooldowns_Prop, new GUIContent ("Ability Cooldowns"));
		if(bAbilityCooldowns_Prop.boolValue)
			EditorGUILayout.PropertyField (abilityCooldownPercent_Prop, new GUIContent ("Ability Cooldown Percent"));

		//Aim Zoom
		EditorGUILayout.PropertyField (bAimZoom_Prop, new GUIContent ("Aim Zoom"));
		if(bAimZoom_Prop.boolValue)
			EditorGUILayout.PropertyField (aimZoomValue_Prop, new GUIContent ("Aim Zoom Value"));

		//Starting Component
		EditorGUILayout.PropertyField (bStartingComponent_Prop, new GUIContent ("Starting Component"));
		if(bStartingComponent_Prop.boolValue)
			EditorGUILayout.PropertyField (startingComponent_Prop, new GUIContent ("Starting Component"));

		serializedObject.ApplyModifiedProperties ();
	}
}
