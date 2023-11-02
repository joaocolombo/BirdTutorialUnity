using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    public GameObject PipePrefab;
    private float Timer;
    public float SpawnRate = 1f;
    public float Highest = 5f;
    public float BonusPipeRate = 2f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Timer < SpawnRate)
        {
            Timer += Time.deltaTime;
        }
        else
        {
            SpawnPipe();
            Timer = 0;

        }
    }

    private void SpawnPipe()
    {
        if (IsBonusPipe())
            return;
        var high = transform.position.y + Highest;
        var low = transform.position.y - Highest;

        Instantiate(PipePrefab, new Vector3(transform.position.x, Random.Range(low, high)), transform.rotation);
    }

    private bool IsBonusPipe()
    {
        return Random.Range(0f, 10f) <= BonusPipeRate;
    }
}
