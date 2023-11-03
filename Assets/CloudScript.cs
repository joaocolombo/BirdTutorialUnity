using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour
{
    public float SpeedBase;
    public float DestroyWhen = -25f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3.left * SpeedBase) * Time.deltaTime;
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
