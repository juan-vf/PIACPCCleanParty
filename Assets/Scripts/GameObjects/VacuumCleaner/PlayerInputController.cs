using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    private PlayerInput playerInput;
    private Vector2 m_input;
    private bool m_Moving;
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        m_input = playerInput.actions["Move"].ReadValue<Vector2>();
        m_Moving = m_input.magnitude > 0;
        
    }
    public Vector2 getInputMove{get{return m_input;}}
    public bool IsMoving{get{return m_Moving;}}
}
