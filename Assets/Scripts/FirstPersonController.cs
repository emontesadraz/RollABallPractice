using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonController : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento de la cámara

    void Update()
    {
        MoveAndRotateCamera();
    }

    void MoveAndRotateCamera()
    {
        float moveX = 0f;
        float moveZ = 0f;

        if (Keyboard.current.upArrowKey.isPressed) moveZ = 1f; // Si se presiona la tecla de flecha arriba, mover hacia adelante
        if (Keyboard.current.downArrowKey.isPressed) moveZ = -1f; // Si se presiona la tecla de flecha abajo, mover hacia atrás
        if (Keyboard.current.rightArrowKey.isPressed) moveX = 1f; // Si se presiona la tecla de flecha derecha, mover hacia la derecha
        if (Keyboard.current.leftArrowKey.isPressed) moveX = -1f; // Si se presiona la tecla de flecha izquierda, mover hacia la izquierda

        Vector3 moveDirection = new Vector3(moveX, 0f, moveZ); // Dirección de movimiento

        if (moveDirection != Vector3.zero) // Si hay movimiento
        {
            // Ajustar la rotación de la cámara para que mire en la dirección del movimiento
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f); // Reducir la velocidad de rotación
        }

        transform.position += moveDirection.normalized * (moveSpeed * 0.5f) * Time.deltaTime; // Reducir la velocidad de movimiento
    }
}