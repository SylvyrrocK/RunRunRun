using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDetection : MonoBehaviour
{
    public PlayerStats playerStats;

    private int collidedCoinValue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Money"))
        {
            collidedCoinValue = other.gameObject.GetComponent<CoinSpin>().coinValue;
            playerStats.coinBalance += collidedCoinValue;
            Destroy(other.gameObject);
            Debug.Log(playerStats.coinBalance);
        }
    }
}
