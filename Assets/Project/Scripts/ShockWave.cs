using UnityEngine;

public class ShockWave : MonoBehaviour
{
    public float spreadSpeed = 5.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Spread();
    }
    
    public void Initialize( float spread )
    {
        spreadSpeed = spread;
    }
    
    /// <summary>
    /// 
    /// </summary>
    public void Spread()
    {
        transform.localScale += new Vector3(spreadSpeed * Time.deltaTime, spreadSpeed * Time.deltaTime, 0);
    }
}
