using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public float lerpAngle;
    public float lerpSpeed;

    public Vector3 clampAngles;

    public Animator cameraAnim;
    public Animator anims;

    [Space]
    public GameObject playerModel;
    public float barrelRollSpeed;

    public void AnimateMovement(float horizontal, float vertical, bool barrelRoll)
    {
        //     Vector3 mouseMovement = (Input.mousePosition - (new Vector3(Screen.width, Screen.height, 0) / 2.0f)) * 1;
        //    transform.rotation *= Quaternion.Euler(new Vector3(-mouseMovement.y + -lerpAngle, mouseMovement.x + lerpAngle, -mouseMovement.x) * lerpSpeed);

        anims.SetFloat("Horizontal", horizontal);
        anims.SetFloat("Vertical", vertical);

        cameraAnim.SetFloat("Horizontal", horizontal);
        cameraAnim.SetFloat("Vertical", vertical);


        //if (vertical == 0 && horizontal == 0)
        //{
        //    print("jsdas");
        //    playerAnim.Play("PlayerModelIdle");
        //}
        //else if (vertical > 0 && horizontal > 0)
        //{
        //    playerAnim.PlayQueued("PlayerModelUpRight", QueueMode.PlayNow);
        //}
        //else if (vertical > 0 && horizontal < 0)
        //{
        //    playerAnim.PlayQueued("PlayerModelUpLeft", QueueMode.PlayNow);
        //}
        //else if (vertical < 0 && horizontal > 0)
        //{
        //    playerAnim.PlayQueued("PlayerModelDownRight", QueueMode.PlayNow);
        //}
        //else if (vertical < 0 && horizontal < 0)
        //{
        //    playerAnim.PlayQueued("PlayerModelDownLeft", QueueMode.PlayNow);
        //}
        //else if (vertical > 0)
        //{
        //    playerAnim.PlayQueued("PlayerModelUp", QueueMode.PlayNow);
        //}
        //else if (vertical < 0)
        //{
        //    playerAnim.PlayQueued("PlayerModelDown", QueueMode.PlayNow);
        //}
        //else if (horizontal > 0)
        //{
        //    playerAnim.PlayQueued("PlayerModelRight", QueueMode.PlayNow);
        //}
        //else if (horizontal < 0)
        //{
        //    playerAnim.PlayQueued("PlayerModelLeft", QueueMode.PlayNow);
        //}


        // transform.LookAt(Camera.main.ViewportToWorldPoint(Input.mousePosition));

        //if (horizontal > 0)
        //    playerModel.transform.localRotation = Quaternion.Lerp(playerModel.transform.localRotation, Quaternion.Euler(0, 0, -45), barrelRollSpeed * Time.deltaTime);
        //else if (horizontal < 0)
        //    playerModel.transform.localRotation = Quaternion.Lerp(playerModel.transform.localRotation, Quaternion.Euler(0, 0, 45), barrelRollSpeed * Time.deltaTime);
        //else
        //    playerModel.transform.localRotation = Quaternion.Lerp(playerModel.transform.localRotation, Quaternion.identity, 1 * Time.deltaTime);


    }


    //// speed is the rate at which the object will rotate
    //public float speed;

    //void Update()
    //{
    //    // Generate a plane that intersects the transform's position with an upwards normal.
    //    Plane playerPlane = new Plane(-Vector3.forward, transform.position);

    //    // Generate a ray from the cursor position
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    //    // Determine the point where the cursor ray intersects the plane.
    //    // This will be the point that the object must look towards to be looking at the mouse.
    //    // Raycasting to a Plane object only gives us a distance, so we'll have to take the distance,
    //    //   then find the point along that ray that meets that distance.  This will be the point
    //    //   to look at.
    //    float hitdist = 100f;
    //    // If the ray is parallel to the plane, Raycast will return false.
    //    if (playerPlane.Raycast(ray, out hitdist))
    //    {
    //        // Get the point along the ray that hits the calculated distance.
    //        Vector3 targetPoint = ray.GetPoint(hitdist);

    //        // Determine the target rotation.  This is the rotation if the transform looks at the target point.
    //        Quaternion targetRotation = Quaternion.LookRotation(targetPoint - new Vector3(transform.position.x, 0, transform.position.z));

    //        // Smoothly rotate towards the target point.
    //        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
    //    }
    //}
}
