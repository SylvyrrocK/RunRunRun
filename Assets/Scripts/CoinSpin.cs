using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class CoinSpin : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] public static float coinSpeed = -2f;
    [SerializeField] private float levitationSpeed = 1f;

    private string coinName;

    public int coinValue = 1;

    public AnimationCurve myCurve;

    private void Start()
    {
        coinName = name;

        switch(coinName)
        {
            case "Coin":
                coinValue = 1;
                break;

            case "Gem":
                coinValue = 5; 
                break;

            case "mine":
                coinValue = -10;
                break;
        }
    }

    void Update()
    {
        //Rotation
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);

        //Up and down motion
        transform.position = new Vector3(transform.position.x, myCurve.Evaluate((Time.time % myCurve.length) * levitationSpeed), transform.position.z);

        //Movement
        transform.position += new Vector3(0, 0, coinSpeed) * Time.deltaTime;
    }

    public static void CoinSpeed()
    {
        CoinSpin.coinSpeed = -6f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
    }
}
