using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallMovement : MonoBehaviour
{
    private Vector3 direction;
    [SerializeField] float speed = 2.0f;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public void OnMoveBall(InputValue value)
    {
        Vector3 fromCameraToMe = transform.position - Camera.main.transform.position;
        fromCameraToMe.y = 0; // First, zero out any vertical component, so the movement plane is always horizontal.
        fromCameraToMe.Normalize(); // Then, normalize the vector to length 1 so that we don't affect the player more strongly when the camera is at different distances.

        Vector2 inputVector = value.Get<Vector2>();

        direction = (fromCameraToMe * inputVector.y + Camera.main.transform.right * inputVector.x);
        direction.y = 0f;
        
        rb.velocity = direction * speed;
    }
 }