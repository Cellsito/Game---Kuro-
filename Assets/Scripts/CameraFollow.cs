using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;        // O jogador
    public float smoothSpeed = 0.125f; // Suavidade do movimento
    public Vector3 offset;          // Distância da câmera em relação ao player

    void LateUpdate()
    {
        if (target == null) return;

        // Posição desejada
        Vector3 desiredPosition = target.position + offset;

        // Suaviza o movimento (Lerp)
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Atualiza posição da câmera
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
    }
}