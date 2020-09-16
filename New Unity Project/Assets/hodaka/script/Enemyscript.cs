using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyscript : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Finish" || other.gameObject.tag == "Player")
        {
            Destroy(gameObject, 0.2f);
        }
    }
}
