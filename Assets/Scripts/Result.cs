using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour {
    [SerializeField] GameObject resultObject;
    [SerializeField] Text scoreText;
    [SerializeField] Text bulletAmountText;
    [SerializeField] Text lastScore;

    [SerializeField] Score scoreManager;
    [SerializeField] Gun gumManager;

    [SerializeField] GameObject retryButton;
    [SerializeField] GameObject endButton;

    bool randomScore;
    bool randomAmount;

    private void Start() {
        randomScore = true;
        randomAmount = true;
    }

    private void Update() {
        if(randomScore) {
            scoreText.text = "" + UnityEngine.Random.Range(100000, 1000000);
            
        }
        if (randomAmount) {
            bulletAmountText.text = "" + UnityEngine.Random.Range(100000, 1000000);
        }

    }

    public void ShowResult() {
        resultObject.SetActive(true);

        foreach (Transform child in GameObject.Find("pots").transform) {
            GameObject.Destroy(child.gameObject);
        }

        StartCoroutine(ScoreResult());
    }

    IEnumerator ScoreResult() {
        yield return new WaitForSeconds(2.0f);

        randomScore = false;
        scoreText.text = "" + scoreManager.score;

        yield return new WaitForSeconds(1.0f);

        randomAmount = false;
        bulletAmountText.text = "" + gumManager.bulletAmount * 10;

        yield return new WaitForSeconds(0.5f);

        lastScore.text = "" + (scoreManager.score + (gumManager.bulletAmount * 10));

        retryButton.SetActive(true);
        endButton.SetActive(true);
    }

}
