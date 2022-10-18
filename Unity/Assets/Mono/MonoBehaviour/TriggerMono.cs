using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMono : MonoBehaviour
{
    public bool isSuc = true;


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.tag);
        if (collision.collider.tag == "Car")
            isSuc = false;
    }

}
