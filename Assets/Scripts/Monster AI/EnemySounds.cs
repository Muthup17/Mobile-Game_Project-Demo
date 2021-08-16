using UnityEngine;

public class EnemySounds : MonoBehaviour
{
    [SerializeField] SoundBase growl;
    [SerializeField] SoundBase footSteps;
    [SerializeField] SoundBase hit;
    [SerializeField] SoundBase shoot;
    [SerializeField] SoundBase breath;
    [SerializeField] SoundBase bow_StringBack;
    [SerializeField] SoundBase bow_StringRelease;

    AudioSource source;
    private void Awake()
    {
        source = this.GetComponentInChildren<AudioSource>();
    }

    public void PlayGrowl()
    {
        growl.Play(source);
    }
    public void PlayMeleeAttackSound()
    {
        hit.Play(source);
    }
    public void IdleBreathing()
    {
        breath.Play(source);
    }
    public void PlayFootSound()
    {
        footSteps.Play(source);
    }
    public void PlayShootSound()
    {
        shoot.Play(source);
    }
    public void PlayStringBackSound()
    {
        bow_StringBack.Play(source);
    }
    public void PlayStringReleaseSound()
    {
        bow_StringRelease.Play(source);
    }
}
