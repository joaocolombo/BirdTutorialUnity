using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public ManagerScript ManagerScript;
    public float FlapStrength;
    public bool IsAlive = true;
    private float LastPositionY;
    public float SmoothRotation;
    public float AngleRotation;
    float r;


    // Start is called before the first frame update
    void Start()
    {
        ManagerScript = GameObject.FindGameObjectWithTag("Manager").GetComponent<ManagerScript>();
        transform.Rotate(new Vector3(0, 0, -45));
    }

    // Update is called once per frame
    void Update()
    {
        Flap();
        Direction();
    }

    private void Direction()
    {
        var distancePerSecondSinceLastFrame = (transform.position.y - LastPositionY) * Time.deltaTime;
        LastPositionY = transform.position.y;
        if (distancePerSecondSinceLastFrame < 0f && transform.rotation.z < AngleRotation)
        {
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.z, -AngleRotation, ref r, SmoothRotation);
            transform.rotation = Quaternion.Euler(0,0,angle);
        }

        if (distancePerSecondSinceLastFrame > 0f && transform.rotation.z > -AngleRotation)
        {
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.z, AngleRotation, ref r, SmoothRotation);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
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
