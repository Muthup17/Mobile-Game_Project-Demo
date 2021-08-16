using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyExploration.Interaction
{
    public interface IInteractable
    {
        ButtonActionType TypeOfButtonAction { get; }
        ObjectType TypeOfObject { get; }
        Vector3 PutBackLocation { get; }
        float AccessTime { get; }
        string GetDescriptionText { get; }
        Transform TouchableButtonAnchor { get; }
        void OnInteract();

    }
}
