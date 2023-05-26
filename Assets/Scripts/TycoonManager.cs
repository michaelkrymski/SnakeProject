using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TycoonManager : MonoBehaviour
{
    private int firstTime;

    private int snakeMultiplier = 1;

    private float balance;
    [SerializeField] TextMeshProUGUI BalanceText;
    [SerializeField] TextMeshProUGUI BucketText;
    [SerializeField] TextMeshProUGUI BucketCost;
    [SerializeField] TextMeshProUGUI AppleTreeText;
    [SerializeField] TextMeshProUGUI AppleTreeCost;
    [SerializeField] TextMeshProUGUI MarketText;
    [SerializeField] TextMeshProUGUI MarketCost;
    [SerializeField] TextMeshProUGUI FactoryText;
    [SerializeField] TextMeshProUGUI FactoryCost;
    [SerializeField] TextMeshProUGUI IncomePerSecond;

    private int numBuckets;
    [SerializeField] int bucketValue = 1;
    [SerializeField] float bucketCost = 10;

    private int numTrees;
    [SerializeField] int treeValue = 8;
    [SerializeField] float treeCost = 100;

    private int numMarkets;
    [SerializeField] int marketValue = 40;
    [SerializeField] float marketCost = 1000;

    private int numFactories;
    [SerializeField] int factoryValue = 400;
    [SerializeField] float factoryCost = 10000;

    private AudioSource buySound;

    void Start()
    {
        buySound = GetComponent<AudioSource>();
        firstTime = PlayerPrefs.GetInt("firstTime", 1);
        if(firstTime == 1)
        {
            PlayerPrefs.SetInt("firstTime", 0);
            PlayerPrefs.SetFloat("balance", 0);
            PlayerPrefs.SetFloat("multiplier", 1);
            PlayerPrefs.SetInt("numBuckets", 0);
            PlayerPrefs.SetFloat("bucketCost", bucketCost);
            PlayerPrefs.SetInt("numTrees", 0);
            PlayerPrefs.SetFloat("treeCost", treeCost);
            PlayerPrefs.SetInt("numMarkets", 0);
            PlayerPrefs.SetFloat("marketCost", marketCost);
            PlayerPrefs.SetInt("numFactories", 0);
            PlayerPrefs.SetFloat("factoryCost", factoryCost);
            PlayerPrefs.Save();
            UpdateUI();
        }
        else
        {
            balance = RetrieveValue("balance");
            snakeMultiplier = (int)RetrieveValue("multiplier");
            numBuckets = (int)RetrieveValue("numBuckets");
            bucketCost = (int)RetrieveValue("bucketCost");
            numTrees = (int)RetrieveValue("numTrees");
            treeCost = RetrieveValue("treeCost");
            numMarkets = (int)RetrieveValue("numMarkets");
            marketCost = RetrieveValue("marketCost");
            numFactories = (int)RetrieveValue("numFactories");
            factoryCost = RetrieveValue("factoryCost");
            StartCoroutine(AddSecondaryBalanceRoutine());
            UpdateUI();
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
        PlayerPrefs.Save();
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

    public void ChangeMarketCount(int amount)
    {
        numMarkets += amount;
        UpdateUI();
        StoreValue("numMarkets", numMarkets);
    }

    public void ChangeFactoryCount(int amount)
    {
        numFactories += amount;
        UpdateUI();
        StoreValue("numFactories", numFactories);
    }

    public void UpdateUI()
    {
        BalanceText.text = "Balance: " + balance;
        AppleTreeText.text = "Apple Trees: " + numTrees;
        AppleTreeCost.text = "Cost: " + treeCost;
        BucketText.text = "Buckets: " + numBuckets;
        BucketCost.text = "Cost: " + bucketCost;
        MarketText.text = "Markets: " + numMarkets;
        MarketCost.text = "Cost: " + marketCost;
        FactoryText.text = "Factories: " + numFactories;
        FactoryCost.text = "Cost: " + factoryCost;
        IncomePerSecond.text = "Income Per Second: " + (numBuckets * bucketValue + numTrees * treeValue + numMarkets * marketValue + numFactories * factoryValue);
    }

    public void AddBucket()
    {
        if(balance < bucketCost)
        {
            return;
        }
        ChangeBucketCount(1);
        ChangeBalance(-bucketCost);
        ChangeSnakeMultiplier(3);
        bucketCost = bucketCost * 1.5f;
        bucketCost = Mathf.Round(bucketCost * 100f) / 100f;
        StoreValue("bucketCost", bucketCost);
        UpdateUI();
        buySound.Play();
    }

    public void AddTree()
    {
        if(balance < treeCost)
        {
            return;
        }
        ChangeTreeCount(1);
        ChangeBalance(-treeCost);
        ChangeSnakeMultiplier(8);
        treeCost = treeCost * 1.5f;
        treeCost = Mathf.Round(treeCost * 100f) / 100f;
        StoreValue("treeCost", treeCost);
        UpdateUI();
        buySound.Play();
    }

    public void AddMarket()
    {
        if(balance < marketCost)
        {
            return;
        }
        ChangeMarketCount(1);
        ChangeBalance(-marketCost);
        ChangeSnakeMultiplier(50);
        marketCost = marketCost * 1.5f;
        marketCost = Mathf.Round(marketCost * 100f) / 100f;
        StoreValue("marketCost", marketCost);
        UpdateUI();
        buySound.Play();
    }

    public void AddFactory()
    {
        if(balance < factoryCost)
        {
            return;
        }
        ChangeFactoryCount(1);
        ChangeBalance(-factoryCost);
        ChangeSnakeMultiplier(700);
        factoryCost = factoryCost * 1.5f;
        factoryCost = Mathf.Round(factoryCost * 100f) / 100f;
        StoreValue("factoryCost", factoryCost);
        UpdateUI();
        buySound.Play();
    }

    private void AddSecondaryBalance()
    {
        int secondaryBalance = 0;
        secondaryBalance += numBuckets * bucketValue;
        secondaryBalance += numTrees * treeValue;
        secondaryBalance += numMarkets * marketValue;
        secondaryBalance += numFactories * factoryValue;
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
