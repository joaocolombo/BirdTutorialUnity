using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour
{
    public ManagerScript ManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        ManagerScript = GameObject.FindGameObjectWithTag("Manager").GetComponent<ManagerScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
            ManagerScript.GameOver();
    }
}
