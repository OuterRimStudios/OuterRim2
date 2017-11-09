using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    #region InControl

    Controls controls;
    string saveData;

    void OnEnable()
    {
        controls = Controls.CreateWithDefaultBindings();
    }

    void OnDisable()
    {
        controls.Destroy();
    }

    void SaveBindings()
    {
        saveData = controls.Save();
        PlayerPrefs.SetString("Bindings", saveData);
    }

    void LoadBindings()
    {
        if (PlayerPrefs.HasKey("Bindings"))
        {
            saveData = PlayerPrefs.GetString("Bindings");
            controls.Load(saveData);
        }
    }
    #endregion

    public bool hideCursor;

    CameraController cameraController;
    PlayerController playerController;
    PlayerAnimator playerAnimator;
    PlayerWeapon playerWeapon;

    private void Start()
    {
        cameraController = GetComponentInChildren<CameraController>();
        playerController = GetComponent<PlayerController>();
        playerAnimator = GetComponent<PlayerAnimator>();
        playerWeapon = GetComponent<PlayerWeapon>();

        if(hideCursor)
        {
            Cursor.visible = false;
        }
    }

    private void Update()
    {
        playerController.Move();
        playerAnimator.AnimateMovement();

        if (controls.Move.Y > 0)
            playerController.FullSpeed();
        else if (controls.Move.Y < 0)
            playerController.ResetSpeed();

        if (controls.Fire)
            playerWeapon.Fire();
    }
}
