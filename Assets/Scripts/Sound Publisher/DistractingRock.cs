using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistractingRock : MonoBehaviour
{
    [SerializeField] SoundBase m_collisionSound;
    [SerializeField] float m_soundDuration;
    AudioSource source;
    private bool m_soundPlayed;
    bool called;
    public bool SoundPlayed => m_soundPlayed;

    private void Awake()
    {
        source = this.GetComponentInChildren<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground") && !called)
        {
            m_collisionSound.Play(source);
            StartCoroutine(SoundPropogation());
            called = true;
        }
    }

    IEnumerator SoundPropogation()
    {
        yield return new WaitForSeconds(m_soundDuration);
        m_soundPlayed = true;
        Debug.Log("Rock 1");
        yield return null;
        m_soundPlayed = false;
    }
}
