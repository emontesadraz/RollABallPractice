using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampBoost : MonoBehaviour
{
    public float boostForce = 20f; // Ajusta la fuerza del boost

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Asegúrate de que la bola tiene el tag "Player"
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Obtener la normal de la superficie de la rampa
                RaycastHit hit;
                if (Physics.Raycast(other.transform.position, Vector3.down, out hit, 2f))
                {
                    Vector3 boostDirection = hit.normal + transform.forward; // Dirección combinada
                    boostDirection.Normalize(); // Normalizar para evitar que sea demasiado fuerte

                    rb.AddForce(boostDirection * boostForce, ForceMode.Impulse);
                }
            }
        }
    }
}