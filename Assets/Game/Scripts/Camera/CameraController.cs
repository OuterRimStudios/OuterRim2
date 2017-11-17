using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 cameraOffset;
    public float followSpeed;

    Transform target;

    private void Start()
    {
        target = transform.root;
        transform.parent = null;
    }

    void LateUpdate ()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position + cameraOffset, followSpeed * Time.fixedDeltaTime);
	}
}
