using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.Rendering;

public class KuroController : MonoBehaviour
{
    //public static KuroController instance;

    [Header("Movimentação")]
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public float kuroDamage = 20f;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isTakingDamage = false;
    private bool isAttack = false;

    public Animator animator;
    public GameObject atkCollider;
    public GameObject pause;
    public GameObject gameover;

    [Header("UI")]
    public float maxHealth = 100f;
    public float currentHealth;

    //private void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    void Start()
    {
        Time.timeScale = 1f;
        rb = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;

        atkCollider.SetActive(false);
        pause.SetActive(false);
        gameover.SetActive(false);

        //if (DualSenseGamepadHID.current != null)
        //{
        //    Debug.Log("Dualsense detectado!");
        //}
        //else if (Gamepad.current != null)
        //{
        //    Debug.Log("Dualsense (genérico) detectado!");
        //}
        //else
        //{
        //    Debug.Log("Nenhum gamepad!");
        //}

        isTakingDamage = false ;
    }

    void Update()
    {
        if (!isTakingDamage && !isAttack)
        {
            // Movimento horizontal
            float moveInput = Input.GetAxisRaw("Horizontal");
            rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

            // Flip do personagem (olhar para esquerda/direita)
            if (moveInput > 0 && isGrounded)
            {
                transform.localScale = new Vector3(1, 1, 1);
                animator.SetBool("isRunning", true);
            }
            else if (moveInput < 0 && isGrounded)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                animator.SetBool("isRunning", true);
            }
            if (moveInput == 0)
            {
                animator.SetBool("isRunning", false);
            }

        }
        else
        {
            rb.linearVelocity = Vector3.zero;
            animator.SetBool("isRunning", false);
        }



        // Pulo
        if ((Input.GetKeyDown(KeyCode.Space) || Gamepad.current.buttonSouth.wasPressedThisFrame) && isGrounded && !isAttack)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
            animator.SetBool("isGrounded", false);
            animator.SetTrigger("Jump");
        }

        //Attack
        if ((Input.GetKeyDown(KeyCode.K) || Gamepad.current.buttonWest.wasPressedThisFrame) && !isTakingDamage)
        {
            StartCoroutine(SlashAttack());
        }

        // Falling
        //if (rb.linearVelocity.y < -0.1f && !isGrounded)
        //{
        //    animator.SetBool("Falling", true);
        //    Debug.Log("Caindo");
        //}
        //else
        //{
        //    animator.SetBool("Falling", false);
        //}

        //Pause
        if (Input.GetKeyDown(KeyCode.Escape) || Gamepad.current.startButton.wasPressedThisFrame)
        {
            Time.timeScale = 0;
            pause.SetActive(true);
        }

        //Debug Dano
        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    StartCoroutine(TakeDamage(maxHealth * 0.1f));

        //    Debug.Log("TomouDano");
        //}

        //var gp = Gamepad.current;

        //if (gp != null)
        //{
        //    Vector2 move = gp.leftStick.ReadValue();
        //    bool jump = gp.buttonSouth.wasPressedThisFrame;
        //}

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isGrounded", true);
        }
    }

    IEnumerator SlashAttack()
    {
        atkCollider.SetActive(true);
        isAttack = true;

        animator.SetTrigger("Attack");
        Debug.Log("Atacou!");
        yield return new WaitForSeconds(0.3f);

        isAttack = false;
        atkCollider.SetActive(false);
    }

    public IEnumerator TakeDamage(float amount)
    {
        if (currentHealth > 0)
        {
            isTakingDamage = true;

            currentHealth -= amount;
            FindFirstObjectByType<UIManager>().UpdatePlayerHealth(currentHealth);
            animator.SetTrigger("Hurt");

            yield return new WaitForSeconds(0.4f);

            isTakingDamage = false;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Time.timeScale = 0;
        gameover.SetActive(true);
    }
}
