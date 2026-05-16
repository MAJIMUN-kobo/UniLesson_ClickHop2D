using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header(">> Sound Settings")]
    public AudioClip BoundSEClip;
    public AudioClip ClickSEClip;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            Rigidbody2D rb2d = GetComponent<Rigidbody2D>();

            rb2d.AddForce(new Vector3(Random.Range(-5.0f, 5.0f) ,5.0f), ForceMode2D.Impulse);
            rb2d.AddTorque(Random.Range(-45.0f, 45.0f));

            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(ClickSEClip);
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Wall")
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(BoundSEClip);
        }
    }
}
