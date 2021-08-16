using UnityEngine.UI;
using UnityEngine;

[CreateAssetMenu(menuName = "InteractableObject Tips/Create Object", fileName = "ObjectTip", order = 5)]
public class InteractableObjectTipDetails : ScriptableObject
{
    public Sprite displayImage;
    public string displayName;
    public string description;
}
