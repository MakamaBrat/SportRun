using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    [Header("Movement")]
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    [Header("Jump Cooldown")]
    public float jumpCooldown = 3f;


    private Rigidbody2D rb;
    private float moveInput;

    private bool canJump = true;

    private Vector3 originalScale;
    public AudioSource au;

    // 👇 ВАЖНО: ссылка на корутину спавна
    private Coroutine spawnCoroutine;

    void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;

        canJump = true;
     
    }

    void Update()
    {
        // Поворот персонажа
        if (moveInput > 0)
            transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        else if (moveInput < 0)
            transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    // --------------------
    // СЕНСОРНЫЕ КНОПКИ
    // --------------------

    public void MoveLeftDown()
    {
        moveInput = -1f;
      
    }

    public void MoveRightDown()
    {
        moveInput = 1f;
     
    }

    public void MoveStop()
    {
        moveInput = 0f;
       
    }

    public void JumpButton()
    {
        if (!canJump) return;

        canJump = false;
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

        StartCoroutine(JumpCooldownRoutine());

        if (au != null)
            au.Play();
    }

    IEnumerator JumpCooldownRoutine()
    {
        yield return new WaitForSeconds(jumpCooldown);
        canJump = true;
    }

    // --------------------
    // SPAWN
    // --------------------

  
}
