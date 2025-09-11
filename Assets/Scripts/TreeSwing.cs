using UnityEngine;

public class TreeSwing : MonoBehaviour
{
    public float amplitude = 5f;      // Ângulo máximo do balanço
    public float minSpeed = 0.5f;     // Velocidade mínima
    public float maxSpeed = 2.5f;     // Velocidade máxima

    private float speed;              // Velocidade final escolhida
    private float startRotation;

    void Start()
    {
        startRotation = transform.eulerAngles.z;
        speed = Random.Range(minSpeed, maxSpeed); // cada árvore pega uma velocidade aleatória
    }

    void Update()
    {
        float angle = Mathf.Sin(Time.time * speed) * amplitude;
        transform.rotation = Quaternion.Euler(0, 0, startRotation + angle);
    }
}