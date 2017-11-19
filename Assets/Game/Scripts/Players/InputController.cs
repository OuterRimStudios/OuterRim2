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

    private void Awake()
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

        //cameraController.UpdateCameraPosition(controls.Look.X, controls.Look.Y);
        playerController.Move(controls.Move.X);
        

        playerAnimator.AnimateMovement(Input.mousePosition.x / 100, Input.mousePosition.y / 100, true);


        if (controls.Sprint)
            playerController.SuperSpeed();
        else if (controls.Move.Y > 0)
            playerController.FullSpeed();
        else if (controls.Move.Y < 0)
            playerController.ResetSpeed();

        if (controls.Fire)
            playerWeapon.Fire();

        if (controls.Aim)
            cameraController.SetAimCameraPosition();
        else
            cameraController.SetNormalCameraPosition();
    }
}
