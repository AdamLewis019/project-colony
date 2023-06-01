using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Ore : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag ("Miner"))
        {
            respawnOre(10f);
            this.gameObject.SetActive(false);
        }
    }

    public async void respawnOre(float duration)
    {
        var end = Time.time + duration;
        while (Time.time < end)
        {
            await Task.Yield();
        }
        this.gameObject.SetActive(true);
        this.tag = "Ore";
    }
}
