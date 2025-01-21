using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonController : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento de la cámara

    void Update()
    {
        // Mover la cámara con W, A, S, D
        MoveCamera();
    }

    void MoveCamera()
    {
        float moveX = 0f;
        float moveZ = 0f;

        // Detectar las teclas W, A, S, D
        if (Keyboard.current.wKey.isPressed) moveZ = 1f;
        if (Keyboard.current.sKey.isPressed) moveZ = -1f;
        if (Keyboard.current.dKey.isPressed) moveX = 1f;
        if (Keyboard.current.aKey.isPressed) moveX = -1f;

        // Calcular la dirección de movimiento relativa a la cámara
        Vector3 moveDirection = transform.right * moveX + transform.forward * moveZ;

        // Aplicar movimiento a la cámara
        transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime;
    }
}
