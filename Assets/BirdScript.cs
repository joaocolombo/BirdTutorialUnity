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
    public GameObject WingUp;
    public GameObject WingDown;
    float r;


    // Start is called before the first frame update
    void Start()
    {
        ManagerScript = GameObject.FindGameObjectWithTag("Manager").GetComponent<ManagerScript>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (IsAlive is false)
            return;
        Fly();
        if (DistanceLastFrame() < 0f)
            Fall();
        LastPositionY = transform.position.y;

    }

    private void Fall()
    {
        if (transform.rotation.z < AngleRotation)
        {
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.z, -AngleRotation, ref r, SmoothRotation);
            transform.rotation = Quaternion.Euler(0, 0, angle);
            WingUp.SetActive(true);
            WingDown.SetActive(false);
        }
    }

    private float DistanceLastFrame()
    {
        return (transform.position.y - LastPositionY) * Time.deltaTime;
    }

    private void Flap()
    {
        rb.velocity = Vector2.up * FlapStrength;
    }

    private void Fly()
    {
        if (DistanceLastFrame() > 0f && transform.rotation.z > -AngleRotation)
        {
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.z, AngleRotation, ref r, SmoothRotation);
            transform.rotation = Quaternion.Euler(0, 0, angle);
            WingUp.SetActive(false);
            WingDown.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Space))
            Flap();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ManagerScript.GameOver();
        BirdDied();
    }

    private void BirdDied() => IsAlive = false;

}
