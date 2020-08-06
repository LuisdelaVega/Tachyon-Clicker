using System.Collections;
using UnityEngine;

public class MinMaxWindow : MonoBehaviour
{
    public RectTransform window;
    private Vector3 windowOriginalScale;
    public GameObject windowObject;
    private Vector3 windowObjectOriginalScale;
    [SerializeField] private bool isMinimized = false;
    [SerializeField] private float scaleTime = 0.5f;

    private void Awake()
    {
        windowOriginalScale = window.transform.localScale;

        if (windowObject != null)
            windowObjectOriginalScale = windowObject.transform.localScale;
    }

    public void Click()
    {
        if (!isMinimized)
        {
            isMinimized = true;
            if (windowObject != null)
            {
                LeanTween.scale(windowObject, Vector3.zero, scaleTime);
                window.gameObject.SetActive(!isMinimized);
            }
            else
                LeanTween.scale(window, Vector3.zero, scaleTime);
        }
        else
        {
            isMinimized = false;
            if (windowObject != null)
            {
                LeanTween.scale(windowObject, windowObjectOriginalScale, scaleTime);
                StartCoroutine(ActivateWindow());
            }
            else
                LeanTween.scale(window, windowOriginalScale, scaleTime);
        }
    }

    private IEnumerator ActivateWindow()
    {
        yield return new WaitForSeconds(scaleTime);
        window.gameObject.SetActive(!isMinimized);
    }
}
