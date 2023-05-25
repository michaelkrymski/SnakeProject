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
    [SerializeField] private TextMeshProUGUI BucketText;

    private int numBuckets;
    [SerializeField] int bucketValue = 1;
    [SerializeField] float bucketCost = 10;

    private int numTrees;
    [SerializeField] int treeValue = 3;
    [SerializeField] float treeCost = 100;

    void Start()
    {
        firstTime = PlayerPrefs.GetInt("firstTime", 1);
        if(firstTime == 1)
        {
            PlayerPrefs.SetInt("firstTime", 0);
            PlayerPrefs.SetFloat("balance", 0);
            PlayerPrefs.SetFloat("multiplier", 1);
            PlayerPrefs.SetInt("numBuckets", 0);
            PlayerPrefs.SetFloat("bucketCost", 10);
            PlayerPrefs.SetInt("numTrees", 0);
            PlayerPrefs.SetFloat("treeCost", 100);
        }
        else
        {
            balance = RetrieveValue("balance");
            snakeMultiplier = (int)RetrieveValue("multiplier");
            numBuckets = (int)RetrieveValue("numBuckets");
            bucketCost = (int)RetrieveValue("bucketCost");
            numTrees = (int)RetrieveValue("numTrees");
            treeCost = RetrieveValue("treeCost");
            StartCoroutine(AddSecondaryBalanceRoutine());
            UpdateUI();
            Debug.Log((int)RetrieveValue("treeCost"));
        }
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

    public void ChangeBucketCount(int amount)
    {
        numBuckets += amount;
        UpdateUI();
        StoreValue("numBuckets", numBuckets);
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
        //BucketText.text = "Buckets: " + numBuckets;
    }

    public void AddBucket()
    {
        if(balance < bucketCost)
        {
            return;
        }
        ChangeBucketCount(1);
        ChangeBalance(-bucketCost);
        ChangeSnakeMultiplier(2);
        bucketCost = bucketCost * 1.5f;
        StoreValue("bucketCost", bucketCost);
        UpdateUI();
    }

    public void AddTree()
    {
        if(balance < treeCost)
        {
            return;
        }
        ChangeTreeCount(1);
        ChangeBalance(-treeCost);
        ChangeSnakeMultiplier(5);
        treeCost = treeCost * 1.5f;
        StoreValue("treeCost", treeCost);
        UpdateUI();
    }

    private void AddSecondaryBalance()
    {
        int secondaryBalance = 0;
        secondaryBalance += numBuckets * bucketValue;
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
