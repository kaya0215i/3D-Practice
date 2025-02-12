using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour {
    [SerializeField] GameObject[] bulletPrefab;
    [SerializeField] Text bulletAmountText;
    [SerializeField] GameObject parentObject;

    public int bulletAmount;

    private void Start() {
        bulletAmount = 50;
        bulletAmountText.text = "持ち壺:" + bulletAmount;
    }

    private void Update() {
        if(GameManager.isPause) return;
        
        //右クリックされたら
        if (Input.GetMouseButtonDown(0)) {
            bulletAmount--;
            bulletAmountText.text = "持ち壺:" + bulletAmount;

            Vector3 pos = Input.mousePosition; //マウスのクリックした位置を取得

            //カメラからクリックした点を通るRayを作成
            Ray ray = Camera.main.ScreenPointToRay(pos);

            //Rayのベクトルを正規化して方向を取得
            Vector3 dir = Camera.main.ScreenPointToRay(pos).direction.normalized;

            //弾を生成して、弾のインスタンスをbulletに代入する
            //引数1: 弾のPrefab, 引数2: 弾の出現位置(=カメラの位置), 引数3: 回転してない状態で生成
            GameObject bullet = Instantiate(bulletPrefab[UnityEngine.Random.Range(0, bulletPrefab.Length)], transform.position, Quaternion.identity, parentObject.transform);

            //生成した弾にアタッチしているbulletスクリプトから、Shotメソッドを呼び出して弾に力を加える
            bullet.GetComponent<Bullet>().Shot(dir);

            //カメラからクリックした点を通るRayをデバッグ用に可視化してみる
            Debug.DrawRay(ray.origin, ray.direction * 15.0f, Color.red, 5, false);
        }
    }

    public void AddBullet(int value) {
        bulletAmount += value;
        bulletAmountText.text = "持ち壺:" + bulletAmount;
    }
}
