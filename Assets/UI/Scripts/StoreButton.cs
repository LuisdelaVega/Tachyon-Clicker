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
    public Image ItemImage;
    [SerializeField] private int cost = 1;
    private bool hasBeenInteractable = false;
    public GameObject[] LabSprites;
    [SerializeField] private int purchaseInterval = 50;

    private void Start()
    {
        btn = GetComponent<Button>();
        Title.text = $"{storeItem.itemName}";
        ItemImage.sprite = storeItem.image;

        SetText();
    }

    private void Update()
    {
        btn.interactable = tachyons.count >= cost;

        if (btn.interactable)
        {
            if (!hasBeenInteractable) hasBeenInteractable = true;
            ItemImage.color = Color.white;
        }
        else
            ItemImage.color = hasBeenInteractable ? Color.grey : Color.black;
    }

    public void Buy(int amount)
    {
        tachyons.count -= cost * amount;
        storeItem.count += amount;
        cost += (int)Math.Round(cost * amount * storeItem.costAdjustment);

        GameObject labSprite = LabSprites[Mathf.Clamp(Mathf.FloorToInt(storeItem.count / purchaseInterval), 0, LabSprites.Length - 1)];

        if (!labSprite.activeSelf) labSprite.SetActive(true);

        SetText();
    }

    private void SetText()
    {
        Cost.text = $"{cost}";
        Count.text = $"{storeItem.count}";
        TachyonsPerSecond.text = $"{storeItem.amountOfTachyonsToHarvest/storeItem.interval * storeItem.count}";
    }
}
