using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TycoonManager : MonoBehaviour
{
    [SerializeField] private int balance;
    [SerializeField] string storageKey = "balance";

    // Start is called before the first frame update
    void Start()
    {
        if(RetrieveBalance(storageKey) == 0)
        {
            balance = 0;
        }
        else
        {
            balance = RetrieveBalance(storageKey);
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
    }    

    public void AddBalance(int amount)
    {
        balance += amount;
    }
}
