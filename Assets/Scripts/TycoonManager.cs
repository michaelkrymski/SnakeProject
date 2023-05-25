using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TycoonManager : MonoBehaviour
{
    private int firstTime;

    private int snakeMultiplier = 1;

    private float balance;
    [SerializeField] TextMeshProUGUI AppleTree;
    [SerializeField] private TextMeshProUGUI BalanceText;

    private int numBuckets;
    [SerializeField] int bucketValue = 1;
    [SerializeField] float bucketCost = 10;

    private int numTrees;
    [SerializeField] int treeValue = 3;
    [SerializeField] float treeCost = 100;

    // Start is called before the first frame update
    void Start()
    {
        firstTime = PlayerPrefs.GetInt("firstTime", 1);
        if(firstTime == 1)
        {
            PlayerPrefs.SetInt("firstTime", 0);
            PlayerPrefs.SetFloat("multiplier", 1);
            PlayerPrefs.SetFloat("balance", 0);
            PlayerPrefs.SetInt("numBuckets", 0);
            PlayerPrefs.SetFloat("bucketCost", 10);
            PlayerPrefs.SetInt("numTrees", 0);
            PlayerPrefs.SetFloat("treeCost", 100);
        }
        else
        {
            balance = RetrieveValue("balance");
            numTrees = (int)RetrieveValue("numTrees");
            snakeMultiplier = (int)RetrieveValue("multiplier");
            treeCost = (int)RetrieveValue("treeCost");
            StartCoroutine(AddSecondaryBalanceRoutine());
            UpdateUI();
            Debug.Log((int)RetrieveValue("treeCost"));
        }
        Debug.Log(PlayerPrefs.GetFloat("treeCost"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetBalance()
    {
        return balance;
    }

    public float RetrieveValue(string storageKey)
    {
        return PlayerPrefs.GetFloat(storageKey);
    }

    public void StoreValue(string storageKey, float value)
    {
        PlayerPrefs.SetFloat(storageKey, value);
    }

    public void SetBalance(float newBalance)
    {
        balance = newBalance;
        UpdateUI();
    }    

    public void ChangeBalance(float amount)
    {
        balance += amount;
        UpdateUI();
        StoreValue("balance", balance);
    }

    public void ChangeSnakeMultiplier(int amount)
    {
        snakeMultiplier += amount;
        StoreValue("multiplier", snakeMultiplier);
    }

    public void ChangeTreeCount(int amount)
    {
        numTrees += amount;
        UpdateUI();
        StoreValue("numTrees", numTrees);
    }

    public void UpdateUI()
    {
        BalanceText.text = "Balance: " + balance;
        AppleTree.text = "Apple Trees: " + numTrees;
    }

    public void AddBucket()
    {
        if(balance < bucketCost)
        {
            return;
        }
        ChangeBalance(-bucketCost);
        ChangeSnakeMultiplier(1);
        bucketCost = bucketCost * 1.5f;
        StoreValue("bucketCost", bucketCost);
        //
    }

    public void AddTree()
    {
        if(balance < treeCost)
        {
            return;
        }
        ChangeTreeCount(1);
        ChangeBalance(-treeCost);
        ChangeSnakeMultiplier(2);
        treeCost = treeCost * 1.5f;
        StoreValue("treeCost", treeCost);
        UpdateUI();
    }

    private void AddSecondaryBalance()
    {
        int secondaryBalance = 0;
        secondaryBalance += numTrees * treeValue;
        ChangeBalance(secondaryBalance);
    }

    private IEnumerator AddSecondaryBalanceRoutine()
    {
        while(true)
        {
            AddSecondaryBalance();
            yield return new WaitForSeconds(1.0f);
        }
    }
}
