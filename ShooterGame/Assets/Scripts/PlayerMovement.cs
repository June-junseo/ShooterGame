using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;

    private Rigidbody rb;
    public float speed = 5f;

    private static readonly int MoveParam = Animator.StringToHash("Move");

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 input = new Vector3(h, 0f, v).normalized;

        float moveAmount = input.magnitude;
        animator.SetFloat(MoveParam, moveAmount, 0.1f, Time.deltaTime);


        Vector3 velocity = input * speed;
        rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);
    }
}
