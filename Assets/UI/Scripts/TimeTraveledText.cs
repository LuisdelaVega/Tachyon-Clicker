using System;
using TMPro;
using UnityEngine;

public class TimeTraveledText : MonoBehaviour
{
    public SimpleDate GameDate;
    private TextMeshProUGUI timeTraveledText;
    private readonly float dayToMonthConversion = 0.03287667629953f;
    private readonly float dayToYearConversion = 0.0027397260274f;

    private void Awake() => timeTraveledText = GetComponent<TextMeshProUGUI>();

    private void Update()
    {
        TimeSpan timeSpan = (GameDate.StartDate - GameDate.Date);

        int totalDays = Mathf.FloorToInt((float)timeSpan.TotalDays);
        int totalMonths = Mathf.FloorToInt((float)timeSpan.TotalDays * dayToMonthConversion);
        int totalYears = Mathf.FloorToInt((float)timeSpan.TotalDays * dayToYearConversion);
        
        timeTraveledText.text = $"{totalDays} Days " + $"| {totalMonths} Months " + $"| {totalYears} Years";
    }
}
