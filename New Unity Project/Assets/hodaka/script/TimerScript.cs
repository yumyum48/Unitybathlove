using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    public float  TimeSeconds = 60.0f;//タイマー表示用
    int TIME;
    public bool TimeEndFlg = false;//タイマーが終了したか管理するフラグ
    private Text textTimer;
    public Text textGameOver;
    public Text textGameClear;

    public GameObject Players;

    void Start()
    {
        textTimer = GameObject.Find("Timer").GetComponent<Text>();
        TimeSeconds += 1;//(x.00からではなくx.99から開始させるため　ただの見栄え）
        textGameOver.enabled = false; //開始段階では存在を抹消する
        textGameClear.enabled = false;//同じく
    }

    void Update()
    {
        if (Players.transform.childCount != 0)
        {
            TimeSeconds -= Time.deltaTime;
            TIME = (int)TimeSeconds;
        }
        if (TimeSeconds <= 0.0f)
        {
            TimeSeconds = 0.0f;
            TimeEndFlg = true;
        }
        textTimer.text = "TIME : " + TIME.ToString();
        GameClearDrawing();
        GameOverDrawing();


    }

    public void GameClearDrawing() {
        if (TimeEndFlg == true)
        {
            textGameClear.enabled = true;
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("joystick button 1")) //マウス左クリック、Aボタン
            {
                SceneManager.LoadScene("Title");//some_senseiシーンをロードする
            }
        }
    }
    public void GameOverDrawing()
    {
        //プレイヤーの処理
        if (Players.transform.childCount == 0)
        {
            textGameOver.enabled = true;
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("joystick button 1")) //マウス左クリック、Aボタン
            {
                SceneManager.LoadScene("Title");//玉本をロードする
            }
        }
    }
}
