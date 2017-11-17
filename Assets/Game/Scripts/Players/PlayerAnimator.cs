using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public float lerpAngle;
    public float lerpSpeed;

    public Vector3 clampAngles;

    [Space]
    public GameObject playerModel;
    public float barrelRollSpeed;

    public void AnimateMovement(float horizontal, bool barrelRoll)
    {

        if (!barrelRoll)
        {
            Vector3 mouseMovement = (Input.mousePosition - (new Vector3(Screen.width, Screen.height, 0) / 2.0f)) * 1;
            transform.rotation = Quaternion.Euler(new Vector3(-mouseMovement.y + -lerpAngle, mouseMovement.x + lerpAngle, -mouseMovement.x) * lerpSpeed);

            if (playerModel.transform.localRotation != Quaternion.identity)
            {
                playerModel.transform.localRotation = Quaternion.Lerp(playerModel.transform.localRotation, Quaternion.identity, 1 * Time.deltaTime);
            }
        }
        else
        {
            if (horizontal > 0 || horizontal < 0)
                playerModel.transform.Rotate(new Vector3(0,0,   -horizontal * barrelRollSpeed * Time.deltaTime));
            else
                playerModel.transform.Rotate(new Vector3(0,0, (-horizontal * barrelRollSpeed * .5f) * Time.deltaTime));
        }

    }
}
