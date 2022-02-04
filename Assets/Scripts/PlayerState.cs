using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {
    
    public enum State {
        Idle,
        Aiming
    }

    public State state;

    public State GetState() {
        return state;
    }

    public void SetIdle() {
        state = State.Idle;
    }

    public void SetAiming() {
        state = State.Aiming;
    }
}
