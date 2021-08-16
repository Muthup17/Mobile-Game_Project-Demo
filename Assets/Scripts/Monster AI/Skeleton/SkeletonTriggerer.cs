using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI.Skeletons;
public class SkeletonTriggerer : MonoBehaviour
{
    [SerializeField] PlayerDetection skeleton;

    public void Trigger()
    {
        skeleton.trigger2 = true;
    }
}
