using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetMouseButtonDown( 0 ) ) {
            Debug.Log("クリックされたよ！！");

            GetComponent<Rigidbody2D>().AddForce(Vector3.up * 10 + Vector3.right * Random.Range( -5f, 5f ), ForceMode2D.Impulse);
        }
        
    }
}
