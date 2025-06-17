using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 1.0f;
    [SerializeField]
    private float mouseXSensitivity = 1.0f;
    [SerializeField]
    private float mouseYSensitivity = 1.0f;

    [SerializeField]
    private Camera playerCamera;
    private CharacterController characterController;
    private Transform playerTransform;

    private float currentCameraPitch = 0.0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        characterController = GetComponent<CharacterController>();
        playerTransform = transform;
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 inputDir = new Vector3(
            Input.GetAxis("Horizontal"),
            0.0f,
            Input.GetAxis("Vertical")
            );

        // Normalize the input direction to prevent moving faster when going diagonals
        //inputDir.Normalize();
        inputDir = Vector3.ClampMagnitude(inputDir, 1.0f);
        Quaternion rot = transform.rotation;

        inputDir = rot * inputDir;
        inputDir.y = 0.0f;
        characterController.Move(inputDir *  movementSpeed * Time.deltaTime);

        // Mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseXSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseYSensitivity * Time.deltaTime;
        currentCameraPitch -= mouseY;
        currentCameraPitch = Mathf.Clamp(currentCameraPitch, -89.0f, 89.0f);

        // Rotate the player
        transform.Rotate(Vector3.up, mouseX);

        // Rotate the camera
        playerCamera.transform.localRotation = Quaternion.Euler(currentCameraPitch, 0.0f, 0.0f);
    }
}
