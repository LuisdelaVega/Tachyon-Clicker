using TMPro;
using UnityEngine;

public class TachyonCountText : MonoBehaviour
{
    public SimpleCounter tachyons;
    private TextMeshProUGUI countText;

    private void Awake() => countText = GetComponent<TextMeshProUGUI>();
    private void Update() => countText.text = $"/c/usr/dlvglpz/opt/> Tachyons Harvested: {tachyons.count}";
}
