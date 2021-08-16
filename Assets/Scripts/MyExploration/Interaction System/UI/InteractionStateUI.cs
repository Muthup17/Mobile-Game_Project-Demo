using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MyExploration.Interaction;

namespace MyExploration.UI.Interactions
{
    public class InteractionStateUI : MonoBehaviour
    {
        private static InteractionStateUI m_instance;
        public static InteractionStateUI Instance => m_instance;
        public GameObject interactionFailed;
        public GameObject wrongKey;
        public GameObject unLocked;
        public GameObject healthFull;
        public GameObject sprintFull;

        private void Awake()
        {
            m_instance = this;
        }
        public void StartShowandHide(GameObject obj)
        {
            StartCoroutine(ShowandHide(obj));
        }
        IEnumerator ShowandHide(GameObject obj)
        {
            obj.SetActive(true);
            yield return new WaitForSeconds(2);
            obj.SetActive(false);
        }
    }
}
