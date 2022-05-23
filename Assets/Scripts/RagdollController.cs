using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    public float force = 3000f;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        transform.Find("mixamorig8:Hips").GetComponent<Rigidbody>().AddRelativeForce(transform.forward * force);
    }
}
