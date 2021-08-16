using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SoundBase : ScriptableObject
{
    public abstract void Play(AudioSource source);
}
