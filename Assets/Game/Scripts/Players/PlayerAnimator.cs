using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public float lerpAngle;
    public float lerpSpeed;

    public void AnimateMovement()
    {
        Vector3 mouseMovement = (Input.mousePosition - (new Vector3(Screen.width, Screen.height, 0) / 2.0f)) * 1;
        transform.rotation = Quaternion.Euler(new Vector3(-mouseMovement.y, mouseMovement.x, -mouseMovement.x) * lerpSpeed);
    }
}
