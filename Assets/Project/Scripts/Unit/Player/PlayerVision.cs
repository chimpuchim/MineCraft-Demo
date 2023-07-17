using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVision : GameManager, IVision
{
    [Header("Set up player vision")]
        [SerializeField] private float mouseSensitivity;
        [SerializeField] private float maxVision;

    private float xRotation;


    protected override void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() 
    {
        Vision();
    }

    protected override void LoadComponents()
    {
        loadValues();
    }

    private void loadValues()
    {
        mouseSensitivity = 100;
        maxVision = 90;
    }

    public void Vision()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -maxVision, maxVision);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        this.transform.parent.Rotate(Vector3.up * mouseX);
    }
}
