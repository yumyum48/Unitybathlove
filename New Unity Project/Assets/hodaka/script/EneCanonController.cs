using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class EneCanonController : MonoBehaviour
{
    public GameObject muzzlePoint;
    public GameObject ball;
    public float speed = 30f;
    private bool ballFlg = true;
    private float frameCount = 0;

    // Update is called once per frame
    void Update()
    {
        if(ballFlg == true)
        {
            EneCanonShot();
            ballFlg = false;
        }
        if(frameCount++ >= 300)
        {
            ballFlg = true;
            frameCount = 0;
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Finish")
        {
            Destroy(gameObject, 0.2f);
        }
    }

    public void EneCanonShot()
    {
        Vector3 mballPos = muzzlePoint.transform.position;
        GameObject newball = Instantiate(ball, mballPos, transform.rotation);
        Vector3 dir = newball.transform.forward;
        newball.GetComponent<Rigidbody>().AddForce(dir * speed, ForceMode.Impulse);
        newball.name = ball.name;
    }

}
