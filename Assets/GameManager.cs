using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SimpleDate GameDate;
    public SimpleCounter tachyons;
    public StoreItem[] storeItems;

    private void Start()
    {
        tachyons.count = 1f;
        GameDate.dateIsBC = false;
        GameDate.Date = new DateTime(2020, 11, 11, 12, 12, 12, 0);

        foreach (StoreItem item in storeItems)
        {
            item.count = 0;
            StartCoroutine(RunStoreItem(item));
        }
    }

    private void Update() => GameDate.AddMilliseconds(-10f * tachyons.count);

    private IEnumerator RunStoreItem(StoreItem item)
    {
        while (true)
        {
            yield return new WaitForSeconds(item.interval);
            item.Click();
        }
    }
}
