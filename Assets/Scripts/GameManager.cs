using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    Fever fever;
    [SerializeField] GameObject barrier;
    [SerializeField] GameObject startTimer;
    Text startTimerText;

    static public bool isPause;

    private void Awake() {
        Application.targetFrameRate = 120;
        isPause = true;
    }

    private void Start() {
        fever = GetComponent<Fever>();

        startTimerText = startTimer.GetComponent<Text>();

        StartCoroutine(GameStart());
    }

    IEnumerator GameStart() {
        for (int i = 0; i < 15; i++) {
            fever.CenterSummon();
        }

        startTimerText.text = "[3]";

        yield return new WaitForSeconds(1);

        startTimerText.text = "[2]";

        yield return new WaitForSeconds(1);

        startTimerText.text = "[1]";

        yield return new WaitForSeconds(1);

        startTimerText.text = "Start";
        isPause = false;
        barrier.SetActive(false);

        yield return new WaitForSeconds(0.5f);

        startTimer.SetActive(false);
    }

    public void RetryButton() {
        SceneManager.LoadScene("Game");
    }

    public void EndButton() {
        Application.Quit();
    }
}
