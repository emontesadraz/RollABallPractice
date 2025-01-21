using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player; // Esto es un GameObject que se llama player que sirve para guardar el objeto que queremos seguir
    private Vector3 offset; // Esto es un Vector3 que se llama offset que sirve para guardar la distancia entre la cámara y el objeto que queremos seguir
    
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position; // Calculamos la distancia entre la cámara y el objeto que queremos seguir
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset; // Actualizamos la posición de la cámara para que siga al objeto que queremos seguir
    }
}
