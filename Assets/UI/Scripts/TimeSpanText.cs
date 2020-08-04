using TMPro;
using UnityEngine;

public class TimeSpanText : MonoBehaviour
{
    public SimpleDate GameDate;
    private TextMeshProUGUI tmp;
    [SerializeField] private string timeTo = "Start";

    private void Awake() => tmp = GetComponent<TextMeshProUGUI>();

    private void Update()
    {
        TotalTime time;
        switch (timeTo)
        {
            case "Start":
                time = GameDate.GetTimeTraveled();
                break;
            default:
                time = GameDate.GetTimeUntilEnd();
                break;

        }

        tmp.text = $"{time.totalDays} Days "
            + $"| {time.totalMonths} Months "
            + $"| {time.totalYears} Years";
    }
}
