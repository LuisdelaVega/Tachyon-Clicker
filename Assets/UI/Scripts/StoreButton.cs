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
    public SimpleAudioEvent StoreSounds;
    private AudioSource audioSource;
    private Color btnColor;
    private bool interactable;

    private void Awake() => audioSource = GetComponent<AudioSource>();

    private void Start()
    {
        btn = GetComponent<Button>();
        Title.text = $"{storeItem.itemName}";
        ItemImage.sprite = storeItem.image;

        SetText();
    }

    private void Update()
    {
        // Button interactable
        interactable = tachyons.count >= cost;
        if (!interactable.Equals(btn.interactable)) btn.interactable = interactable;

        // Button Color
        if (btn.interactable)
        {
            if (!hasBeenInteractable) hasBeenInteractable = true;
            btnColor = Color.white;
        }
        else
            btnColor = hasBeenInteractable ? Color.grey : Color.black;

        if (!ItemImage.color.Equals(btnColor)) ItemImage.color = btnColor;
    }

    public void Buy(int amount)
    {
        tachyons.count -= cost * amount;
        storeItem.count += amount;
        cost += (int)Math.Round(cost * amount * storeItem.costAdjustment);

        if (audioSource != null && !StoreSounds.Waiting)
            StartCoroutine(StoreSounds.PlayWithDelay(audioSource));

        GameObject labSprite = LabSprites[Mathf.Clamp(Mathf.FloorToInt(storeItem.count / purchaseInterval), 0, LabSprites.Length - 1)];

        if (!labSprite.activeSelf) labSprite.SetActive(true);

        SetText();
    }

    private void SetText()
    {
        Cost.text = $"{cost:n0}";
        Count.text = $"{storeItem.count:n0}";
        string tachyonsPerSec = (storeItem.amountOfTachyonsToHarvest / storeItem.interval * storeItem.count).ToString("n0");
        TachyonsPerSecond.text = $"{(storeItem.count > 0 ? tachyonsPerSec : "???")}";
    }
}
