using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveForce;
    [SerializeField] private float jumpForce;

    private bool isJumping = false;

    private void Update() {
        if (Input.GetKey("a")) {
            rb.AddForce(Vector2.left * moveForce);
        }
        if (Input.GetKey("d")) {
            rb.AddForce(Vector2.right * moveForce);
        }
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping) {
            rb.AddForce(Vector2.up * jumpForce);
        }
    }
}
