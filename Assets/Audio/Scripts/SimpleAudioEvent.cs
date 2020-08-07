
using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Audio Events/Simple")]
public class SimpleAudioEvent : ScriptableObject
{
    public AudioClip[] clips;
    [SerializeField]
    private float minPitch = 0.89f, maxPitch = 1.05f,
        minVolume = 0.8f, maxVolume = 1f;

    public bool Waiting { get; private set; } = false;
    [SerializeField] private float waitTime = 0.125f;

    public void Play(AudioSource source)
    {
        source.clip = clips[Random.Range(0, clips.Length)];
        source.volume = Random.Range(minVolume, maxVolume);
        source.pitch = Random.Range(minPitch, maxPitch);
        source.Play();
    }

    public IEnumerator PlayWithDelay(AudioSource source)
    {
        Play(source);
        Waiting = true;
        yield return new WaitForSeconds(waitTime);
        Waiting = false;
    }
}