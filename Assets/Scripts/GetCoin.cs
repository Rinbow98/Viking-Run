using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]

public class GetCoin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Coin: " + other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<Score>().AddScore(20f);
            Destroy(gameObject);
        }
    }
}
