using System.Collections;
using UnityEngine;

public enum EProjectileType
{
    Water,
    Fire,
    Earth,
    Air
}


public class PhysicsTest : MonoBehaviour
{

    Rigidbody rb;
    public float jumpForce;
    public float speed;
    bool jump = false;
    float inputX, inputY;

    public float bulletSpeed;
    bool shoot = false;
    public GameObject bullet;
    public Transform bulletPos;

    [field: SerializeField] public static EProjectileType BulletType { get; private set; }


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {

        rb.velocity = new Vector3(0, 0, speed);

        BulletType = EProjectileType.Water;
    
    }

    // Update is called once per frame
    void Update()
    {

        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

        /*
        //Jump
        if (Input.GetKeyDown("space"))
        {
            rb.velocity += new Vector3(0, jumpForce, 0);
        }
        */

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            shoot = true;
            StartCoroutine(shooting());
        }

        if (Input.GetButtonUp("Fire1"))
        {
            shoot = false;
        }

        if (Input.GetKeyDown("1"))
        {
            BulletType = EProjectileType.Water;
            Debug.Log(BulletType);
        }
        if (Input.GetKeyDown("2"))
        {
            BulletType = EProjectileType.Fire;
            Debug.Log(BulletType);
        }
        if (Input.GetKeyDown("3"))
        {
            BulletType = EProjectileType.Earth;
            Debug.Log(BulletType);
        }
        if (Input.GetKeyDown("4"))
        {
            BulletType = EProjectileType.Air;
            Debug.Log(BulletType);
        }

    }

    private void FixedUpdate()
    {

        rb.velocity = new Vector3(inputX * speed, rb.velocity.y, inputY * speed);

        if (jump)
        {
            Jump();
        }

    }

    void Jump()
    {
        rb.AddForce(0, jumpForce, 0);
        jump = false;
    }

    void Shoot()
    {
        GameObject bulletSpawn = Instantiate(bullet, bulletPos.position, bullet.transform.rotation);
        bulletSpawn.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, bulletSpeed);

        Destroy(bulletSpawn, 3f);
    }

    IEnumerator shooting()
    {
        while (shoot)
        {
            Shoot();

            yield return new WaitForSeconds(0.1f);

        }
    }

}
