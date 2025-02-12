using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    [SerializeField] Text scoreText;
    public int score;

    private void Start() {
        score = 0;
        scoreText.text = "スコア:" + score;
    }

    public void AddScore(int value) {
        score += value;
        scoreText.text = "スコア:" + score;
    }
}
