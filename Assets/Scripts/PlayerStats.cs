using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public float coinBalance;

    public TMP_Text coinText;

    private void Update()
    {
        coinText.text = "Balance: " + coinBalance.ToString();
    }
}
