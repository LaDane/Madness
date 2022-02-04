using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerState;

public class Punch : MonoBehaviour {

    [SerializeField] private PlayerState playerState;
    [SerializeField] private Punch otherHandPunch;
    [SerializeField] private Transform punchPos;
    [SerializeField] private Transform originalPos;
    [SerializeField] private float punchDuration;
    [SerializeField] private float punchReturnDuration;
    [SerializeField] private bool rightHand;
    
    public bool isPunching = false;

    private Vector2 testPos;


    //private void Update() {
    //    if (playerState.GetState() == State.Aiming) {
    //        if (Input.GetMouseButton(0) && !isPunching && !otherHandPunch.isPunching) {
    //            isPunching = true;
    //            StartCoroutine(HandPunch());
    //        }
    //    }
    //}

    public IEnumerator HandPunch() {
        testPos = transform.position;
        Vector2 destination = punchPos.position;
        float timeElapsed = 0f;

        while (true) {
            if (timeElapsed < punchDuration) {
                transform.position = Vector2.Lerp(transform.position, destination, timeElapsed / punchDuration);
                timeElapsed += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            else {
                break;
            }
        }
        StartCoroutine(HandReturn());
    }

    private IEnumerator HandReturn() {
        float timeElapsed = 0f;

        while (true) {
            Vector2 ogPos = originalPos.position;
            if (timeElapsed < punchReturnDuration) {
                transform.position = Vector2.Lerp(transform.position, ogPos, timeElapsed / punchReturnDuration);
                timeElapsed += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            else {
                break;
            }
        }
        isPunching = false;
    }
}
