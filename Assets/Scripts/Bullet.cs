using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    private int power = 6000;

    public void Shot(Vector3 dir) {
        // 弾のRigidbodyコンポーネントを取得して力を加える 
        GetComponent<Rigidbody>().AddForce(dir * power);
    }

    private void Update() {
        StartCoroutine(Wait());
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("moveWall")) {
            this.gameObject.tag = "item";
        }
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(3.0f);

        this.gameObject.tag = "item";
    }
}
