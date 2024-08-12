using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDetection : MonoBehaviour
{
    public PlayerStats playerStats;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Money"))
        {
            Destroy(other.gameObject);
            playerStats.coinBalance += 1f;
            Debug.Log(playerStats.coinBalance);
        }
    }
}
