using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PlayerController : MonoBehaviour
{
    public float rotateSpeed;
    
    private Vector2 m_rotationInput;

    void Start()
    {
        
    }

    public void OnInputRotatePlane(InputAction.CallbackContext context){
        m_rotationInput = context.ReadValue<Vector2>();
    }

    void Update()
    {
        Rotate(m_rotationInput);
    }

    private void Rotate(Vector2 rotationInput){
        transform.Rotate(new Vector3(rotationInput.x, 0.0f, rotationInput.y));
    }

    void FixedUpdate()
    {
    }
}
