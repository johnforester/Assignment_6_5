using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject objectToFollow;

    [SerializeField] float mouseSensitivity = 10f;

    private float yRotation = 0f;
    private bool isRotating = false;

    private void Start()
    {
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        transform.position = objectToFollow.gameObject.transform.position;
    }

    public void OnEnableRotateCamera(InputValue value)
    {
        float isHolding = value.Get<float>();
        isRotating = isHolding > 0;
    }

    public void OnRotateCamera(InputValue value)
    {
        if (isRotating)
        {
            Vector2 delta = value.Get<Vector2>();
            float deltaX = delta.x;
            yRotation += deltaX * mouseSensitivity * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, yRotation, 0);
        }
    }
}
