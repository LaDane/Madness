using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour {

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private HingeJoint2D hinge;
    [SerializeField] private float aimThrust;
    [SerializeField] private float[] aimAngles = new float[2];

    private JointAngleLimits2D angleLimits;
    private float[] originalAngles = new float[2];
    private bool addedTorque = false;

    private void Start() {
        angleLimits = hinge.limits;
        originalAngles[0] = angleLimits.min;
        originalAngles[1] = angleLimits.max;
    }

    private void Update() {
        if (Input.GetMouseButton(1)) {
            angleLimits.min = aimAngles[0];
            angleLimits.max = aimAngles[1];
            hinge.limits = angleLimits;
            //rb.AddForce(-transform.up * aimThrust, ForceMode2D.Impulse);

            if (!addedTorque) {
                rb.AddTorque(aimThrust, ForceMode2D.Impulse);
                addedTorque = true;
            }

            //Debug.Log("min = "+ angleLimits.min + "\tMax = "+ angleLimits.max);

        }
        else {
            angleLimits.min = originalAngles[0];
            angleLimits.max = originalAngles[1];
            hinge.limits = angleLimits;
            addedTorque = false;
            //Debug.Log("min = " + angleLimits.min + "\tMax = " + angleLimits.max);

        }
    }
}
