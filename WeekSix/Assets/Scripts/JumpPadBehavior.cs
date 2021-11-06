using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadBehavior : MonoBehaviour
{
    [SerializeField] float jumpForce = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody playerRB = other.GetComponent<Rigidbody>();
            playerRB.AddForce(other.transform.up * jumpForce, ForceMode.Impulse);
        }
    }
}
