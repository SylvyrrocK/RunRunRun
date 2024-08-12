using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class CoinSpin : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f;

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
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);

        transform.position = new Vector3(transform.position.x, myCurve.Evaluate((Time.time % myCurve.length)), transform.position.z);

    }
}
