using UnityEngine;

public class TachyonSize : MonoBehaviour
{
    public SimpleCounter tachyons;
    private bool isScaling = false;
    [SerializeField] private float minScale = 1;
    private float originalScaleX = 1;
    private float originalScaleY = 1;
    [SerializeField] private float maxScale = 5;
    [SerializeField] private int logBase = 80;
    [SerializeField] private float timeToScale;

    private void Awake()
    {
        originalScaleX = transform.localScale.x;
        originalScaleY = transform.localScale.y;
    }

    private void Update()
    {
        if (isScaling) return;

        isScaling = true;
        float scaleX = Mathf.Clamp(Mathf.Log(tachyons.count, logBase), minScale, maxScale) * originalScaleX;
        float scaleY = Mathf.Clamp(Mathf.Log(tachyons.count, logBase), minScale, maxScale) * originalScaleY;
        LeanTween.scale(gameObject, new Vector2(scaleX, scaleY), timeToScale)
            .setEaseOutElastic()
            .setOnComplete(() => isScaling = false);
    }
}
