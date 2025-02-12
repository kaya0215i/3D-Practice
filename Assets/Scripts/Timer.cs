using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    [SerializeField] Text timerText;
    [SerializeField] Result result;
    [SerializeField] Slot slot;

    int time;

    private void Start() {
        time = 180;
        timerText.text = "残り時間:" + time;

        // CountDownメソッドを1.0秒後に呼び出し、1.0秒ごとに繰り返し呼び出す
        InvokeRepeating(nameof(CountDown), 3.0f, 1.0f);
    }

    public void CountDown() {
        time -= 1;
        timerText.text = "残り時間:" + time;

        // 制限時間が切れたらInvokeによるメソッド呼び出し終了
        if (time <= 0) {
            CancelInvoke();

            slot.StopAllCoroutines();

            GameManager.isPause = true;

            result.ShowResult();
        }
    }
}
