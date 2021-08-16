using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerControlls
{    
    public class InputHandler : MonoBehaviour
    {
        Player_Actions inputActions;
        bool interactionKeyHolded;
        bool navigationSignPlacerHolded;
        #region BuiltIn Methods

             private void OnEnable()
             {
                 inputActions.Enable();
             }
             private void OnDisable()
             {
                 inputActions.Disable();
             }
            void Awake()
            {
                inputActions = new Player_Actions();

                inputActions.Player.Movement.performed += MovementInput;
                inputActions.Player.Look.performed += LookInput;

                inputActions.Player.InteractionPressed.started += ctx => interactionKeyHolded = true;
                inputActions.Player.InteractionPressed.performed += ctx => interactionKeyHolded = true;
                inputActions.Player.InteractionPressed.canceled += ctx => interactionKeyHolded = false;

                inputActions.Player.NavigationSignPlacerHolded.started += ctx => navigationSignPlacerHolded = true;
                inputActions.Player.NavigationSignPlacerHolded.performed += ctx => navigationSignPlacerHolded = true;
                inputActions.Player.NavigationSignPlacerHolded.canceled += ctx => navigationSignPlacerHolded = false;
            }

            void Update()
            {
                GetMovementInputData();
                GetInteractionInputData();
                GetExaminationInputData();
                GetPointPickUpInputData();
                GetSignPlacementInputData();
                GetUIInputData();
                ZoomLookInput();
            }
        #endregion

        #region Custom Methods

            void MovementInput(InputAction.CallbackContext context)
            {
                
                Vector2 inputData = context.ReadValue<Vector2>();
                PlayerMovement_InputData.Instance.InputVectorX = inputData.x;
                PlayerMovement_InputData.Instance.InputVectorY = inputData.y;
            }
            
            void LookInput(InputAction.CallbackContext context)
            {
                Vector2 inputData = context.ReadValue<Vector2>();
                Camera_InputData.Instance.InputVectorX = inputData.x;
                Camera_InputData.Instance.InputVectorY = inputData.y;
                PlayerExamination_InputData.Instance.InputVectorX = inputData.x;
                PlayerExamination_InputData.Instance.InputVectorY = inputData.y;
            }
            
            void ZoomLookInput()
            {
                Camera_InputData.Instance.ZoomClicked = inputActions.Player.ZoomLookPressed.triggered;
                Camera_InputData.Instance.ZoomReleased = inputActions.Player.ZoomLookReleased.triggered;
            }

            void GetMovementInputData()
            {
                PlayerMovement_InputData.Instance.RunClicked =  inputActions.Player.SprintPressed.triggered;
                PlayerMovement_InputData.Instance.RunReleased = inputActions.Player.SprintReleased.triggered;

                if(PlayerMovement_InputData.Instance.RunClicked)
                    PlayerMovement_InputData.Instance.IsRunning = true;

                if(PlayerMovement_InputData.Instance.RunReleased)
                    PlayerMovement_InputData.Instance.IsRunning = false;

                PlayerMovement_InputData.Instance.JumpClicked = inputActions.Player.JumpPressed.triggered;
                PlayerMovement_InputData.Instance.CrouchClicked = inputActions.Player.CrouchPressed.triggered;
                PlayerMovement_InputData.Instance.ShootPressed = inputActions.Player.Shoot.triggered;
            }

            void GetInteractionInputData()
            {
                PlayerInteraction_InputData.Instance.InteractionKeyPressed = inputActions.Player.InteractionPressed.triggered;
                PlayerInteraction_InputData.Instance.InteractionKeyHolded = interactionKeyHolded;
/*                PlayerInteraction_InputData.Instance.PickupKeyPressed = inputActions.Player.PickUpPressed.triggered;*/
            }

            void GetExaminationInputData()
            {

                PlayerExamination_InputData.Instance.ExaminationButtonisHolding = inputActions.Player.ZoomLookPressed.triggered;
                PlayerExamination_InputData.Instance.ExaminationButtonReleased = inputActions.Player.ZoomLookReleased.triggered;
            }
            
            void GetPointPickUpInputData()
            {
/*                PlayerPointPickUp_InputData.Instance.IsKeyPressed = inputActions.Player.PickUpPressed.triggered;*/
                /*PlayerPointPickUp_InputData.Instance.IsExamineKeyHolded = Input.GetKey(KeyCode.O);*/
            }
            
            void GetSignPlacementInputData()
            {
                NavigationSignPlacement_InputData.Instance.IsKeyHolded = navigationSignPlacerHolded;
                NavigationSignPlacement_InputData.Instance.Printed = inputActions.Player.NavigationSignPaintPressed.triggered;

                NavigationSignPlacement_InputData.Instance.FirstOneIsSelected = inputActions.Player.NavigationSign1.triggered;
                NavigationSignPlacement_InputData.Instance.SecondOneIsSelected = inputActions.Player.NavigationSign2.triggered;
                NavigationSignPlacement_InputData.Instance.ThirdOneIsSelected = inputActions.Player.NavigationSign3.triggered;
                NavigationSignPlacement_InputData.Instance.ForthOneIsSelected = inputActions.Player.NavigationSign4.triggered;
            } 
            void GetUIInputData()
            {
                UI_InputData.Instance.InventoryUIKeyPressed = inputActions.Player.InventoryOpen.triggered; ;
                /*UI_InputData.Instance.GameMenuUI_KeyPressed = Input.GetKeyDown(KeyCode.Escape);*/
            }
        #endregion
    }
}