using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public ManagerScript ManagerScript;
    public float FlapStrength = 6f;
    public bool IsAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        ManagerScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<ManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Flap();
    }

    private void Flap()
    {
        if (IsAlive is false)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
            rb.velocity = Vector2.up * FlapStrength;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ManagerScript.GameOver();
        BirdDied();
    }

    private void BirdDied() => IsAlive = false;
}
