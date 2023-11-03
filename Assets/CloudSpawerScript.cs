using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CloudSpawerScript : MonoBehaviour
{
    public GameObject CloudPrefab;
    private float Timer;
    public float SpawnRate;

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
            Spawn();
            Timer = 0;
        }
    }

    private void Spawn()
    {
        Instantiate(CloudPrefab, transform.position, transform.rotation);
    }
}
