using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    private PlayerInput playerInput;
    private Vector2 m_input;
    private bool m_Moving;
    private bool isCleaningKeyPressed = false;
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerInput.actions["Clean"].performed += OnCleanKeyPressed;
    }
    void Update()
    {
        m_input = playerInput.actions["Move"].ReadValue<Vector2>();
        m_Moving = m_input.magnitude > 0;

        isCleaningKeyPressed = playerInput.actions["Clean"].IsPressed();
    }
    private void OnCleanKeyPressed(InputAction.CallbackContext context)
    {
        isCleaningKeyPressed = !isCleaningKeyPressed;
        // Debug.Log("Para limpiar" + isCleaningKeyPressed);
    }
    public Vector2 getInputMove{get{return m_input;}}
    public bool IsMoving{get{return m_Moving;}}
    public bool IsCleaningKeyPressed { get { return isCleaningKeyPressed; } }

}
