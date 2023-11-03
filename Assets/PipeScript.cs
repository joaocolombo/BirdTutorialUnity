using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    public float Speed = 5;
    public float DestroyPipeWhen = -25f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3.left * Speed) * Time.deltaTime;
        DestroyIfIsPossible();
    }

    private void DestroyIfIsPossible()
    {
        if (transform.position.x < DestroyPipeWhen)
        {
            Destroy(gameObject);
        }
    }
}
