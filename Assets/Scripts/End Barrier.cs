using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class EndBarrier : MonoBehaviour
{
    public List<GameObject> enemies;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Remove inimigos nulos (que já foram destruídos)
        enemies.RemoveAll(enemy => enemy == null);

        // Se a lista estiver vazia, destrói a parede
        if (enemies.Count == 0)
        {
            Destroy(gameObject); // destrói a parede
        }
    }
}
