using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldBalance : MonoBehaviour
{
    TMP_Text goldBalance;
    Bank bank;

    void Start()
    {
        goldBalance = GetComponent<TMP_Text>();
        bank = FindObjectOfType<Bank>();
    }

    private void Update()
    {
        UpdateGold();
    }

    public void UpdateGold()
    {
        goldBalance.text = $"Gold: {bank.CurrentBalance}";
    }
}
