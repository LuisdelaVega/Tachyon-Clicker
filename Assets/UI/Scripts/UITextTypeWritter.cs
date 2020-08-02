using System.Collections;
using UnityEngine;
using TMPro;

public class UITextTypeWritter : MonoBehaviour
{
    public TextMeshProUGUI txt;
    private string story;
    [SerializeField] private float timeBetweenLeters = 0.125f;

    private void Awake()
    {
        txt = GetComponent<TextMeshProUGUI>();
        story = txt.text;
        txt.text = "";

        StartCoroutine(PlayText());
    }

    private IEnumerator PlayText()
    {
        foreach (char c in story)
        {
            txt.text += c;
            yield return new WaitForSeconds(timeBetweenLeters);
        }
    }
}
