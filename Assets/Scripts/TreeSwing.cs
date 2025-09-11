using UnityEngine;

public class TreeSwing : MonoBehaviour
{
    public float amplitude = 5f;      // �ngulo m�ximo do balan�o
    public float minSpeed = 0.5f;     // Velocidade m�nima
    public float maxSpeed = 2.5f;     // Velocidade m�xima

    private float speed;              // Velocidade final escolhida
    private float startRotation;

    void Start()
    {
        startRotation = transform.eulerAngles.z;
        speed = Random.Range(minSpeed, maxSpeed); // cada �rvore pega uma velocidade aleat�ria
    }

    void Update()
    {
        float angle = Mathf.Sin(Time.time * speed) * amplitude;
        transform.rotation = Quaternion.Euler(0, 0, startRotation + angle);
    }
}