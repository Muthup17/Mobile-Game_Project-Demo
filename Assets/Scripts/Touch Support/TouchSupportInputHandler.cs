using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

namespace PlayerControlls
{    
    public class TouchSupportInputHandler : MonoBehaviour
    {
        Player_Actions inputActions;
        bool interactionKeyHolded;

        bool canLookArround;
        int fingerIndex;
        Vector2 prevFingerPos;
        Vector2 lookDelta;

        TouchFields touchFields;
        #region BuiltIn Methods

        private void OnEnable()
        {
            inputActions.Enable();
            EnhancedTouchSupport.Enable();
        }
        private void OnDisable()
        {
            inputActions.Disable();
            EnhancedTouchSupport.Disable();

            PlayerMovement_InputData.Instance.ResetInput();
            Camera_InputData.Instance.ResetInput();
            PlayerExamination_InputData.Instance.ResetInput();
            PlayerPointPickUp_InputData.Instance.ResetInput();
            PlayerInteraction_InputData.Instance.ResetInput();
            NavigationSignPlacement_InputData.Instance.ResetInput();
            UI_InputData.Instance.ResetInput();
        }
        void Awake()
        {
            inputActions = new Player_Actions();
            touchFields = FindObjectOfType<TouchFields>();

            UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown += FingerDown;
            UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerUp += FingerUp;

            inputActions.Player.Movement.performed += MovementInput;
            inputActions.Player.Look.performed += LookInput;

            inputActions.Player.InteractionPressed.started += ctx => interactionKeyHolded = true;
            inputActions.Player.InteractionPressed.performed += ctx => interactionKeyHolded = true;
            inputActions.Player.InteractionPressed.canceled += ctx => interactionKeyHolded = false;
        }

        void Update()
        {
            Touch_MoveInput();
            Touch_LookInput();
/*            GetMovementInputData();*/
            GetTouchMovementInputData();
            GetInteractionInputData();
            GetExaminationInputData();
            GetPointPickUpInputData();
            GetSignPlacementInputData();
            GetUIInputData();
            ZoomLookInput();
        }

        private void OnDestroy()
        {
            UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown -= FingerDown;
            UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerUp -= FingerUp;

            inputActions.Player.Movement.performed -= MovementInput;
            inputActions.Player.Look.performed -= LookInput;

            inputActions.Player.InteractionPressed.started -= ctx => interactionKeyHolded = true;
            inputActions.Player.InteractionPressed.performed -= ctx => interactionKeyHolded = true;
            inputActions.Player.InteractionPressed.canceled -= ctx => interactionKeyHolded = false;

        }
        #endregion

        #region Custom Methods

            void MovementInput(InputAction.CallbackContext context)
            {

                Vector2 inputData = context.ReadValue<Vector2>();
                PlayerMovement_InputData.Instance.InputVectorX = inputData.x;
                PlayerMovement_InputData.Instance.InputVectorY = inputData.y;

            }
            void Touch_MoveInput()
            {
                PlayerMovement_InputData.Instance.InputVectorX = touchFields.JoystickInput.x;
                PlayerMovement_InputData.Instance.InputVectorY = touchFields.JoystickInput.y;
            }
            void Touch_LookInput()
            {
                if (canLookArround)
                {
                    if (fingerIndex >= 0 && fingerIndex < UnityEngine.InputSystem.EnhancedTouch.Touch.activeFingers.Count)
                    {
                        lookDelta = UnityEngine.InputSystem.EnhancedTouch.Touch.activeFingers[fingerIndex].screenPosition - prevFingerPos;
                        prevFingerPos = UnityEngine.InputSystem.EnhancedTouch.Touch.activeFingers[fingerIndex].screenPosition;
                    }
                }
                else
                {
                    lookDelta = Vector2.zero;
                }
                Camera_InputData.Instance.InputVectorX = lookDelta.x;
                Camera_InputData.Instance.InputVectorY = lookDelta.y;
                PlayerExamination_InputData.Instance.InputVectorX = lookDelta.x;
                PlayerExamination_InputData.Instance.InputVectorY = lookDelta.y;
            }
            void LookInput(InputAction.CallbackContext context)
            {
                Vector2 inputData = context.ReadValue<Vector2>();
                Camera_InputData.Instance.InputVectorX = inputData.x;
                Camera_InputData.Instance.InputVectorY = inputData.y;
                PlayerExamination_InputData.Instance.InputVectorX = inputData.x;
                PlayerExamination_InputData.Instance.InputVectorY = inputData.y;
            }
            void FingerDown(Finger finger)
            {
                if (finger.screenPosition.x > Screen.width / 2)
                {
                    canLookArround = true;
                    fingerIndex = finger.index;
                    prevFingerPos = finger.screenPosition;
                }
            }

            void FingerUp(Finger finger)
            {
                canLookArround = false;
            }
            void ZoomLookInput()
            {
                Camera_InputData.Instance.ZoomClicked = inputActions.Player.ZoomLookPressed.triggered;
                Camera_InputData.Instance.ZoomReleased = inputActions.Player.ZoomLookReleased.triggered;
            }
            
            void GetMovementInputData()
            {
                PlayerMovement_InputData.Instance.RunClicked = inputActions.Player.SprintPressed.triggered;
                PlayerMovement_InputData.Instance.RunReleased = inputActions.Player.SprintReleased.triggered;

                if (PlayerMovement_InputData.Instance.RunClicked)
                    PlayerMovement_InputData.Instance.IsRunning = true;

                if(PlayerMovement_InputData.Instance.RunReleased)
                    PlayerMovement_InputData.Instance.IsRunning = false;
                PlayerMovement_InputData.Instance.JumpClicked = inputActions.Player.JumpPressed.triggered;
                PlayerMovement_InputData.Instance.CrouchClicked = inputActions.Player.CrouchPressed.triggered;
                PlayerMovement_InputData.Instance.ShootPressed = inputActions.Player.Shoot.triggered;
                PlayerMovement_InputData.Instance.ConsumePressed = inputActions.Player.DirectConsume.triggered;
            }
            
            void GetTouchMovementInputData()
            {
                PlayerMovement_InputData.Instance.RunClicked = touchFields.runClicked;
                PlayerMovement_InputData.Instance.RunReleased = touchFields.runReleased;

                if (PlayerMovement_InputData.Instance.RunClicked)
                    PlayerMovement_InputData.Instance.IsRunning = true;

                if (PlayerMovement_InputData.Instance.RunReleased)
                    PlayerMovement_InputData.Instance.IsRunning = false;
                PlayerMovement_InputData.Instance.JumpClicked = inputActions.Player.JumpPressed.triggered;
                PlayerMovement_InputData.Instance.CrouchClicked = inputActions.Player.CrouchPressed.triggered;
                PlayerMovement_InputData.Instance.ShootPressed = inputActions.Player.Shoot.triggered;
            }

            void GetInteractionInputData()
            {
                PlayerInteraction_InputData.Instance.InteractionKeyPressed = inputActions.Player.InteractionPressed.triggered;
                PlayerInteraction_InputData.Instance.InteractionKeyHolded = interactionKeyHolded;
                PlayerInteraction_InputData.Instance.PickupKeyPressed = inputActions.Player.InventoryStoreKeyPressed.triggered;
            }

            void GetExaminationInputData()
            {

                PlayerExamination_InputData.Instance.ExaminationButtonisHolding = inputActions.Player.ZoomLookPressed.triggered;
                PlayerExamination_InputData.Instance.ExaminationButtonReleased = inputActions.Player.ZoomLookReleased.triggered;
            }
            
            void GetPointPickUpInputData()
            {
                PlayerPointPickUp_InputData.Instance.IsKeyPressed = inputActions.Player.InteractionPressed.triggered;
            }

            void GetSignPlacementInputData()
            {
/*                NavigationSignPlacement_InputData.Instance.IsKeyHolded = touchFields.navigationSignHolded;*/
                NavigationSignPlacement_InputData.Instance.Printed = inputActions.Player.NavigationSignPaintPressed.triggered;
                NavigationSignPlacement_InputData.Instance.FirstOneIsSelected = inputActions.Player.NavigationSign1.triggered;
                NavigationSignPlacement_InputData.Instance.SecondOneIsSelected = inputActions.Player.NavigationSign2.triggered;
                NavigationSignPlacement_InputData.Instance.ThirdOneIsSelected = inputActions.Player.NavigationSign3.triggered;
                NavigationSignPlacement_InputData.Instance.ForthOneIsSelected = inputActions.Player.NavigationSign4.triggered;
            } 
            void GetUIInputData()
            {
                UI_InputData.Instance.InventoryUIKeyPressed = inputActions.Player.InventoryOpen.triggered;
                /*UI_InputData.Instance.GameMenuUI_KeyPressed = Input.GetKeyDown(KeyCode.Escape);*/
            }
        #endregion
    }
}