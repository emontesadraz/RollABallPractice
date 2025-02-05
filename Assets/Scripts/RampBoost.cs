using UnityEngine;

public class RampBoost : MonoBehaviour
{
    public float boostForce = 10f; // Fuerza del empujón
    public Vector3 boostDirection = Vector3.up; // Dirección del empujón

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Verifica si es el jugador
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(boostDirection.normalized * boostForce, ForceMode.Impulse);
            }
        }
    }
}
