using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundName", menuName = "Sound/Simple Sounds")]
public class SimpleSounds : SoundBase
{
    [SerializeField] private AudioClip[] clips;
    [SerializeField] private Vector2 volume;
    [SerializeField] private Vector2 pitch;
    public override void Play(AudioSource source)
    {
       if(clips.Length > 0)
        {
            source.clip = clips[Random.Range(0, clips.Length)];
            source.volume = Random.Range(volume.x, volume.y);
            source.pitch = Random.Range(pitch.x, pitch.y);
            source.Play();
        }
    }
}
