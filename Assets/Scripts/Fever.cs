using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Fever : MonoBehaviour {
    [SerializeField] GameObject[] potPrefab;
    [SerializeField] GameObject parentObject;

    Vector3 rPos;
    Vector3 lPos;

    private void Start() {
        rPos = new Vector3(25, 25, 25);
        lPos = new Vector3(-25, 25, 25);
    }

    public void FeverTime() {

        for (int i = 0; i < 10; i++) {
            Instantiate(potPrefab[UnityEngine.Random.Range(0, potPrefab.Length)], rPos, Quaternion.identity, parentObject.transform);
        }
        for (int i = 0; i < 10; i++) {
            Instantiate(potPrefab[UnityEngine.Random.Range(0, potPrefab.Length)], lPos, Quaternion.identity, parentObject.transform);
        }
    }

    public void CenterSummon() {
        for (int i = 0; i < 10; i++) {
            Instantiate(potPrefab[UnityEngine.Random.Range(0, potPrefab.Length)], new Vector3(-1, 15, 12), Quaternion.identity, parentObject.transform);
        }
    }

}
