using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb; // Rigidbody del jugador para poder moverlo
    private float movementX; // Movimiento en el eje X
    private float movementY; // Movimiento en el eje Y
    public float speed = 0; // Velocidad del jugador
    public TextMeshProUGUI countText; // Texto que muestra el contador de objetos recogidos
    public GameObject winTextObject; // Texto que muestra que el jugador ha ganado
    private int count; // Contador de objetos recogidos

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtiene el Rigidbody del jugador
        count = 0; // Inicializa el contador de objetos recogidos
        SetCountText(); // Actualiza el contador de objetos recogidos
        winTextObject.SetActive(false); // Desactiva el texto que muestra que el jugador ha ganado
    }

    // La funcion FixedUpdate se llama una vez por frame y sirve para mover objetos fisicos
    private void FixedUpdate()
    {
        // Mueve al jugador en la direccion que se le indique
        Vector3 movement = new Vector3(movementX, 0.0f, movementY); // Vector de movimiento que hace que el jugador se mueva en la direccion que se le indique
        rb.AddForce(movement * speed); // Mueve al jugador en la direccion que se le indique con la velocidad que se le indique
    }

    // La función OnTriggerEnter sirve para detectar colisiones con otros objetos, recibe como parametro el objeto con el que colisiona
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp")) // Si el objeto con el que colisiona el jugador tiene la etiqueta "PickUp"
        {
            other.gameObject.SetActive(false); // Desactiva el objeto con el que colisiona el jugador
            count = count + 1; // Aumenta el contador de objetos recogidos
            SetCountText(); // Actualiza el contador de objetos recogidos
        }
    }

    // Esta función hace que el jugador se mueva en la dirección que se le indique
void OnMove(InputValue movementValue)
{
    // Verifica si únicamente las teclas de flecha están siendo presionadas
    if (Keyboard.current.upArrowKey.isPressed || 
        Keyboard.current.downArrowKey.isPressed || 
        Keyboard.current.leftArrowKey.isPressed || 
        Keyboard.current.rightArrowKey.isPressed)
    {
        Vector2 movementVector = movementValue.Get<Vector2>(); // Obtiene el vector de movimiento

        // Limitar el movimiento al uso exclusivo de las flechas
        movementX = Keyboard.current.rightArrowKey.isPressed ? 1 : Keyboard.current.leftArrowKey.isPressed ? -1 : 0;
        movementY = Keyboard.current.upArrowKey.isPressed ? 1 : Keyboard.current.downArrowKey.isPressed ? -1 : 0;
    }
    else
    {
        // Detener el movimiento si no se presionan las flechas
        movementX = 0;
        movementY = 0;
    }
}


    // Esta funcion se llama cuando el jugador recoge un objeto y actualiza el contador de objetos recogidos
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString(); // Muestra el contador de objetos recogidos en la pantalla
        if (count >= 12) // Si el contador de objetos recogidos es mayor o igual a 12
        {
            winTextObject.SetActive(true); // Activa el texto que muestra que el jugador ha ganado
            Destroy(GameObject.FindWithTag("Enemy")); // Destruye al enemigo
        }
    }
    
    // La funcion OnCollisionEnter se llama cuando el jugador colisiona con otro objeto, recibe como parametro el objeto con el que colisiona
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // Si el objeto con el que colisiona el jugador tiene la etiqueta "Enemy"
        {
            Destroy(gameObject); // Destruye al jugador
            winTextObject.gameObject.SetActive(true); // Activa el texto que muestra que el jugador ha perdido
            winTextObject.GetComponent<TextMeshProUGUI>().text = "Game Over!"; // Muestra el texto "Game Over!" en la pantalla
        }
    }
    
}
