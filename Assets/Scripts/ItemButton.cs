using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    public Text itemDisPlayer;
    public string itemName;

    public int level;

    public int currentCost;

    public int startCurrentCost = 1;

    public int goldPerSec;

    public int startGoldPerSec = 1;

    public float costPow = 1.07f;

    public float upgradePow = 1.07f;

    public bool isPurchase = false;

    void Start()
    {
        DataController.GetInstance().LoadItemButton(this);
        StartCoroutine("AddGoldLoop");

        UpdateUI();
    }

    public void PurchaseItem()
    {
        if (DataController.GetInstance().GetPayGoods() >= currentCost)
        {
            isPurchase = true;
            DataController.GetInstance().SubPayGoods(currentCost);
            level++;

            UpdateItem();
            UpdateUI();
            DataController.GetInstance().SaveItemButton(this);
        }
    }

    IEnumerator AddGoldLoop()
    {
        while (true)
        {
            if (isPurchase)
            {
                DataController.GetInstance().AddGold(goldPerSec);
                DataController.GetInstance().AddTotalGold(goldPerSec);
            }

            yield return new WaitForSeconds(1.0f);
        }
    }

    public void UpdateItem()
    {
        goldPerSec = goldPerSec + startGoldPerSec * (int)Mathf.Pow(upgradePow, level);
        currentCost = startCurrentCost * (int)Mathf.Pow(costPow, level);
    }

    public void UpdateUI()
    {
        itemDisPlayer.text = itemName + "\nlevel : " + level + "\nCost : " + currentCost + "\nGold Per Sec : " + goldPerSec
            + "\nisPurchase : " + isPurchase;
    }

}
