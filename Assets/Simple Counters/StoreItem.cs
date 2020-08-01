using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Counter/Store")]
public class StoreItem : SimpleCounter
{
    public float amountOfTachyonsToHarvest = 1;
    public static event Action<float> OnPerformClick;
    public float interval = 0.5f;
    public string itemName = "Jeff";
    public float costAdjustment = 0.5f;

    public void Click() => OnPerformClick?.Invoke(count * amountOfTachyonsToHarvest);
}
