using System.Collections;
using UnityEngine;
using TMPro;

public class UITextTypeWritter : MonoBehaviour
{
    private TextMeshProUGUI txt;
    private string story;
    [SerializeField] private float timeBetweenLeters = 0.125f;
    public SimpleAudioEvent Keyboard;
    private AudioSource source;
    private readonly float soundTime = 1.8f;
    private bool playSound = true;


    private void Awake()
    {
        txt = GetComponent<TextMeshProUGUI>();
        source = GetComponent<AudioSource>();
        story = txt.text;
        txt.text = "";

        StartCoroutine(PlayText());
    }

    private IEnumerator PlayText()
    {
        foreach (char c in story)
        {
            if (source != null && playSound) StartCoroutine(PlaySound());
            txt.text += c;
            yield return new WaitForSeconds(timeBetweenLeters);
        }
    }

    private IEnumerator PlaySound()
    {
        playSound = false;
        Keyboard.Play(source);
        yield return new WaitForSeconds(timeBetweenLeters * soundTime);
        playSound = true;
    }
}
