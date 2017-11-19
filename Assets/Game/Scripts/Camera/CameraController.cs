using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 cameraOffset;
    public Vector3 aimPosition;
   
    public float followSpeed;

    [Space, Header("Positions")]
    public Vector3 upPosition;
    public Vector3 downPosition;
    public Vector3 leftPosition;
    public Vector3 rightPosition;

    [Space, Header("Rotations")]
    public Quaternion upRotation;
    public Quaternion downRotation;
    public Quaternion leftRotation;
    public Quaternion rightRotation;

    Transform target;

    private void Start()
    {
        target = transform.root;
        transform.parent = null;
    }

    public void UpdateCameraPosition(float horizontal, float vertical)
    {
        //if(vertical > 0)
        //{
        //    transform.position = Vector3.Lerp(transform.position, target.transform.position + upPosition, followSpeed * Time.deltaTime);
        //    transform.rotation = Quaternion.Lerp(transform.rotation, upRotation, followSpeed * Time.deltaTime);
        //}
        //else
        //if (vertical < 0)
        //{
        //    transform.position = Vector3.Lerp(transform.position, target.transform.position + downPosition, followSpeed * Time.deltaTime);
        //    transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, followSpeed * Time.deltaTime);
        //}

        //if (horizontal < 0)
        //{
        //    transform.position = Vector3.Lerp(transform.position, target.transform.position + leftPosition, followSpeed * Time.deltaTime);
        //    transform.rotation = Quaternion.Lerp(transform.rotation, leftRotation, followSpeed * Time.deltaTime);
        //}
        //else
        //if (horizontal > 0)
        //{
        //    transform.position = Vector3.Lerp(transform.position, target.transform.position + rightPosition, followSpeed * Time.deltaTime);
        //    transform.rotation = Quaternion.Lerp(transform.rotation, rightRotation, followSpeed * Time.deltaTime);
        //}

    }

    public void SetNormalCameraPosition()
    {
        transform.position = Vector3.Slerp(transform.position, target.transform.position + cameraOffset, followSpeed * Time.fixedDeltaTime);
    }

    public void SetAimCameraPosition()
    {
        transform.position = Vector3.Slerp(transform.position, target.transform.position + aimPosition, followSpeed* Time.fixedDeltaTime);
    }
}
