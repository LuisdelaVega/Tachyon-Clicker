using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Counter/Store")]
public class StoreItem : SimpleCounter
{
    public float amountOfTachyonsToHarvest = 1;
    public float interval = 0.5f;
    public string itemName = "Jeff";
    public float costAdjustment = 0.5f;

    public SimpleCounter tachyon;

    public void Click() => tachyon.count += count * amountOfTachyonsToHarvest;
}
