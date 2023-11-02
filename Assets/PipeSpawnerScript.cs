using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    public GameObject PipePrefab;
    private float Timer = 0;
    public float SpawnRate = 2f;

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
            Instantiate(PipePrefab, transform.position, transform.rotation);
            Timer = 0;
        }
    }
}
