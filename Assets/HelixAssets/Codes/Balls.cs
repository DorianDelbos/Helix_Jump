using UnityEngine;
using UnityEngine.SceneManagement;

public class Balls : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float bouciness = 5.0f;
    private int withoutBounce = 0;
    [SerializeField] private ParticleSystem particles;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Bounce acitions
        if (withoutBounce > 2)
            Destroy(collision.gameObject);

        withoutBounce = 0;

        // If is dead
        if (collision.gameObject.CompareTag("Death"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            GameManager.current.ScoreRegister = 0;
            return;
        }

        // Else
        rb.linearVelocity = transform.up * bouciness;
        particles.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Platform"))
        {
            GameManager.current.ScoreRegister += ++withoutBounce;
        }
    }
}
