using UnityEngine;

public class TachyonSize : MonoBehaviour
{
    public SimpleCounter tachyons;
    private bool isScaling = false;
    [SerializeField] private int minScale = 1;
    [SerializeField] private int maxScale = 5;
    [SerializeField] private int logBase = 80;
    [SerializeField] private float timeToScale;

    private void Update()
    {
        if (isScaling) return;

        isScaling = true;
        float scale = Mathf.Clamp(Mathf.Log(tachyons.count, logBase), minScale, maxScale);
        LeanTween.scale(gameObject, new Vector2(scale, scale), timeToScale)
            .setEaseOutElastic()
            .setOnComplete(() => isScaling = false);
    }
}
