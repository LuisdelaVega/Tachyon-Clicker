
using UnityEngine;

[CreateAssetMenu(menuName = "Audio Events/Simple")]
public class SimpleAudioEvent : ScriptableObject
{
    public AudioClip[] clips;
    [SerializeField] private float minPitch = 0.89f, maxPitch = 1.05f,
        minVolume = 0.8f, maxVolume = 1f;

    public void Play(AudioSource source)
    {
        source.clip = clips[Random.Range(0, clips.Length)];
        source.volume = Random.Range(minVolume, maxVolume);
        source.pitch = Random.Range(minPitch, maxPitch);
        source.Play();
    }
}