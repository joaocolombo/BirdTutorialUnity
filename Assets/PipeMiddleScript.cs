using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public ManagerScript ManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        ManagerScript = GameObject.FindGameObjectWithTag("Manager").GetComponent<ManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
            ManagerScript.AddScore(1);
    }
}
