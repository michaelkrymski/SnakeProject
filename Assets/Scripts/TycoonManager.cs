using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TycoonManager : MonoBehaviour
{
    [SerializeField] private int balance;
    [SerializeField] TextMeshProUGUI BalanceText;
    [SerializeField] TextMeshProUGUI AppleTree;

    // Start is called before the first frame update
    void Start()
    {
        if(RetrieveBalance("balance") == 0)
        {
            balance = 0;
        }
        else
        {
            SetBalance(RetrieveBalance("balance"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetBalance()
    {
        return balance;
    }

    public int RetrieveBalance(string storageKey)
    {
        return PlayerPrefs.GetInt(storageKey);
    }

    public void StoreBalance(string storageKey)
    {
        PlayerPrefs.SetInt(storageKey, balance);
    }

    public void SetBalance(int newBalance)
    {
        balance = newBalance;
        UpdateUI();
    }    

    public void AddBalance(int amount)
    {
        balance += amount;
        UpdateUI();
    }

    public void UpdateUI()
    {
        BalanceText.text = "Balance: " + balance;
    }
}
