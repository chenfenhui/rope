using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RigidType
{
    Car = 0,
    Stone = 1,
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (type == RigidType.Car)
            return;
        if (collision.collider.tag == "Car")
        {
            GetComponent<Animator>()?.Play("Die");
        }
    }

}
