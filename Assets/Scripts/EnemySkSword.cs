using UnityEngine;

public class EnemySkSword : MonoBehaviour
{
    [Header("Enemy Status")]
    public float maxEnemyLife = 60f;

    //public GameObject player;
    public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("KuroAtk"))
        {
            animator.SetTrigger("GetHit");
            Debug.Log("Esqueleto ta morrendo");
        }
    }
}
