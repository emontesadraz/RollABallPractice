using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 1;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);  // El proyectil se destruye al chocar
        }
        else if (other.gameObject.CompareTag("Walls"))
        {
            Destroy(gameObject);  // El proyectil se destruye al chocar con una pared
        }
    }
}