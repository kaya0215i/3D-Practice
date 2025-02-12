using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour {
    [SerializeField] GameObject slot;
    Image slotBack;
    [SerializeField] Text slotText;
    [SerializeField] Text slotAmountText;

    [SerializeField] Score scoreManager;

    [SerializeField] Gun gunManager;

    bool isSlot;

    int slotAmount;

    int slot1;
    int slot2;
    int slot3;

    bool slot1f;
    bool slot2f;
    bool slot3f;

    bool rgbText;

    private void Start() {
        UnityEngine.Random.InitState(DateTime.Now.Millisecond);

        slotBack = slot.GetComponent<Image>();
        slotBack.color = Color.red;

        isSlot = false;

        slotAmount = 0;

        slot1f = true;
        slot2f = true;
        slot3f = true;

        rgbText = false;
    }

    private void Update() {
        if (GameManager.isPause) return;

        if (slot1f) {
            slot1 = UnityEngine.Random.Range(0, 10);
        }
        if (slot2f) {
            slot2 = UnityEngine.Random.Range(0, 10);
        }
        if(slot3f) {
            slot3 = UnityEngine.Random.Range(0, 10);
        }

        slotText.text = "[" + slot1 + "]" + "[" + slot2 + "]" + "[" + slot3 + "]";


        //if (Input.GetKeyDown(KeyCode.F)) {
        //    AddSlotAmount();
        //}

        //if (Input.GetKeyDown(KeyCode.G)) {
        //    this.gameObject.GetComponent<Fever>().FeverTime();
        //}

        if(slotAmount > 0) {
            if (!isSlot) {
                StartSlot();
            }
        }

        if (rgbText) {
            float R;
            float G;
            float B;

            R = UnityEngine.Random.Range(0.0f, 1.0f);
            G = UnityEngine.Random.Range(0.0f, 1.0f);
            B = UnityEngine.Random.Range(0.0f, 1.0f);

            slotText.color = new Color(R, G, B);
            slotBack.color = new Color(R, G, B);
        }
        else {
            slotText.color = Color.black;
            slotBack.color = Color.red;
        }

    }

    public void StartSlot() {
        isSlot = true;
        slotAmount--;

        slotAmountText.text = "+" + slotAmount;

        slot.SetActive(true);

        StartCoroutine(SlotOn());
    }

    IEnumerator SlotOn() {
        yield return new WaitForSeconds(1.0f);

        slot1f = false;
        //slot1 = 7;

        yield return new WaitForSeconds(0.5f);

        slot3f = false;
        //slot3 = 7;

        yield return new WaitForSeconds(0.5f);

        slot2f = false;
        //slot2 = 7;

        if(slot1 == slot2) {
            if(slot1 == slot3) {
                if (slot1 == 7) {
                    for (int i = 0; i < 15; i++) {
                        gunManager.AddBullet(150);
                        this.gameObject.GetComponent<Fever>().FeverTime();
                    }

                    for (int i = 0; i < 5; i++) {
                        gunManager.AddBullet(150);
                        this.gameObject.GetComponent<Fever>().CenterSummon();
                    }

                    scoreManager.AddScore(10000);
                }
                else if (slot1 == 9) {
                    for (int i = 0; i < 10; i++) {
                        gunManager.AddBullet(150);
                        this.gameObject.GetComponent<Fever>().CenterSummon();
                    }

                    scoreManager.AddScore(5000);
                }
                else {
                    for (int i = 0; i < 5; i++) {
                        gunManager.AddBullet(50);
                        this.gameObject.GetComponent<Fever>().FeverTime();
                    }

                    scoreManager.AddScore(3000);
                }
                rgbText = true;

                yield return new WaitForSeconds(3);
            }
        }

        yield return new WaitForSeconds(0.7f);

        if (slotAmount <= 0) {
            slot.SetActive(false);
        }

        slot1f = true;
        slot2f = true;
        slot3f = true;

        yield return new WaitForSeconds(0.1f);
        rgbText = false;
        isSlot = false;
    }

    public void AddSlotAmount() {
        slotAmount++;

        slotAmountText.text = "+" + slotAmount;
    }

    public void StopCoroutines() {
        StopAllCoroutines();
    }
}