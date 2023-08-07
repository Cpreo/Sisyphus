//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Input/ConvoControls.inputactions
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

public partial class @ConvoControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @ConvoControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ConvoControls"",
    ""maps"": [
        {
            ""name"": ""Convo"",
            ""id"": ""419b16d9-7aec-474c-be42-383065a84d72"",
            ""actions"": [
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""e446856c-0f08-411e-8dd7-76aa1c9795c4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b2219271-cd9e-4152-93ac-e7469bbab246"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Convo
        m_Convo = asset.FindActionMap("Convo", throwIfNotFound: true);
        m_Convo_MousePosition = m_Convo.FindAction("MousePosition", throwIfNotFound: true);
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

    // Convo
    private readonly InputActionMap m_Convo;
    private IConvoActions m_ConvoActionsCallbackInterface;
    private readonly InputAction m_Convo_MousePosition;
    public struct ConvoActions
    {
        private @ConvoControls m_Wrapper;
        public ConvoActions(@ConvoControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MousePosition => m_Wrapper.m_Convo_MousePosition;
        public InputActionMap Get() { return m_Wrapper.m_Convo; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ConvoActions set) { return set.Get(); }
        public void SetCallbacks(IConvoActions instance)
        {
            if (m_Wrapper.m_ConvoActionsCallbackInterface != null)
            {
                @MousePosition.started -= m_Wrapper.m_ConvoActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_ConvoActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_ConvoActionsCallbackInterface.OnMousePosition;
            }
            m_Wrapper.m_ConvoActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
            }
        }
    }
    public ConvoActions @Convo => new ConvoActions(this);
    public interface IConvoActions
    {
        void OnMousePosition(InputAction.CallbackContext context);
    }
}
