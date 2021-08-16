using UnityEngine.UI;
using UnityEngine;

public class TouchFields : MonoBehaviour
{
    [SerializeField] FloatingJoystick floatingJoystick;
    [SerializeField] Toggle sprintToggle;
    [SerializeField] Toggle navigationSignToggle;
    [SerializeField] GameObject navigationSignRefContainer;

    public Vector2 JoystickInput => new Vector2(floatingJoystick.Direction.x, floatingJoystick.Direction.y);
    public bool runClicked;
    public bool runReleased;
    public bool navigationSignHolded;
    private void Awake()
    {
        sprintToggle.onValueChanged.AddListener(ChangeSprintMovementState);
        navigationSignToggle.onValueChanged.AddListener(ChangeNavigationSignState);
    }

    private void Start()
    {
        if (sprintToggle == null)
        {
            Debug.Log("Add ref of Sprint Toggle To this script");
        }
        if (navigationSignToggle == null)
        {
            Debug.Log("Add ref of NavigationSign Toggle To this script");
        }
        navigationSignRefContainer.SetActive(false);
    }
    void ChangeSprintMovementState(bool value)
    {
        ColorBlock cb = sprintToggle.colors;
        if (value)
        {
            runClicked = true;
            runReleased = false;
            cb.normalColor = cb.selectedColor;
            sprintToggle.colors = cb;
        }
        else
        {
            runReleased = true;
            runClicked = false;
            cb.normalColor = Color.white;
            sprintToggle.colors = cb;
        }
    }

    void ChangeNavigationSignState(bool value)
    {
        ColorBlock cb = navigationSignToggle.colors;
        if (value)
        {
            navigationSignHolded = true;
            cb.normalColor = cb.selectedColor;
            navigationSignToggle.colors = cb;
            navigationSignRefContainer.SetActive(true);
        }
        else
        {
            navigationSignHolded = false;
            cb.normalColor = Color.white;
            navigationSignToggle.colors = cb;
            navigationSignRefContainer.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        sprintToggle.onValueChanged.RemoveListener(ChangeSprintMovementState);
        navigationSignToggle.onValueChanged.RemoveListener(ChangeNavigationSignState);
    }
}
