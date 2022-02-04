using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerState;

public class PunchManager : MonoBehaviour {

    [SerializeField] PlayerState playerState;
    [SerializeField] private Punch leftPunch;
    [SerializeField] private Punch rightPunch;

    private int punchIndex = 1;

    private void Update() {
        if (playerState.GetState() == State.Aiming) {
            if (Input.GetMouseButtonDown(0)) {
                if (punchIndex == 1 && !leftPunch.isPunching) {
                    leftPunch.isPunching = true;
                    punchIndex = 2;
                    StartCoroutine(leftPunch.HandPunch());
                }
                else if (punchIndex == 2 && !rightPunch.isPunching) {
                    rightPunch.isPunching = true;
                    punchIndex = 1;
                    StartCoroutine(rightPunch.HandPunch());
                }
            }
        }
    }
}
