using DG.Tweening;
using UnityEngine;

public class SimpleScreenPopUpAnimation : MonoBehaviour
{

    [SerializeField] float animationDuration;
    private void OnEnable()
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, animationDuration);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDisable()
    {
        
    }
}
