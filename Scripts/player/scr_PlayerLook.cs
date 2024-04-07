using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class scr_Player : MonoBehaviour
{
    #region Properties
    Camera _plaCamera;                                  // Player Camera

    [Header("Mouse Options")]
    [SerializeField] float _plaMouseX = 1f;             // X Look Mouse Sensitivity
    [SerializeField] float _plaMouseY = 1f;             // Y Look Mouse Sensitivity

    [SerializeField] float _plaCameraClamp = 90f;       // Camera Rotation Clamp

    bool _plaInvertX = false;                           // Invert X Look Boolean
    bool _plaInvertY = true;                            // Invert Y Look Boolean

    float _plaYLook;
    #endregion

    // Start is called before the first frame update
    void StartLook()
    {
        // Get player camera
        _plaCamera = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void UpdateLook()
    {
        // Get player look on the X axis
        GetLookX();

        // Get player look on the Y axis
        GetLookY();
    }

    void GetLookX()
    {
        // Get look on X axis using delta and sensitivity
        float lookX = (!_plaInvertX) ? _plaLookInput.x * _plaMouseX : -_plaLookInput.x * _plaMouseX;

        // Turn controller sideways
        transform.Rotate(lookX * Vector3.up);
    }

    void GetLookY()
    {
        // Code Modified from Brackey's FPS Controller (https://youtu.be/_QajrabyTJc?si=NQ0-tVtGhx2XAab8)

        // Get look on Y axis using delta and sensitivity
        float lookY = (!_plaInvertY)? _plaLookInput.y * _plaMouseY : -_plaLookInput.y * _plaMouseY ;

        // Add Y look to Player Y Look
        _plaYLook += lookY;

        // Clamp rotation
        _plaYLook = Mathf.Clamp(_plaYLook, -_plaCameraClamp, _plaCameraClamp);

        // Turn camera up/down
        _plaCamera.transform.localRotation = Quaternion.Euler(_plaYLook, 0f, 0f);
    }
}
