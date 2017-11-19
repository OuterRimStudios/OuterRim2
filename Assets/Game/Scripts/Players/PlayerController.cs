using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Variables")]
    public float baseSpeed;
    public float fullSpeed;

    public float superSpeed;

    public float speedIncreaseAmount;
    public float speedDecreaseAmount;
    public float speedChangeFrequency;

    public Vector3 superSpeedCameraOffset;
    public float FoVLerp;

    public float barrelRollSpeed;
    float rollSpeed;

    [Space, Header("")]
    public int clampValue;

    public GameObject playerModel;

    float speed;
    Vector3 movement;
    Rigidbody rigidBody;
    Camera myCamera;
    CameraController cameraController;

    bool changingSpeed;

    Vector3 cameraOriginalOffset;

    private void Awake()
    {
        myCamera = GetComponentInChildren<Camera>();
        cameraController = myCamera.GetComponent<CameraController>();
       // cameraOriginalOffset = cameraController.cameraOffset;

        rigidBody = GetComponent<Rigidbody>();
        ResetSpeed();
    }

    public void Move(float horizontal)
    {
        rigidBody.velocity = playerModel.transform.forward * speed * Time.deltaTime;
        Clamp();
    }

    void Clamp()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -clampValue, clampValue), 
            Mathf.Clamp(transform.position.y, -clampValue, clampValue), transform.position.z);
    }

    public void FullSpeed() 
    {
        if(!changingSpeed)
        {
            changingSpeed = true;

            speed += speedIncreaseAmount;

            if (speed > fullSpeed)
                speed = fullSpeed;

            StartCoroutine(SpeedChangeFrequency());
        }

        myCamera.fieldOfView = Mathf.Lerp(myCamera.fieldOfView, 60, FoVLerp * .01f * Time.deltaTime);

        if (myCamera.fieldOfView < 60)
            myCamera.fieldOfView = 60;
    }

    public void ResetSpeed()
    {
        if (!changingSpeed)
        {
            changingSpeed = true;

            speed -= speedDecreaseAmount;

            if (speed < baseSpeed)
                speed = baseSpeed;
            StartCoroutine(SpeedChangeFrequency());
        }

        myCamera.fieldOfView = Mathf.Lerp(myCamera.fieldOfView, 70, FoVLerp * .01f * Time.deltaTime);

        if (myCamera.fieldOfView > 70)
            myCamera.fieldOfView = 70;
    }

    IEnumerator SpeedChangeFrequency()
    {
        yield return new WaitForSeconds(speedChangeFrequency);
        changingSpeed = false;
    }

    public void SuperSpeed()
    {
        speed = superSpeed;

        myCamera.fieldOfView = Mathf.Lerp(myCamera.fieldOfView, 40, FoVLerp * Time.deltaTime);
        cameraController.cameraOffset = superSpeedCameraOffset;

        if (myCamera.fieldOfView > 40)
            myCamera.fieldOfView = 90;
    }
}
