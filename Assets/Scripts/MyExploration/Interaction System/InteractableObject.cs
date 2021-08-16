using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyExploration.Inventories;

namespace MyExploration.Interaction
{
    public enum ObjectType
    {
        ONEHANDED,
        TWOHANDED
    }
    public enum ButtonActionType
    {
        HOLDABLE,
        NON_HOLDABLE
    }
    public abstract class InteractableObject : MonoBehaviour, IInteractable
    {
        [SerializeField] private ButtonActionType m_buttonActionType;
        [SerializeField] private ObjectType m_objectType;
        [SerializeField] private string m_itemDescriptionText;
        [SerializeField] private float m_accessTime;
        [SerializeField] Transform m_touchableButtonAnchor;

        protected AudioSource source;

        private float m_currentAccessTime;
        private Vector3 this_initPosition;

        private void Awake()
        {
            source = this.GetComponentInChildren<AudioSource>();
        }
        protected virtual void Start()
        {
            m_currentAccessTime = 0;
        }

        public ButtonActionType TypeOfButtonAction
        {
            get => m_buttonActionType;
        }
        public ObjectType TypeOfObject { get => m_objectType; }
        public Vector3 PutBackLocation => this_initPosition;
        public float AccessTime => m_accessTime;
        public float CurrentAccessTime
        {
            get => m_currentAccessTime;
            set => m_currentAccessTime = value;
        }
        public string GetDescriptionText => m_itemDescriptionText;

        public Transform TouchableButtonAnchor => m_touchableButtonAnchor;

        public virtual void OnInteract()
        {
            CurrentAccessTime = 0;
            Debug.Log("Item Interacted");
        }
    }
}
