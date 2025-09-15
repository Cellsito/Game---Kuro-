using System.Collections;
using UnityEngine;


public class EnemySkSword : MonoBehaviour
{
    [Header("Enemy Status")]
    public float maxEnemyLife = 60f;
    public float currentEnemyLife;

    public float speed = 2f;     // velocidade do inimigo
    public float stopDistance = 0.5f; // distância mínima para parar
    public float detectionRange = 8f; // raio máximo para seguir o player
    public float enemyDamage = 25f;

    public GameObject target;
    public KuroController kuroController;

    //public GameObject player;
    public Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentEnemyLife = maxEnemyLife;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            float distance = Vector2.Distance(transform.position, target.transform.position);

            // Só segue o player se estiver dentro do range
            if (distance <= detectionRange && distance > stopDistance)
            {
                transform.position = Vector2.MoveTowards(
                    transform.position,
                    target.transform.position,
                    speed * Time.deltaTime
                );
            }
        }
    
            if (target.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(- 0.2f,0.2f,0.2f);
        }
        else
        {
            transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        }

        if (currentEnemyLife <= 0)
        {
            Destroy(this.gameObject);
        }   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (currentEnemyLife <= 0) return;

        speed = 0;

        if (collision.gameObject.CompareTag("KuroAtk"))
        {
            animator.SetTrigger("GetHit");
            Debug.Log("Esqueleto ta morrendo");
            currentEnemyLife = currentEnemyLife - kuroController.kuroDamage;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        speed = 2f;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("HAHAHAHAHAHAHAHAHAHA");
            animator.SetTrigger("Attack");
            StartCoroutine(kuroController.TakeDamage(enemyDamage));
            StartCoroutine(StopRightThere());
        }
    }

    IEnumerator StopRightThere()
    {
        speed = 0;
        Debug.Log("Paro");
        yield return new WaitForSeconds(0.4f);
        Debug.Log("Volto");
        speed = 2f;
    }
}
