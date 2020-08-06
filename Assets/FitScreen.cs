using UnityEngine;

public class FitScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float width = (float)(Camera.main.orthographicSize * 2.0 * Screen.width / Screen.height);
        float height = (float)(Camera.main.orthographicSize * 2.0 * Screen.height / Screen.width);
        transform.localScale = new Vector2(width, width);
    }
}
