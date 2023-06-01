using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.Rotate(5, 0, 0 * Time.deltaTime); //rotates 5 degrees per second around x axis
    }

    private void OnCollisionEnter(Collision collision)
    {
        // pick me up

    }
}
