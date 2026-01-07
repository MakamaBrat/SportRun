using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveLeft2D : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;      // ����� �� �����
        rb.freezeRotation = true; // ����� �� ��������
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);
    }
}
