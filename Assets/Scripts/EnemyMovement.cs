using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform player; // Objetivo al que se dirige el enemigo
    private NavMeshAgent navMeshAgent; // Componente NavMeshAgent del enemigo

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>(); // Obtiene el componente NavMeshAgent del enemigo
    }

    // Update sirve para actualizar el estado del enemigo en cada frame
    void Update()
    {
        if (player != null) // Si el objetivo al que se dirige el enemigo no es nulo
        {
            navMeshAgent.SetDestination(player.position); // Establece la posicion del objetivo al que se dirige el enemigo
        }
    }
}
