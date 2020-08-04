using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SimpleDate GameDate;
    public SimpleCounter tachyons;
    public StoreItem[] storeItems;

    private void Awake()
    {
        // Set the Start and End dates for the game
        GameDate.StartDate = new DateTime(2020, 11, 11, 12, 12, 12, 0);
        GameDate.EndDate = new DateTime(2000, 7, 27, 12, 12, 12, 0);

        // Start the game at one Tachyon
        tachyons.count = 1f;

        // Start the game with no Store Items bought
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
