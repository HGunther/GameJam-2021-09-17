using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float rotateSpeed;
    public float maxRotation;    
    private Vector2 m_rotationInput;

    void Start()
    {
        
    }

    public void OnInputRotatePlane(InputAction.CallbackContext context){
        m_rotationInput = context.ReadValue<Vector2>();
    }

    public void OnReturnToStartMenuPressed(InputAction.CallbackContext context){
        var returnToStartPressed = context.ReadValue<float>();
        if(returnToStartPressed > 0.0f)
           SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    void Update()
    {
        
    }

    private void Rotate(Vector2 rotationInput){
        if (rotationInput.magnitude < 0.1){
            return;
        }

        var rotation = transform.eulerAngles;
        if (Mathf.Abs(rotationInput.x) > 0.1){
            rotation.x += rotationInput.x * rotateSpeed * Time.deltaTime;
            if (rotation.x > 180){
                rotation.x = Mathf.Max(rotation.x, 360 -maxRotation);
            }
            else{
                rotation.x = Mathf.Min(rotation.x, maxRotation);
            }
        }
        rotation.y = 0.0f;
        if (Mathf.Abs(rotationInput.y) > 0.1){
            rotation.z += rotationInput.y * rotateSpeed * Time.deltaTime;
            if (rotation.z > 180){
                rotation.z = Mathf.Max(rotation.z, 360 -maxRotation);
            }
            else{
                rotation.z = Mathf.Min(rotation.z, maxRotation);
            }
        }
        transform.eulerAngles = rotation;
    }

    void FixedUpdate()
    {
        Rotate(m_rotationInput);
    }
}
