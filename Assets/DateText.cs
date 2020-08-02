using TMPro;
using UnityEngine;

public class DateText : MonoBehaviour
{
    public SimpleDate GameDate;
    private TextMeshProUGUI dateText;

    private void Awake() => dateText = GetComponent<TextMeshProUGUI>();
    private void Update() => dateText.text = $"/c/usr/dlvglpz/opt/> Current date:\n" +
        $"{(GameDate.dateIsBC ? "-":  "")}{GameDate.Date.Year}/{GameDate.Date.Month}/{GameDate.Date.Day} " +
        $"{GameDate.Date.Hour}:{GameDate.Date.Minute}:{GameDate.Date.Second}.{GameDate.Date.Millisecond}";
}
