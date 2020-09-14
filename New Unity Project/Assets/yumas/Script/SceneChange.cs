using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // シーンマネジメントの追加

public class SceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("joystick button 1")) //マウス左クリック、スペースキー、Aボタン、ジャンプボタンを押した場合
        {
            SceneManager.LoadScene("GameMain");//some_senseiシーンをロードする
        }
    }
}
