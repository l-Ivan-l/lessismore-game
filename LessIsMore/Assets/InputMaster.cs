// GENERATED AUTOMATICALLY FROM 'Assets/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""PlayerActions"",
            ""id"": ""75846b2b-c8bd-404c-97a7-ce33c47e2f0c"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""ac39a55c-a619-40d6-8a8b-7632c4a03f4a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""10b4e03f-6faf-4b64-b166-4f9cc5993a2c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""HorizontalKeyboard"",
                    ""id"": ""d4506ae3-2170-4883-930d-590e394e07f6"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""6ed3aa25-ac1b-44cd-8037-232dc2e86324"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""8ca6283b-289b-4220-9953-f04468e2bf3b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""HorizontalDPad"",
                    ""id"": ""e061ffdc-f222-4fdc-9cb4-efec71237b27"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""07ea00b3-e091-41b7-88e7-39b74505c41e"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""be9d3110-2195-4c43-9641-c3a74b1b4cc2"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""HorizontalGamepad"",
                    ""id"": ""6063c1ea-4834-49c2-a526-7980be4faf0a"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": ""AxisDeadzone(min=0.9)"",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""f95ac46d-1a9e-4a51-b0cf-97b7c9892554"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""2ff69d41-b64c-42ed-87e2-87ff493905bf"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""db52bcc5-3893-4125-b56b-3fa0fd93b00d"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ea6fe0d2-4af4-44aa-8925-aed856b8bf82"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UIActions"",
            ""id"": ""deb4c144-361d-447c-a727-99b0f7c6c0b9"",
            ""actions"": [
                {
                    ""name"": ""Close/Return"",
                    ""type"": ""Button"",
                    ""id"": ""daffcc5e-4260-4f50-b7f3-5263f36c6508"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseNavigation"",
                    ""type"": ""Value"",
                    ""id"": ""1d82cd1a-d66e-4f01-ac2f-8d02041854bd"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""GamepadNavigation"",
                    ""type"": ""Value"",
                    ""id"": ""81f08f55-c8a7-4fbb-b29d-ed15c51d43c1"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Accept"",
                    ""type"": ""Button"",
                    ""id"": ""57b1c8d6-f2ee-4713-815a-568bccaa93f9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AcceptMouse"",
                    ""type"": ""Button"",
                    ""id"": ""10eb28b7-900c-432e-99c2-3ff3c0bc33d2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""831039b6-2b1e-4e3e-9b38-0c54d15678b2"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Close/Return"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0707efe4-d06e-400b-b37e-94103686dbad"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Close/Return"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""45705bd5-1723-4f83-9f33-94476cd9e2f9"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MouseNavigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cb5a23e4-cbae-47ae-a7fa-c545251dccdf"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""GamepadNavigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b70f41f0-ed08-4cc6-9022-48a40a093fa3"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Accept"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c2f40f48-a7f1-4d31-923b-4759c9065f3d"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""AcceptMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PlayerActions
        m_PlayerActions = asset.FindActionMap("PlayerActions", throwIfNotFound: true);
        m_PlayerActions_Movement = m_PlayerActions.FindAction("Movement", throwIfNotFound: true);
        m_PlayerActions_Jump = m_PlayerActions.FindAction("Jump", throwIfNotFound: true);
        // UIActions
        m_UIActions = asset.FindActionMap("UIActions", throwIfNotFound: true);
        m_UIActions_CloseReturn = m_UIActions.FindAction("Close/Return", throwIfNotFound: true);
        m_UIActions_MouseNavigation = m_UIActions.FindAction("MouseNavigation", throwIfNotFound: true);
        m_UIActions_GamepadNavigation = m_UIActions.FindAction("GamepadNavigation", throwIfNotFound: true);
        m_UIActions_Accept = m_UIActions.FindAction("Accept", throwIfNotFound: true);
        m_UIActions_AcceptMouse = m_UIActions.FindAction("AcceptMouse", throwIfNotFound: true);
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

    // PlayerActions
    private readonly InputActionMap m_PlayerActions;
    private IPlayerActionsActions m_PlayerActionsActionsCallbackInterface;
    private readonly InputAction m_PlayerActions_Movement;
    private readonly InputAction m_PlayerActions_Jump;
    public struct PlayerActionsActions
    {
        private @InputMaster m_Wrapper;
        public PlayerActionsActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerActions_Movement;
        public InputAction @Jump => m_Wrapper.m_PlayerActions_Jump;
        public InputActionMap Get() { return m_Wrapper.m_PlayerActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActionsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActionsActions instance)
        {
            if (m_Wrapper.m_PlayerActionsActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_PlayerActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public PlayerActionsActions @PlayerActions => new PlayerActionsActions(this);

    // UIActions
    private readonly InputActionMap m_UIActions;
    private IUIActionsActions m_UIActionsActionsCallbackInterface;
    private readonly InputAction m_UIActions_CloseReturn;
    private readonly InputAction m_UIActions_MouseNavigation;
    private readonly InputAction m_UIActions_GamepadNavigation;
    private readonly InputAction m_UIActions_Accept;
    private readonly InputAction m_UIActions_AcceptMouse;
    public struct UIActionsActions
    {
        private @InputMaster m_Wrapper;
        public UIActionsActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @CloseReturn => m_Wrapper.m_UIActions_CloseReturn;
        public InputAction @MouseNavigation => m_Wrapper.m_UIActions_MouseNavigation;
        public InputAction @GamepadNavigation => m_Wrapper.m_UIActions_GamepadNavigation;
        public InputAction @Accept => m_Wrapper.m_UIActions_Accept;
        public InputAction @AcceptMouse => m_Wrapper.m_UIActions_AcceptMouse;
        public InputActionMap Get() { return m_Wrapper.m_UIActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActionsActions set) { return set.Get(); }
        public void SetCallbacks(IUIActionsActions instance)
        {
            if (m_Wrapper.m_UIActionsActionsCallbackInterface != null)
            {
                @CloseReturn.started -= m_Wrapper.m_UIActionsActionsCallbackInterface.OnCloseReturn;
                @CloseReturn.performed -= m_Wrapper.m_UIActionsActionsCallbackInterface.OnCloseReturn;
                @CloseReturn.canceled -= m_Wrapper.m_UIActionsActionsCallbackInterface.OnCloseReturn;
                @MouseNavigation.started -= m_Wrapper.m_UIActionsActionsCallbackInterface.OnMouseNavigation;
                @MouseNavigation.performed -= m_Wrapper.m_UIActionsActionsCallbackInterface.OnMouseNavigation;
                @MouseNavigation.canceled -= m_Wrapper.m_UIActionsActionsCallbackInterface.OnMouseNavigation;
                @GamepadNavigation.started -= m_Wrapper.m_UIActionsActionsCallbackInterface.OnGamepadNavigation;
                @GamepadNavigation.performed -= m_Wrapper.m_UIActionsActionsCallbackInterface.OnGamepadNavigation;
                @GamepadNavigation.canceled -= m_Wrapper.m_UIActionsActionsCallbackInterface.OnGamepadNavigation;
                @Accept.started -= m_Wrapper.m_UIActionsActionsCallbackInterface.OnAccept;
                @Accept.performed -= m_Wrapper.m_UIActionsActionsCallbackInterface.OnAccept;
                @Accept.canceled -= m_Wrapper.m_UIActionsActionsCallbackInterface.OnAccept;
                @AcceptMouse.started -= m_Wrapper.m_UIActionsActionsCallbackInterface.OnAcceptMouse;
                @AcceptMouse.performed -= m_Wrapper.m_UIActionsActionsCallbackInterface.OnAcceptMouse;
                @AcceptMouse.canceled -= m_Wrapper.m_UIActionsActionsCallbackInterface.OnAcceptMouse;
            }
            m_Wrapper.m_UIActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @CloseReturn.started += instance.OnCloseReturn;
                @CloseReturn.performed += instance.OnCloseReturn;
                @CloseReturn.canceled += instance.OnCloseReturn;
                @MouseNavigation.started += instance.OnMouseNavigation;
                @MouseNavigation.performed += instance.OnMouseNavigation;
                @MouseNavigation.canceled += instance.OnMouseNavigation;
                @GamepadNavigation.started += instance.OnGamepadNavigation;
                @GamepadNavigation.performed += instance.OnGamepadNavigation;
                @GamepadNavigation.canceled += instance.OnGamepadNavigation;
                @Accept.started += instance.OnAccept;
                @Accept.performed += instance.OnAccept;
                @Accept.canceled += instance.OnAccept;
                @AcceptMouse.started += instance.OnAcceptMouse;
                @AcceptMouse.performed += instance.OnAcceptMouse;
                @AcceptMouse.canceled += instance.OnAcceptMouse;
            }
        }
    }
    public UIActionsActions @UIActions => new UIActionsActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IPlayerActionsActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
    public interface IUIActionsActions
    {
        void OnCloseReturn(InputAction.CallbackContext context);
        void OnMouseNavigation(InputAction.CallbackContext context);
        void OnGamepadNavigation(InputAction.CallbackContext context);
        void OnAccept(InputAction.CallbackContext context);
        void OnAcceptMouse(InputAction.CallbackContext context);
    }
}
