using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    [Range(0, 1)] public float chaseIntencity = 0.1f;

    public GameObject shockWavePrefab;

    public AudioSource audioSource;
    public AudioClip shotWaveSound;

    public TimeManager timeManager;

    private Vector3 mousePosition = new Vector3(0, 0, 0);
    private float shockWavePower = 0.0f;
    
    void Start()
    {
        timeManager = FindAnyObjectByType<TimeManager>();
    }
    
    void Update()
    {
        ChaseMousePointer();

        if (Input.GetMouseButton(0)) ChagePower();
        if (Input.GetMouseButtonUp(0)) ShockWave();
    }

    public void ChaseMousePointer()
    {
        if (timeManager.isPlaying == false) return;

        mousePosition = Input.mousePosition;

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        worldPosition.z = 0.0f;

        transform.position = Vector3.Lerp(transform.position, worldPosition, chaseIntencity);
    }

    public void ChagePower()
    {
        shockWavePower += Time.deltaTime;
        if(shockWavePower > 2.0f) shockWavePower = 2.0f;
    }
    
    public void ResetPower()
    {
        shockWavePower = 0.5f;
    }

    public void ShockWave()
    {
        CreateWave();
        ResetPower();
        PlaySE( shotWaveSound );
    }

    public void CreateWave()
    {
        GameObject shockWave = Instantiate(shockWavePrefab, transform.position, transform.rotation);
        ShockWave wave = shockWave.GetComponent<ShockWave>();
        wave.Initialize(shockWavePower * 2.0f);
        Destroy(shockWave, shockWavePower);
    }

    public void PlaySE(AudioClip se)
    {
        audioSource.pitch = shockWavePower + 0.5f;
        audioSource.PlayOneShot(se);
    }
}
