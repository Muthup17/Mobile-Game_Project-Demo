// GENERATED AUTOMATICALLY FROM 'Assets/Input System/PlayerActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Player_Actions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Player_Actions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""28248f20-a8ad-47f3-bf86-f535cb6381eb"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6ae4291d-7a76-4012-9628-97c17f011a87"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b66026e7-72ee-429c-89fa-b4e134808064"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ZoomLookPressed"",
                    ""type"": ""Button"",
                    ""id"": ""d5732021-a696-4863-9b70-25621a586bd3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ZoomLookReleased"",
                    ""type"": ""Button"",
                    ""id"": ""dd880ae4-7c7c-4475-bda9-0eb321535f34"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""SprintPressed"",
                    ""type"": ""Button"",
                    ""id"": ""9bcfa608-6d96-4769-8bd2-e6df1b5619f3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SprintReleased"",
                    ""type"": ""Button"",
                    ""id"": ""2c4c2fd8-71f2-4ae2-97be-53ad9615e72e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""JumpPressed"",
                    ""type"": ""Button"",
                    ""id"": ""a62ed86c-5397-41ed-b85e-74c7b3ffdb14"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CrouchPressed"",
                    ""type"": ""Button"",
                    ""id"": ""fe7f42ae-3998-430f-93a9-238b37723590"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""InteractionPressed"",
                    ""type"": ""Button"",
                    ""id"": ""d0efd8f3-bbc7-45fe-93d4-bf87d0f632f7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""InteractionHolded"",
                    ""type"": ""Button"",
                    ""id"": ""812e85b9-c8c2-4918-a5c0-b90cf4fd1fe1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""NavigationSignPlacerHolded"",
                    ""type"": ""Button"",
                    ""id"": ""87801b9a-c48d-4f87-8d54-07f3a65fc3c8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NavigationSignPaintPressed"",
                    ""type"": ""Button"",
                    ""id"": ""8ed5525b-cbfa-47f3-bd27-ad15b0be419a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NavigationSign1"",
                    ""type"": ""Button"",
                    ""id"": ""39599bf8-044d-4b5d-9e49-640acd29e2cd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NavigationSign2"",
                    ""type"": ""Button"",
                    ""id"": ""213c6da0-0ca8-4d8f-afb8-18d762acb72e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NavigationSign3"",
                    ""type"": ""Button"",
                    ""id"": ""54ae7663-a789-458d-a39f-f63cb74fb3fe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NavigationSign4"",
                    ""type"": ""Button"",
                    ""id"": ""9f8917a1-c655-4201-95c3-7b1a45c0d66b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""1d325d9c-385e-4a24-bb88-b2df3d987dc4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""InventoryOpen"",
                    ""type"": ""Button"",
                    ""id"": ""7738ed09-7850-45cb-bbe3-95a16cfafcaa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LevelComplete"",
                    ""type"": ""Button"",
                    ""id"": ""bd0108be-6063-459a-9a49-737b2940e19e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""InventoryStoreKeyPressed"",
                    ""type"": ""Button"",
                    ""id"": ""20f5964b-e4f7-4703-a842-48cecd16444e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DirectConsume"",
                    ""type"": ""Button"",
                    ""id"": ""3e79af9a-c01e-4ee5-8bce-f630c3145624"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""KeyBoard"",
                    ""id"": ""ed9a8a55-8e90-4908-9527-16be2f7f58ab"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""28554e1e-0d6c-43a3-8d43-64f9cceb635b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b7203fab-25aa-49ee-8fc0-f2d9f5f608eb"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""77a71269-dd20-4da8-93fd-5503f7277c76"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""90bb70c8-ef6d-414f-83b4-37f5b139b4c3"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""42d68246-01d5-4f72-9307-eb538b55a89e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""903a6905-c613-4b1e-b912-2a3d8ef681e2"",
                    ""path"": ""<XInputController>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8afe6a2b-69c9-4870-925f-538c22f0e624"",
                    ""path"": ""<XInputController>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4e720069-2631-4d40-b808-e99e41d98db3"",
                    ""path"": ""<XInputController>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""bcc349f1-7976-4753-8a1f-1dd12ef72628"",
                    ""path"": ""<XInputController>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9481b79e-7ffa-486e-b6f0-bdc8064c2284"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9ceb7ed0-98e5-4e82-ae96-4202c7c1473d"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fda39c01-9bf7-4109-b6aa-9a6725e5563b"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ZoomLookPressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6804fea3-4654-4406-b75b-3e7ae61f65ad"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ZoomLookPressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b5801e78-7b41-43f1-a839-13e97bc73710"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ZoomLookReleased"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""47c0c930-4ab0-4e79-9647-8628f6534a15"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ZoomLookReleased"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""85a78e4f-0d4c-4e7d-b6ef-b298ada8bd42"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SprintPressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a701799c-529e-4260-b72e-93520ddf70e5"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SprintPressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a92ef140-c0b2-4f53-b872-d45d9df76493"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SprintReleased"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3d3eb22a-e831-4abb-9b43-e61edaa9c5d5"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SprintReleased"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7f5bdf62-e775-4cb8-9880-00b6b9939648"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JumpPressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cb8ac4f9-e142-42bc-ac19-dde105ac9820"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JumpPressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3abc2bf2-91a7-4348-b577-4f368a5b0019"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CrouchPressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d9dd1269-ed0a-4193-8634-26e0c5fb70aa"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CrouchPressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""36bcf3f2-19c5-445e-b8c9-5b2c90b19321"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InteractionPressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5feea6d5-1313-4b8a-a2f6-779fe3f6bd40"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InteractionPressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ca395f47-27d3-40fa-8b36-cfdc37c0f6ec"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InteractionHolded"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eb9aaea7-e160-4d6d-9265-8fa89d094d29"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InteractionHolded"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2fa01cfa-7f99-4901-b280-16c3abb9f1f0"",
                    ""path"": ""<Keyboard>/n"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavigationSignPlacerHolded"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a570ab5f-e3e1-4e1c-beea-9d3a9fdf78c6"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavigationSignPlacerHolded"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""43f05fcc-20db-4d60-aec3-807f813a9a05"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavigationSignPaintPressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c37a386b-87f9-4ad4-85ac-226ff50cf373"",
                    ""path"": ""<Gamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavigationSignPaintPressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""feed03fe-e9a3-486f-b789-5cf9a2519a60"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavigationSign1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""53daa9c6-2b5e-4985-80af-5ee00b69ac5a"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavigationSign1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3097c4d0-e843-4d64-b950-dbe0ac6c9b80"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavigationSign2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d474c2aa-e19e-42b9-9541-172f28fa748a"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavigationSign2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ae6fcd88-6e51-4c33-bfdc-c70e50a61444"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavigationSign3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6a8fac4c-fc89-4188-9f2a-05cfeab498a4"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavigationSign3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""61658a0e-04f9-46eb-b5e8-c0ed7bbec84a"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavigationSign4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""07eae845-f6cc-445b-81cc-494a0de9ceb7"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavigationSign4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ff08513e-a781-4c79-8292-fdc0914d4e41"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4b330bbd-c48e-4323-9576-fcdd8766b8b0"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1f703bd6-9790-4f0e-ae7c-7cef870f24f6"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InventoryOpen"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""55cdb69d-3887-43f5-b2f9-dc2bdfdb920c"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InventoryOpen"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""43e533b0-f340-467b-bd2f-281ca8753822"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LevelComplete"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ed43cec3-3c28-4b66-9d98-c08e15567771"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InventoryStoreKeyPressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""277c48e5-552b-4d92-8ebb-da915515bab2"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InventoryStoreKeyPressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1d78f8b0-9224-48a4-83f2-375829130b4c"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DirectConsume"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Look = m_Player.FindAction("Look", throwIfNotFound: true);
        m_Player_ZoomLookPressed = m_Player.FindAction("ZoomLookPressed", throwIfNotFound: true);
        m_Player_ZoomLookReleased = m_Player.FindAction("ZoomLookReleased", throwIfNotFound: true);
        m_Player_SprintPressed = m_Player.FindAction("SprintPressed", throwIfNotFound: true);
        m_Player_SprintReleased = m_Player.FindAction("SprintReleased", throwIfNotFound: true);
        m_Player_JumpPressed = m_Player.FindAction("JumpPressed", throwIfNotFound: true);
        m_Player_CrouchPressed = m_Player.FindAction("CrouchPressed", throwIfNotFound: true);
        m_Player_InteractionPressed = m_Player.FindAction("InteractionPressed", throwIfNotFound: true);
        m_Player_InteractionHolded = m_Player.FindAction("InteractionHolded", throwIfNotFound: true);
        m_Player_NavigationSignPlacerHolded = m_Player.FindAction("NavigationSignPlacerHolded", throwIfNotFound: true);
        m_Player_NavigationSignPaintPressed = m_Player.FindAction("NavigationSignPaintPressed", throwIfNotFound: true);
        m_Player_NavigationSign1 = m_Player.FindAction("NavigationSign1", throwIfNotFound: true);
        m_Player_NavigationSign2 = m_Player.FindAction("NavigationSign2", throwIfNotFound: true);
        m_Player_NavigationSign3 = m_Player.FindAction("NavigationSign3", throwIfNotFound: true);
        m_Player_NavigationSign4 = m_Player.FindAction("NavigationSign4", throwIfNotFound: true);
        m_Player_Shoot = m_Player.FindAction("Shoot", throwIfNotFound: true);
        m_Player_InventoryOpen = m_Player.FindAction("InventoryOpen", throwIfNotFound: true);
        m_Player_LevelComplete = m_Player.FindAction("LevelComplete", throwIfNotFound: true);
        m_Player_InventoryStoreKeyPressed = m_Player.FindAction("InventoryStoreKeyPressed", throwIfNotFound: true);
        m_Player_DirectConsume = m_Player.FindAction("DirectConsume", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Look;
    private readonly InputAction m_Player_ZoomLookPressed;
    private readonly InputAction m_Player_ZoomLookReleased;
    private readonly InputAction m_Player_SprintPressed;
    private readonly InputAction m_Player_SprintReleased;
    private readonly InputAction m_Player_JumpPressed;
    private readonly InputAction m_Player_CrouchPressed;
    private readonly InputAction m_Player_InteractionPressed;
    private readonly InputAction m_Player_InteractionHolded;
    private readonly InputAction m_Player_NavigationSignPlacerHolded;
    private readonly InputAction m_Player_NavigationSignPaintPressed;
    private readonly InputAction m_Player_NavigationSign1;
    private readonly InputAction m_Player_NavigationSign2;
    private readonly InputAction m_Player_NavigationSign3;
    private readonly InputAction m_Player_NavigationSign4;
    private readonly InputAction m_Player_Shoot;
    private readonly InputAction m_Player_InventoryOpen;
    private readonly InputAction m_Player_LevelComplete;
    private readonly InputAction m_Player_InventoryStoreKeyPressed;
    private readonly InputAction m_Player_DirectConsume;
    public struct PlayerActions
    {
        private @Player_Actions m_Wrapper;
        public PlayerActions(@Player_Actions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Look => m_Wrapper.m_Player_Look;
        public InputAction @ZoomLookPressed => m_Wrapper.m_Player_ZoomLookPressed;
        public InputAction @ZoomLookReleased => m_Wrapper.m_Player_ZoomLookReleased;
        public InputAction @SprintPressed => m_Wrapper.m_Player_SprintPressed;
        public InputAction @SprintReleased => m_Wrapper.m_Player_SprintReleased;
        public InputAction @JumpPressed => m_Wrapper.m_Player_JumpPressed;
        public InputAction @CrouchPressed => m_Wrapper.m_Player_CrouchPressed;
        public InputAction @InteractionPressed => m_Wrapper.m_Player_InteractionPressed;
        public InputAction @InteractionHolded => m_Wrapper.m_Player_InteractionHolded;
        public InputAction @NavigationSignPlacerHolded => m_Wrapper.m_Player_NavigationSignPlacerHolded;
        public InputAction @NavigationSignPaintPressed => m_Wrapper.m_Player_NavigationSignPaintPressed;
        public InputAction @NavigationSign1 => m_Wrapper.m_Player_NavigationSign1;
        public InputAction @NavigationSign2 => m_Wrapper.m_Player_NavigationSign2;
        public InputAction @NavigationSign3 => m_Wrapper.m_Player_NavigationSign3;
        public InputAction @NavigationSign4 => m_Wrapper.m_Player_NavigationSign4;
        public InputAction @Shoot => m_Wrapper.m_Player_Shoot;
        public InputAction @InventoryOpen => m_Wrapper.m_Player_InventoryOpen;
        public InputAction @LevelComplete => m_Wrapper.m_Player_LevelComplete;
        public InputAction @InventoryStoreKeyPressed => m_Wrapper.m_Player_InventoryStoreKeyPressed;
        public InputAction @DirectConsume => m_Wrapper.m_Player_DirectConsume;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Look.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                @ZoomLookPressed.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnZoomLookPressed;
                @ZoomLookPressed.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnZoomLookPressed;
                @ZoomLookPressed.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnZoomLookPressed;
                @ZoomLookReleased.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnZoomLookReleased;
                @ZoomLookReleased.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnZoomLookReleased;
                @ZoomLookReleased.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnZoomLookReleased;
                @SprintPressed.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprintPressed;
                @SprintPressed.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprintPressed;
                @SprintPressed.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprintPressed;
                @SprintReleased.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprintReleased;
                @SprintReleased.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprintReleased;
                @SprintReleased.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprintReleased;
                @JumpPressed.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJumpPressed;
                @JumpPressed.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJumpPressed;
                @JumpPressed.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJumpPressed;
                @CrouchPressed.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouchPressed;
                @CrouchPressed.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouchPressed;
                @CrouchPressed.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouchPressed;
                @InteractionPressed.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteractionPressed;
                @InteractionPressed.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteractionPressed;
                @InteractionPressed.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteractionPressed;
                @InteractionHolded.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteractionHolded;
                @InteractionHolded.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteractionHolded;
                @InteractionHolded.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteractionHolded;
                @NavigationSignPlacerHolded.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNavigationSignPlacerHolded;
                @NavigationSignPlacerHolded.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNavigationSignPlacerHolded;
                @NavigationSignPlacerHolded.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNavigationSignPlacerHolded;
                @NavigationSignPaintPressed.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNavigationSignPaintPressed;
                @NavigationSignPaintPressed.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNavigationSignPaintPressed;
                @NavigationSignPaintPressed.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNavigationSignPaintPressed;
                @NavigationSign1.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNavigationSign1;
                @NavigationSign1.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNavigationSign1;
                @NavigationSign1.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNavigationSign1;
                @NavigationSign2.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNavigationSign2;
                @NavigationSign2.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNavigationSign2;
                @NavigationSign2.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNavigationSign2;
                @NavigationSign3.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNavigationSign3;
                @NavigationSign3.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNavigationSign3;
                @NavigationSign3.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNavigationSign3;
                @NavigationSign4.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNavigationSign4;
                @NavigationSign4.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNavigationSign4;
                @NavigationSign4.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNavigationSign4;
                @Shoot.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
                @InventoryOpen.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInventoryOpen;
                @InventoryOpen.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInventoryOpen;
                @InventoryOpen.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInventoryOpen;
                @LevelComplete.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLevelComplete;
                @LevelComplete.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLevelComplete;
                @LevelComplete.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLevelComplete;
                @InventoryStoreKeyPressed.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInventoryStoreKeyPressed;
                @InventoryStoreKeyPressed.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInventoryStoreKeyPressed;
                @InventoryStoreKeyPressed.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInventoryStoreKeyPressed;
                @DirectConsume.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDirectConsume;
                @DirectConsume.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDirectConsume;
                @DirectConsume.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDirectConsume;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @ZoomLookPressed.started += instance.OnZoomLookPressed;
                @ZoomLookPressed.performed += instance.OnZoomLookPressed;
                @ZoomLookPressed.canceled += instance.OnZoomLookPressed;
                @ZoomLookReleased.started += instance.OnZoomLookReleased;
                @ZoomLookReleased.performed += instance.OnZoomLookReleased;
                @ZoomLookReleased.canceled += instance.OnZoomLookReleased;
                @SprintPressed.started += instance.OnSprintPressed;
                @SprintPressed.performed += instance.OnSprintPressed;
                @SprintPressed.canceled += instance.OnSprintPressed;
                @SprintReleased.started += instance.OnSprintReleased;
                @SprintReleased.performed += instance.OnSprintReleased;
                @SprintReleased.canceled += instance.OnSprintReleased;
                @JumpPressed.started += instance.OnJumpPressed;
                @JumpPressed.performed += instance.OnJumpPressed;
                @JumpPressed.canceled += instance.OnJumpPressed;
                @CrouchPressed.started += instance.OnCrouchPressed;
                @CrouchPressed.performed += instance.OnCrouchPressed;
                @CrouchPressed.canceled += instance.OnCrouchPressed;
                @InteractionPressed.started += instance.OnInteractionPressed;
                @InteractionPressed.performed += instance.OnInteractionPressed;
                @InteractionPressed.canceled += instance.OnInteractionPressed;
                @InteractionHolded.started += instance.OnInteractionHolded;
                @InteractionHolded.performed += instance.OnInteractionHolded;
                @InteractionHolded.canceled += instance.OnInteractionHolded;
                @NavigationSignPlacerHolded.started += instance.OnNavigationSignPlacerHolded;
                @NavigationSignPlacerHolded.performed += instance.OnNavigationSignPlacerHolded;
                @NavigationSignPlacerHolded.canceled += instance.OnNavigationSignPlacerHolded;
                @NavigationSignPaintPressed.started += instance.OnNavigationSignPaintPressed;
                @NavigationSignPaintPressed.performed += instance.OnNavigationSignPaintPressed;
                @NavigationSignPaintPressed.canceled += instance.OnNavigationSignPaintPressed;
                @NavigationSign1.started += instance.OnNavigationSign1;
                @NavigationSign1.performed += instance.OnNavigationSign1;
                @NavigationSign1.canceled += instance.OnNavigationSign1;
                @NavigationSign2.started += instance.OnNavigationSign2;
                @NavigationSign2.performed += instance.OnNavigationSign2;
                @NavigationSign2.canceled += instance.OnNavigationSign2;
                @NavigationSign3.started += instance.OnNavigationSign3;
                @NavigationSign3.performed += instance.OnNavigationSign3;
                @NavigationSign3.canceled += instance.OnNavigationSign3;
                @NavigationSign4.started += instance.OnNavigationSign4;
                @NavigationSign4.performed += instance.OnNavigationSign4;
                @NavigationSign4.canceled += instance.OnNavigationSign4;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @InventoryOpen.started += instance.OnInventoryOpen;
                @InventoryOpen.performed += instance.OnInventoryOpen;
                @InventoryOpen.canceled += instance.OnInventoryOpen;
                @LevelComplete.started += instance.OnLevelComplete;
                @LevelComplete.performed += instance.OnLevelComplete;
                @LevelComplete.canceled += instance.OnLevelComplete;
                @InventoryStoreKeyPressed.started += instance.OnInventoryStoreKeyPressed;
                @InventoryStoreKeyPressed.performed += instance.OnInventoryStoreKeyPressed;
                @InventoryStoreKeyPressed.canceled += instance.OnInventoryStoreKeyPressed;
                @DirectConsume.started += instance.OnDirectConsume;
                @DirectConsume.performed += instance.OnDirectConsume;
                @DirectConsume.canceled += instance.OnDirectConsume;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnZoomLookPressed(InputAction.CallbackContext context);
        void OnZoomLookReleased(InputAction.CallbackContext context);
        void OnSprintPressed(InputAction.CallbackContext context);
        void OnSprintReleased(InputAction.CallbackContext context);
        void OnJumpPressed(InputAction.CallbackContext context);
        void OnCrouchPressed(InputAction.CallbackContext context);
        void OnInteractionPressed(InputAction.CallbackContext context);
        void OnInteractionHolded(InputAction.CallbackContext context);
        void OnNavigationSignPlacerHolded(InputAction.CallbackContext context);
        void OnNavigationSignPaintPressed(InputAction.CallbackContext context);
        void OnNavigationSign1(InputAction.CallbackContext context);
        void OnNavigationSign2(InputAction.CallbackContext context);
        void OnNavigationSign3(InputAction.CallbackContext context);
        void OnNavigationSign4(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnInventoryOpen(InputAction.CallbackContext context);
        void OnLevelComplete(InputAction.CallbackContext context);
        void OnInventoryStoreKeyPressed(InputAction.CallbackContext context);
        void OnDirectConsume(InputAction.CallbackContext context);
    }
}
