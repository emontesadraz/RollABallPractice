using UnityEngine;

public class ReiniciarJugador : MonoBehaviour
{
    public Transform puntoDeReinicio; // Asigna un objeto vacío en la escena como punto de reinicio

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Asegúrate de que el jugador tiene el tag "Player"
        {
            other.transform.position = puntoDeReinicio.position; // Mueve al jugador al punto de reinicio
        }
    }
}
