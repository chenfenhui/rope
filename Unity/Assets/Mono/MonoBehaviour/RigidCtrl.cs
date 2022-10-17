using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RigidType
{
    Car = 0,
    Stone = 1,
    Ship = 2,
    Rod = 3,
}

public class RigidCtrl : MonoBehaviour
{
    public RigidType type = RigidType.Car;
    public Vector3 force;
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (type == RigidType.Car || type == RigidType.Rod)
            return;
        if (type == RigidType.Ship)
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
            transform.position += transform.forward * 10f * Time.deltaTime;
            return;
        }
    }

}
