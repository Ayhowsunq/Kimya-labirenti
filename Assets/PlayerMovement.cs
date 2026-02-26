using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveDistance = 1f;
    public float moveSpeed = 5f;

    private bool isMoving = false;
    private Vector3 targetPosition;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetPosition = rb.position; // başlangıç pozisyonunu sabitle
    }

    void Update()
    {
        if (isMoving) return;

        if (Input.GetKeyDown(KeyCode.W))
            TryMove(Vector3.forward);

        if (Input.GetKeyDown(KeyCode.S))
            TryMove(Vector3.back);

        if (Input.GetKeyDown(KeyCode.A))
            TryMove(Vector3.left);

        if (Input.GetKeyDown(KeyCode.D))
            TryMove(Vector3.right);
    }

    void TryMove(Vector3 direction)
    {
        targetPosition = rb.position + direction * moveDistance;
        StartCoroutine(SmoothMove());
    }

    System.Collections.IEnumerator SmoothMove()
    {
        isMoving = true;

        while (Vector3.Distance(rb.position, targetPosition) > 0.01f)
        {
            rb.MovePosition(Vector3.MoveTowards(
                rb.position,
                targetPosition,
                moveSpeed * Time.deltaTime
            ));

            yield return null;
        }

        rb.MovePosition(targetPosition);
        isMoving = false;
    }
}