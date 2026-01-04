using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Поля класса (видимы во всех методах)
    public float moveSpeed = 5f;

    private Animator animator;
    private Rigidbody rb;

    void Awake()
    {
        // Берём компоненты с того же объекта
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 input = new Vector3(h, 0f, v);
        Vector3 move = input.normalized;

        // Поворот в сторону движения (если есть движение)
        if (move.sqrMagnitude > 0.0001f)
        {
            Quaternion targetRot = Quaternion.LookRotation(move, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, 10f * Time.deltaTime);
        }

        // Обновляем параметр аниматора
        animator.SetFloat("speed", move.magnitude * moveSpeed);
    }

    void FixedUpdate()
    {
        // Перемещение через физику (FixedUpdate)
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(h, 0f, v).normalized;

        rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
    }
}
