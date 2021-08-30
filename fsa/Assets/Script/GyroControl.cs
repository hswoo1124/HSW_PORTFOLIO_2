using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroControl : MonoBehaviour
{
    private Rigidbody rigi;

    private void Start()
    {
        rigi = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rigi.AddForce(Input.acceleration*30);
    }
}
