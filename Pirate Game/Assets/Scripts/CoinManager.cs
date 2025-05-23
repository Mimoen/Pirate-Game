using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public int coinCount;
    public TMP_Text coinText;

    void Start()
    {
        
    }

    void Update()
    {
        coinText.text = "Doubloons: " + coinCount.ToString();
    }
}
