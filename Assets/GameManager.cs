using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SimpleDate GameDate;
    public SimpleCounter Tachyons;
    public StoreItem[] storeItems;

    public GameObject OutroTimeline;

    private AudioSource source;
    [SerializeField] private float soundfadeInterval = 0.125f;
    [SerializeField] private float soundfadeTimeInterval = 0.125f;
    [SerializeField] private float maxVolume = 0.5f;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        // Set the Start and End dates for the game
        GameDate.StartDate = new DateTime(2020, 11, 11, 12, 12, 12, 0);
        GameDate.EndDate = new DateTime(2000, 7, 27, 12, 12, 12, 0);

        // Start the game at one Tachyon
        Tachyons.count = 1f;

        // Start the game with no Store Items bought
        foreach (StoreItem item in storeItems)
        {
            item.count = 0;
            StartCoroutine(RunStoreItem(item));
        }
    }

    private void Start() => StartCoroutine(FadeInAudio());

    private void Update()
    {
        GameDate.AddMilliseconds(-10f * Tachyons.count);

        if (GameDate.GetTimeUntilEnd().totalDays <= 0 && !OutroTimeline.gameObject.activeSelf)
            OutroTimeline.SetActive(true);
    }

    private IEnumerator RunStoreItem(StoreItem item)
    {
        while (true)
        {
            yield return new WaitForSeconds(item.interval);
            item.Click();
        }
    }

    private IEnumerator FadeInAudio()
    {
        while (source.volume < maxVolume)
        {
            yield return new WaitForSeconds(soundfadeTimeInterval);
            source.volume += soundfadeInterval;
        }
    }
}
