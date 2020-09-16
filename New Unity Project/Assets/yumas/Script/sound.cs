using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour
{
    public AudioClip sound1;
    AudioSource audioSource;
    bool DontDestroyEnabled = true;
    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
        if(DontDestroyEnabled)
        {
            // シーンが遷移しても、オブジェクトが消えないようにする
            DontDestroyOnLoad(this);
        }
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("joystick button 1")) //マウス左クリック、Aボタン
        {
            //音(sound1)を鳴らす
            audioSource.PlayOneShot(sound1);
        }
    }
}
