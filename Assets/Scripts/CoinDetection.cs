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

            if (playerStats.coinBalance + collidedCoinValue >= 0)
            {
                playerStats.coinBalance += collidedCoinValue;
            }
            else
            {
                playerStats.coinBalance = 0;
            }

            Destroy(other.gameObject);
            Debug.Log(playerStats.coinBalance);
        }
    }
}
