using UnityEngine;

public class Jump : MonoBehaviour
{
    //public GameControl gameC;
    public float jumpForce = 5f; // Zýplama kuvveti
    public float groundCheckDistance = 1.1f; // Zemini kontrol etme mesafesi
    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Zemin kontrolü
        //if (gameC.gameActive)
        
            isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance);

            if (isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        
    }

    // Bu metodu görselleþtirme amacýyla kullanabilirsiniz
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance);
    }
}
