using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour {

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float force;
    [SerializeField] private float angleAdjustment;

    private void Update() {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 diff = mousePos - rb.position;
        float angle = Mathf.Atan2(diff.y, diff.x);

        rb.MoveRotation(Mathf.LerpAngle(rb.rotation, angle * angleAdjustment, force * Time.fixedDeltaTime));
    }

}
