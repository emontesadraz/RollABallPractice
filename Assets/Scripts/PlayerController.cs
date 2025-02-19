using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float speed = 5f;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    private int count;
    public GameObject InvisibleWall;
    public GameObject InvisibleWall2;

    public Renderer colores; // Para cambiar el color según el estado

    public enum PlayerState { Idle, Moving, Jumping }; // Estados del jugador
    public PlayerState currentState; // Estado actual
    private bool isMoving = false;
    public Animator animator; // Animator del jugador 
    public float jumpForce = 4f;
    private bool isGrounded = true; // Verifica si el jugador está en el suelo

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        // Buscar automáticamente el MeshRenderer si no está asignado
        if (colores == null)
        {
            colores = GetComponent<Renderer>();
            if (colores == null)
            {
                Debug.LogError("No se encontró un Renderer en el Player. Asegúrate de que el Player tiene un MeshRenderer.");
            }
        }

        count = 0;
        SetCountText();
        winTextObject.SetActive(false);

        currentState = PlayerState.Idle;
        UpdateState();
    }

    void Update()
    {
        // Solo permite saltar si está en el suelo
        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            currentState = PlayerState.Jumping;
            isGrounded = false; // Evita saltos en el aire
            UpdateState();
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);

        // Detectar si el jugador se está moviendo
        isMoving = rb.velocity.magnitude > 0.1f;

        // Actualizar el estado visual
        UpdateState();

        // Obtener datos del acelerómetro
        Vector3 acceleration = Input.acceleration;
        Vector3 gyroMovement = new Vector3(acceleration.x, 0.0f, acceleration.y);
        rb.AddForce(gyroMovement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();

            if (count == 1)
            {
                InvisibleWall.SetActive(false);
            }
            else if (count == 2)
            {
                InvisibleWall2.SetActive(false);
            }
        }
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;

        isMoving = movementX != 0 || movementY != 0;
        if (isMoving)
        {
            currentState = PlayerState.Moving;
        }
        else
        {
            currentState = PlayerState.Idle;
        }
        UpdateState();
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 3)
        {
            winTextObject.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Si toca el suelo, puede saltar
        {
            isGrounded = true;
            currentState = isMoving ? PlayerState.Moving : PlayerState.Idle;
            UpdateState();
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "Game Over!";
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Si deja de tocar el suelo
        {
            isGrounded = false;
        }
    }

    // Método para actualizar el color según el estado
    void UpdateState()
    {
        animator.SetBool("isMoving", currentState == PlayerState.Moving);
        animator.SetBool("isJumping", currentState == PlayerState.Jumping);

        if (currentState == PlayerState.Moving)
            colores.material.color = Color.green;
        else if (currentState == PlayerState.Jumping)
            colores.material.color = Color.blue;
        else
            colores.material.color = Color.red;
    }
}
