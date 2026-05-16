using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnPrefab;
    public float spawnInterval = 2.0f;
    public float spawnIntervalTimer = 0.0f;

    public TimeManager timeManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeManager = FindAnyObjectByType<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        IntervalUpdate();
    }

    public void IntervalUpdate()
    {
        if (timeManager.isPlaying == false) return;

        spawnIntervalTimer += Time.deltaTime;
        if(spawnInterval < spawnIntervalTimer)
        {
            Spawn();
            ResetInterval();
        }
    }

    public void ResetInterval()
    {
        spawnIntervalTimer = 0;
    }

    public void Spawn()
    {
        Vector3 randomPosition = new Vector3(0, 0, 0);
        randomPosition.x = Random.Range(-7.5f, 7.5f);
        randomPosition.y = Random.Range(-4f, 4f);
        GameObject clone = Instantiate(spawnPrefab, randomPosition, transform.rotation);
    }
}
