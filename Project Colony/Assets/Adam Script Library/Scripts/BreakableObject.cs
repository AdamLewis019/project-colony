using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    public GameObject ItemToDrop;
    public float itemQuantity = 1f;
    public void mineThis()
    {
        Debug.Log("Mined " + this.gameObject);
        Instantiate(ItemToDrop, this.transform.position, Quaternion.Euler(0, 0, 90));
        Destroy(this.gameObject);
    }
}
