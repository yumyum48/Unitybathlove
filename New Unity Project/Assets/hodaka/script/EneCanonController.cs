using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class EneCanonController : MonoBehaviour
{
    public TimerScript timeFlg;
    public GameObject muzzlePoint;
    public GameObject ball;
    public float speed = 30f;
    private bool ballFlg = false;
    private float frameCount = 0;
    public float MaxFrameCount = 300;

    // Update is called once per frame
    void Update()
    {
        if(ballFlg == true)
        {
            EneCanonShot();
            ballFlg = false;
        }
        if(frameCount++ >= MaxFrameCount)
        {
            ballFlg = true;
            frameCount = 0;
        }
    }

    public void EneCanonShot()
    {
        if (timeFlg.TimeEndFlg == false)
        {
            Vector3 mballPos = muzzlePoint.transform.position;
            //Vector3 mballRot = new Vector3(-180,- 90,- 180);
            GameObject newball = Instantiate(ball, mballPos, transform.rotation); //Quaternion.Euler(mballRot)
                                                                                  // Vector3 dir = newball.transform.forward;
                                                                                  //Vector3 dir = new Vector3(0,0,0);
            Vector3 dir = newball.transform.right;
            newball.GetComponent<Rigidbody>().AddForce(dir * speed, ForceMode.Impulse);
            newball.name = ball.name;
        }
    }

}
