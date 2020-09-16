using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSEDestroy : MonoBehaviour
{

    GameObject titleSe = GameObject.Find("TachSE");
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("joystick button 1")) //マウス左クリック、Aボタン
        {
            // タイトル決定オンのオブジェクトを破棄
            Destroy(titleSe, 0.2f);
        }
    }
}
