using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RigidType
{
    Car = 0,
    Stone = 1,
    Ship = 2,
    Rod = 3,
    BigShip =  4,
}

public class RigidCtrl : MonoBehaviour
{
    public RigidType type = RigidType.Car;
    public Vector3 force;

    public bool isReverse;

    private Vector3 oriPos;
    private void OnEnable()
    {
        if (type == RigidType.Car)
            GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
        else if (type == RigidType.Stone)
        {
            GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
        }
        else if (type == RigidType.Rod)
        {
            GetComponent<Rigidbody>().isKinematic = false;
        }
        oriPos = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (type == RigidType.Car)
        {
            return;
        }

        if (type == RigidType.Rod)
            return;
        if (type == RigidType.Ship || type == RigidType.BigShip)
        {           
            return;
        }
        if (collision.collider.tag == "Car")
        {
            GetComponent<Animator>()?.Play("Die");
        }
    }

    private void Update()
    {
        if (type == RigidType.Ship)
        {
            if(!isReverse)
                transform.position += Vector3.forward * 6f * Time.deltaTime;
            else
                transform.position -= Vector3.forward * 6f * Time.deltaTime;
            return;
        }
        else if (type == RigidType.BigShip)
        {
            transform.position += new Vector3(1,0,-1) * 6f * Time.deltaTime;

        }
    }

    public float DisZ()
    {
        Debug.LogError(Mathf.Abs(transform.position.z - oriPos.z).ToString());
        return Mathf.Abs(transform.position.z - oriPos.z);
    }


}
