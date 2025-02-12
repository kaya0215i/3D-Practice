using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor2 : MonoBehaviour {
    private Vector3 pos;

    private int time = 0;

    private void Start() {
        pos = this.transform.localPosition;
    }

    private void Update() {
        if (GameManager.isPause) return;

        time++;

        pos.x = Mathf.Sin(time * 0.005f) * 15;
        pos.z = Mathf.Sin(time * 0.01f) * 3;

        this.transform.localPosition = pos;
    }
}
