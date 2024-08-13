using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    public GameObject roadSection;
    public GameObject coin;
    public GameObject gem;
    public GameObject mine;

    public int coinSpawnAmount;
    public int gemSpawnAmount;
    public int mineSpawnAmount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            Instantiate(roadSection, new Vector3(0, 0, 20f), Quaternion.identity);

            coinSpawnAmount = Random.Range(1, 3);
            gemSpawnAmount = Random.Range(0, 2);
            mineSpawnAmount = Random.Range(0, 2);

            for (int i = 0; i < coinSpawnAmount; i++)
            {
                Instantiate(coin, new Vector3 (Random.Range(1.8f, 6.2f), 0, Random.Range(15.5f, 24.5f)), Quaternion.identity);
            }

            for (int i = 0; i < gemSpawnAmount; i++)
            {
                Instantiate(gem, new Vector3(Random.Range(1.8f, 6.2f), 0, Random.Range(15.5f, 24.5f)), Quaternion.identity);
            }

            for(int i = 0; i < mineSpawnAmount; i++)
            {
                Instantiate(mine, new Vector3(Random.Range(1.8f, 6.2f), 0, Random.Range(15.5f, 24.5f)), Quaternion.identity);
            }
        }
    }
}
