using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip knockBackSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Wave")
        {
            Vector3 direction = collision.transform.position - transform.position;
            KnockBack(direction.normalized, 100.0f);

            ScoreManager scoreManager = FindAnyObjectByType<ScoreManager>();
            scoreManager.AddScore(10.0f);

            PlaySE( knockBackSound );
            Destroy(gameObject, 2.0f);
        }

        if(collision.transform.tag == "Enemy")
        {

        }
    }

    public void KnockBack(Vector3 direction, float power)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce( -direction * power, ForceMode2D.Impulse );
        rb.AddTorque(Random.Range(-power, power));
        rb.mass = 100.0f;
    }

    public void PlaySE( AudioClip se )
    {
        audioSource.PlayOneShot( se );
    }
}
