using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreButton : MonoBehaviour
{
    public SimpleCounter tachyons;
    public StoreItem storeItem;
    private Button btn;
    public TextMeshProUGUI Title;
    public TextMeshProUGUI Cost;
    public TextMeshProUGUI Count;
    public TextMeshProUGUI TachyonsPerSecond;
    [SerializeField] private int cost = 1;

    private void Start()
    {
        btn = GetComponent<Button>();

        SetText();
    }

    private void Update() => btn.interactable = tachyons.count >= cost;
    public void Buy(int amount)
    {
        tachyons.count -= cost * amount;
        storeItem.count += amount;
        cost += (int)Math.Round(cost * amount * storeItem.costAdjustment);

        SetText();
    }

    private void SetText()
    {
        Title.text = $"{storeItem.itemName}";
        Cost.text = $"{cost}";
        Count.text = $"{storeItem.count}";
        TachyonsPerSecond.text = $"{storeItem.amountOfTachyonsToHarvest/storeItem.interval * storeItem.count}";
    }
}
