using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    Score scoreManager;
    Gun gunManager;
    Slot slotManager;

    private void Start() {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<Score>();
        gunManager = GameObject.Find("Main Camera").GetComponent<Gun>();
        slotManager = GameObject.Find("EventManager").GetComponent<Slot>();
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("floor")) {
            if (this.gameObject.CompareTag("item")) {
                scoreManager.AddScore(10);
                gunManager.AddBullet(1);
            }

            Destroy(this.gameObject);
        }
        else if (collision.gameObject.CompareTag("floor2")) {
            if (this.gameObject.CompareTag("item")) {
                scoreManager.AddScore(35);
                gunManager.AddBullet(1);

                slotManager.AddSlotAmount();
            }

            Destroy(this.gameObject);
        }
        else if (collision.gameObject.CompareTag("end")) {
            Destroy(this.gameObject);
        }


    }
}
