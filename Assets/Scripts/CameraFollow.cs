using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;        // O jogador
    public float smoothSpeed = 0.125f; // Suavidade do movimento
    public Vector3 offset;          // Dist�ncia da c�mera em rela��o ao player

    void LateUpdate()
    {
        if (target == null) return;

        // Posi��o desejada
        Vector3 desiredPosition = target.position + offset;

        // Suaviza o movimento (Lerp)
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Atualiza posi��o da c�mera
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
    }
}