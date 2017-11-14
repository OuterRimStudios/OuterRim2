﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform target;

	void Update ()
    {
        if(target != null)
            transform.LookAt(target);
	}

    public void SetLookAtTarget(Transform newTarget)
    {
        target = newTarget;
    }
}