using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Variables")]
    public float baseSpeed;
    public float fullSpeed;
    public float speedIncreaseAmount;
    public float speedDecreaseAmount;
    public float speedChangeFrequency;
    public float FoVLerp;

    [Space, Header("")]
    public int clampValue;

    float speed;
    Vector3 movement;
    Rigidbody rigidBody;
    Camera myCamera;

    bool changingSpeed;


    private void Awake()
    {
        myCamera = GetComponentInChildren<Camera>();
    }

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        ResetSpeed();
    }

    public void Move()
    {
        rigidBody.velocity = transform.forward * speed * Time.deltaTime;
        Clamp();
    }

    public void Dodge(float horizontal)
    {
        transform.Rotate(horizontal * 50 * Time.deltaTime, 0, 0);
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
}
