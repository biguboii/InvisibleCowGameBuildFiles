using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_View : MonoBehaviour
{
    /* Mouse X and Y settings with sensitivity */
    [SerializeField] private string mouseXInputEntry, mouseYInputEntry;
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private Transform playerBody;
    private float xAxisLimit;

    private void Awake()
    {
        LockCursor(); /* esc to unlock, click screen to re-lock */
        mouseXInputEntry = "Mouse X";
        mouseYInputEntry = "Mouse Y";
        mouseSensitivity = 150.0f; /* Maybe have adjustable through UI */
        xAxisLimit = 0.0f;
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    private void Update()
    {
        CameraMovement();
    }

    private void CameraMovement()
    {
        float mouseXInput = Input.GetAxis(mouseXInputEntry) * mouseSensitivity * Time.deltaTime;
        float mouseYInput = Input.GetAxis(mouseYInputEntry) * mouseSensitivity * Time.deltaTime;

        xAxisLimit += mouseYInput;

        if(xAxisLimit > 90.0f)/* Prevents player from doing a 360 when looking up or down. */
        {
            xAxisLimit = 90.0f;
            mouseYInput = 0.0f;
            LimitXAxisRotationToValue(270.0f);
        }
        else if (xAxisLimit < -90.0f)
        {
            xAxisLimit = -90.0f;
            mouseYInput = 0.0f;
            LimitXAxisRotationToValue(90.0f);
        }

        transform.Rotate(Vector3.left * mouseYInput);
        playerBody.Rotate(Vector3.up * mouseXInput);
    }

    private void LimitXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }
}
