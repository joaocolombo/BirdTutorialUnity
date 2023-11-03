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
        var positionY = Random.Range(-4, 8);
        var newCloud =Instantiate(CloudPrefab, new Vector3(transform.position.x, positionY, 10), transform.rotation);
        var scale = Random.Range(0.1f, 0.5f);
        newCloud.transform.localScale = new Vector3(scale, scale);
    }
}
