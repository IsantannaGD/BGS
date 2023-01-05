//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/_project/Script/Input/InputBinder.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @InputBinder : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputBinder()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputBinder"",
    ""maps"": [
        {
            ""name"": ""Keyboard"",
            ""id"": ""e8c66c2e-b507-496f-bbf1-18330d98a105"",
            ""actions"": [
                {
                    ""name"": ""RightMove"",
                    ""type"": ""Button"",
                    ""id"": ""afed72af-ecc6-4804-8e49-57c7b82fcd49"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LeftMove"",
                    ""type"": ""Button"",
                    ""id"": ""0f419677-6907-42e4-a7f3-91740101ebec"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""DownMove"",
                    ""type"": ""Button"",
                    ""id"": ""62edd8cc-9854-4f8e-aeb4-cdb56487a54f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""UpMove"",
                    ""type"": ""Button"",
                    ""id"": ""8766607d-85de-4607-9d3c-f4e37138e846"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interactive"",
                    ""type"": ""Button"",
                    ""id"": ""ae3e1b4f-dcaa-4a66-8e9d-4b27680a64d0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Inventory"",
                    ""type"": ""Button"",
                    ""id"": ""ddb2466a-d532-466c-b5ea-3f1db2c4f027"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ChangeScene"",
                    ""type"": ""Button"",
                    ""id"": ""689608eb-fe78-403d-b919-c3e5bb189c4d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c878957e-8b3a-46b1-a80d-98f781bb60fb"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7da0dae5-ae3d-468c-bc24-1cc95eece372"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9a106db8-8142-4226-99de-cff2153e305b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""67596def-d558-4688-83b4-705a8c34e89d"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""298c3b25-6699-468d-9c0b-fa59c6385c0c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DownMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9bf98459-ad56-42a7-b435-46a20eabef41"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DownMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""36a9c6ca-e779-44e5-b3e5-7b0aec439f54"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ea3d630c-fa0f-400d-af35-d3215497ced3"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c5b45373-86df-4430-89f5-16cdf077b49c"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interactive"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bfb34efb-d74a-4e8d-99e8-2ce9f3adae86"",
                    ""path"": ""<Keyboard>/numpadEnter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interactive"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""523d9bf4-19f6-4d6e-b977-53e0426faec7"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interactive"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7201c4a5-a939-46b0-a13d-f4bfeaacab5c"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0428be90-b6c8-4340-bc3b-81b8a450dafa"",
                    ""path"": ""<Keyboard>/f1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeScene"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Keyboard
        m_Keyboard = asset.FindActionMap("Keyboard", throwIfNotFound: true);
        m_Keyboard_RightMove = m_Keyboard.FindAction("RightMove", throwIfNotFound: true);
        m_Keyboard_LeftMove = m_Keyboard.FindAction("LeftMove", throwIfNotFound: true);
        m_Keyboard_DownMove = m_Keyboard.FindAction("DownMove", throwIfNotFound: true);
        m_Keyboard_UpMove = m_Keyboard.FindAction("UpMove", throwIfNotFound: true);
        m_Keyboard_Interactive = m_Keyboard.FindAction("Interactive", throwIfNotFound: true);
        m_Keyboard_Inventory = m_Keyboard.FindAction("Inventory", throwIfNotFound: true);
        m_Keyboard_ChangeScene = m_Keyboard.FindAction("ChangeScene", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Keyboard
    private readonly InputActionMap m_Keyboard;
    private IKeyboardActions m_KeyboardActionsCallbackInterface;
    private readonly InputAction m_Keyboard_RightMove;
    private readonly InputAction m_Keyboard_LeftMove;
    private readonly InputAction m_Keyboard_DownMove;
    private readonly InputAction m_Keyboard_UpMove;
    private readonly InputAction m_Keyboard_Interactive;
    private readonly InputAction m_Keyboard_Inventory;
    private readonly InputAction m_Keyboard_ChangeScene;
    public struct KeyboardActions
    {
        private @InputBinder m_Wrapper;
        public KeyboardActions(@InputBinder wrapper) { m_Wrapper = wrapper; }
        public InputAction @RightMove => m_Wrapper.m_Keyboard_RightMove;
        public InputAction @LeftMove => m_Wrapper.m_Keyboard_LeftMove;
        public InputAction @DownMove => m_Wrapper.m_Keyboard_DownMove;
        public InputAction @UpMove => m_Wrapper.m_Keyboard_UpMove;
        public InputAction @Interactive => m_Wrapper.m_Keyboard_Interactive;
        public InputAction @Inventory => m_Wrapper.m_Keyboard_Inventory;
        public InputAction @ChangeScene => m_Wrapper.m_Keyboard_ChangeScene;
        public InputActionMap Get() { return m_Wrapper.m_Keyboard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyboardActions set) { return set.Get(); }
        public void SetCallbacks(IKeyboardActions instance)
        {
            if (m_Wrapper.m_KeyboardActionsCallbackInterface != null)
            {
                @RightMove.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnRightMove;
                @RightMove.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnRightMove;
                @RightMove.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnRightMove;
                @LeftMove.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnLeftMove;
                @LeftMove.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnLeftMove;
                @LeftMove.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnLeftMove;
                @DownMove.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnDownMove;
                @DownMove.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnDownMove;
                @DownMove.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnDownMove;
                @UpMove.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnUpMove;
                @UpMove.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnUpMove;
                @UpMove.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnUpMove;
                @Interactive.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnInteractive;
                @Interactive.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnInteractive;
                @Interactive.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnInteractive;
                @Inventory.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnInventory;
                @Inventory.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnInventory;
                @Inventory.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnInventory;
                @ChangeScene.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnChangeScene;
                @ChangeScene.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnChangeScene;
                @ChangeScene.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnChangeScene;
            }
            m_Wrapper.m_KeyboardActionsCallbackInterface = instance;
            if (instance != null)
            {
                @RightMove.started += instance.OnRightMove;
                @RightMove.performed += instance.OnRightMove;
                @RightMove.canceled += instance.OnRightMove;
                @LeftMove.started += instance.OnLeftMove;
                @LeftMove.performed += instance.OnLeftMove;
                @LeftMove.canceled += instance.OnLeftMove;
                @DownMove.started += instance.OnDownMove;
                @DownMove.performed += instance.OnDownMove;
                @DownMove.canceled += instance.OnDownMove;
                @UpMove.started += instance.OnUpMove;
                @UpMove.performed += instance.OnUpMove;
                @UpMove.canceled += instance.OnUpMove;
                @Interactive.started += instance.OnInteractive;
                @Interactive.performed += instance.OnInteractive;
                @Interactive.canceled += instance.OnInteractive;
                @Inventory.started += instance.OnInventory;
                @Inventory.performed += instance.OnInventory;
                @Inventory.canceled += instance.OnInventory;
                @ChangeScene.started += instance.OnChangeScene;
                @ChangeScene.performed += instance.OnChangeScene;
                @ChangeScene.canceled += instance.OnChangeScene;
            }
        }
    }
    public KeyboardActions @Keyboard => new KeyboardActions(this);
    public interface IKeyboardActions
    {
        void OnRightMove(InputAction.CallbackContext context);
        void OnLeftMove(InputAction.CallbackContext context);
        void OnDownMove(InputAction.CallbackContext context);
        void OnUpMove(InputAction.CallbackContext context);
        void OnInteractive(InputAction.CallbackContext context);
        void OnInventory(InputAction.CallbackContext context);
        void OnChangeScene(InputAction.CallbackContext context);
    }
}
