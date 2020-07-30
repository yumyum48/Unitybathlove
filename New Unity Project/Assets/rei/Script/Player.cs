using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 12.0f;
    public float brake = 0.5f;      //減速の大きさ
    private Rigidbody rB;
    private Vector3 rbVelo;         //今の速度を入れる変数

    public bool goalOn;
    public ParticleSystem explosion;
    public Text failText;
    private Vector3 height;

    Vector3 moveDirection;          //むく方向
    public float moveTumSpeed = 10f;//プレイヤーの回頭スピード



    void Start()
    {
        rB = GetComponent<Rigidbody>();
        goalOn = false;
        failText.enabled = false;
    }


    void Update()
    {
        if (goalOn == false)
        {
            //rbVelo = Vector3.zero;      //初期化するため毎回(0,0,0)を入れる
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            //rbVelo = rB.velocity;       //今の速度をebVeloに入れる
            rB.AddForce(x * speed, 0, z * speed, ForceMode.Impulse);
            //rB.AddForce(x * speed - rbVelo.x * brake, 0, z * speed - rbVelo.z * brake, ForceMode.Impulse);
            height = this.GetComponent<Transform>().position;
            if (height.y <= -3.0f)
            {
                explosion.transform.position = this.transform.position;
                explosion.Play();
                this.gameObject.SetActive(false);

            }

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Goal")
        {
            rB.AddForce(-rbVelo.x * 0.8f, 0, -rbVelo.z * 0.8f, ForceMode.Impulse);
            goalOn = true;
        }

    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            explosion.transform.position = this.transform.position;
            this.gameObject.SetActive(false);
            failText.enabled = true;
            explosion.Play();
        }

    }
    IEnumerator WaitKeyInput()
    {
        this.gameObject.GetComponent<Player>().enabled = false;
        {
            yield return new WaitForSeconds(0.2f);
        }
        this.gameObject.GetComponent<Player>().enabled = true;
    }

    void FixedUpdate()
    {
        if (goalOn == false)
        {
            rbVelo = Vector3.zero;
            float x = Input.GetAxis("Horizontal");  //左右方向キー
            float z = Input.GetAxis("Vertical");       //上下方向キー

            moveDirection = new Vector3(x * speed, 0, z * speed);

            if (moveDirection.magnitude > 0.01f && !(Input.GetKey(KeyCode.LeftShift)))
            {
                Quaternion moveRot = Quaternion.LookRotation(moveDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, moveRot, Time.deltaTime * moveTumSpeed);

            }
            rbVelo = rB.velocity;
            rB.AddForce(x * speed - rbVelo.x * brake, 0, z * speed - rbVelo.z * brake, ForceMode.Impulse);
        }
    }
}

