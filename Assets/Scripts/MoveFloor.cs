using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour {
    private Vector3 pos;

    private int time = 0;

    private void Start() {
        pos = this.transform.localPosition;
    }

    private void Update() {
        if (GameManager.isPause) return;

        time++;

        pos.z = Mathf.Sin(time * 0.007f) * 4f + 18;

        this.transform.localPosition = pos;
    }
}
