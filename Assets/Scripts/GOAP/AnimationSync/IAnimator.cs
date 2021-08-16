using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimator 
{
    public bool Sitting { get; set; }
    public IEnumerator AlignWithPosition();
    public IEnumerator WaitForAnimationToFinish();
}
