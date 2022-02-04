using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimPosition : MonoBehaviour {

    [SerializeField] Transform target;
    [SerializeField] float radius;

    private void Update() {
        Vector3 v3Pos = Camera.main.WorldToScreenPoint(target.position);
        v3Pos = Input.mousePosition - v3Pos;
        float angle = Mathf.Atan2(v3Pos.y, v3Pos.x) * Mathf.Rad2Deg;
        v3Pos = Quaternion.AngleAxis(angle, Vector3.forward) * (Vector3.right * radius);
        transform.position = target.position + v3Pos;
    }
}
