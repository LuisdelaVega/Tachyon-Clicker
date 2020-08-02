using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Counter/Store")]
public class StoreItem : SimpleCounter
{
    public float amountOfTachyonsToHarvest = 1;
    public float interval = 0.5f;
    public string itemName = "Jeff";
    public float costAdjustment = 0.5f;

    public static event Action<float> OnPerformClick;

    public void Click() => OnPerformClick?.Invoke(count * amountOfTachyonsToHarvest);
}
