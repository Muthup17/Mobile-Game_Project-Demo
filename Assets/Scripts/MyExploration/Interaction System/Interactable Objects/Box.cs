using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyExploration.Interaction;
public class Box : InteractableObject
{
    public override void OnInteract()
    {
        base.OnInteract();
        Destroy(this.gameObject);
    }
}
