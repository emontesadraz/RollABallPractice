using UnityEngine;

public class Torreta : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform shootingPoint;
    public float fireRate = 1f;  // Tiempo entre disparos
    private float nextFireTime = 0f;

    private Transform player; // Aseguramos que esta variable es de la clase y accesible en todos los métodos

    void Start()
    {
        // Buscar al jugador por su tag
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("No se encontró un objeto con el tag 'Player'. Asegúrate de que el jugador tiene el tag correcto.");
        }
    }

    void Update()
    {
        if (player == null) return; // Si el jugador no existe, no hacer nada

        // Dispara el proyectil en intervalos regulares
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        if (player == null) return; // Evitar errores si no hay jugador

        // Calcular dirección hacia el jugador
        Vector3 direction = (player.position - shootingPoint.position).normalized;

        // Instanciar el proyectil y hacer que mire hacia el jugador
        GameObject projectile = Instantiate(projectilePrefab, shootingPoint.position, Quaternion.LookRotation(direction));
    }
}
