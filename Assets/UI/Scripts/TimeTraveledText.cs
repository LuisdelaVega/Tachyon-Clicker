using TMPro;
using UnityEngine;

public class TimeTraveledText : MonoBehaviour
{
    public SimpleDate GameDate;
    private TextMeshProUGUI timeTraveledText;

    private void Awake() => timeTraveledText = GetComponent<TextMeshProUGUI>();

    private void Update()
    {
        TotalTime timeTraveled = GameDate.GetTimeTraveled();

        timeTraveledText.text = $"{timeTraveled.totalDays} Days "
            + $"| {timeTraveled.totalMonths} Months "
            + $"| {timeTraveled.totalYears} Years";
    }
}
