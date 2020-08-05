using UnityEngine;
using UnityEngine.UI;

public class Journal : MonoBehaviour
{

    public ScrollRect scrollRect;
    public RectTransform contentPanel;
    public SimpleDate GameDate;
    public RectTransform[] entries;

    private void Update()
    {
        TotalTime timeTraveled = GameDate.GetTimeTraveled();
        TotalTime timeUntilEnd = GameDate.GetTimeUntilEnd();

        #region Story Elements
        if (timeTraveled.totalDays == 1 && !entries[0].gameObject.activeSelf)
        {
            entries[0].gameObject.SetActive(true);
            SnapTo(entries[0]);
        }
        else if (timeTraveled.totalMonths == 1 && !entries[1].gameObject.activeSelf)
        {
            entries[1].gameObject.SetActive(true);
            SnapTo(entries[1]);
        }
        else if (timeTraveled.totalYears == 1 && !entries[2].gameObject.activeSelf)
        {
            entries[2].gameObject.SetActive(true);
            SnapTo(entries[2]);
        }
        else if (timeTraveled.totalYears == 5 && !entries[3].gameObject.activeSelf)
        {
            entries[3].gameObject.SetActive(true);
            SnapTo(entries[3]);
        }
        else if (timeTraveled.totalYears == 10 && !entries[4].gameObject.activeSelf)
        {
            entries[4].gameObject.SetActive(true);
            SnapTo(entries[4]);
        }
        else if (timeUntilEnd.totalYears == 1 && !entries[5].gameObject.activeSelf)
        {
            entries[5].gameObject.SetActive(true);
            SnapTo(entries[5]);
        }
        else if (timeUntilEnd.totalMonths == 6 && !entries[6].gameObject.activeSelf)
        {
            entries[6].gameObject.SetActive(true);
            SnapTo(entries[6]);
        }
        else if (timeUntilEnd.totalDays <= 0 && !entries[7].gameObject.activeSelf)
        {
            entries[7].gameObject.SetActive(true);
            SnapTo(entries[7]);
        }
        #endregion
    }

    private void SnapTo(RectTransform target)
    {
        Canvas.ForceUpdateCanvases();

        Vector3 position = new Vector3(contentPanel.position.x,
                                       target.position.y + target.sizeDelta.y * 1.5f,
                                       contentPanel.position.z);

        contentPanel.anchoredPosition =
            (Vector2)scrollRect.transform.InverseTransformPoint(contentPanel.position)
            - (Vector2)scrollRect.transform.InverseTransformPoint(position);
    }
}
