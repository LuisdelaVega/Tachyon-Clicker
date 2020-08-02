using System;
using UnityEngine;
using UnityEngine.UI;

public class StoreButton : MonoBehaviour
{
    public SimpleCounter tachyons;
    public StoreItem storeItem;
    private Button btn;
    private Text btnText;
    [SerializeField] private int cost = 1;

    private void Awake()
    {
        btn = GetComponent<Button>();
        btnText = GetComponentInChildren<Text>();

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

    private void SetText() => btnText.text = $"{storeItem.itemName} cost: {cost} amount: {storeItem.count}";
}
