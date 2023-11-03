using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour
{
    public float SpeedBase;
    public float DestroyWhen = -25f;
    private float FinalSpeed;

    // Start is called before the first frame update
    void Start()
    {

        transform.position = new Vector3(transform.position.x, Random.Range(-4, 8), 10);
        var scale = Random.Range(0.1f, 0.5f);
        transform.localScale = new Vector3(scale, scale);
        FinalSpeed = SpeedBase * scale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3.left * FinalSpeed) * Time.deltaTime;
        DestroyIfIsPossible();
    }

    private void DestroyIfIsPossible()
    {
        if (transform.position.x < DestroyWhen)
        {
            Destroy(gameObject);
        }
    }
}
