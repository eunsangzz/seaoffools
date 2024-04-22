using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameObject manager;
    Vector3 pos;

    public float speed = 5;

    public Animator anim;

    private SpriteRenderer playerSpriteRenderer;

    void Start()
    {
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (GameManager.Instance.isCannon1 == false)
        {
            if (Input.GetKey(KeyCode.A) && pos.x >= -2.8f)
            {
                pos.x -= speed * Time.deltaTime;
                playerSpriteRenderer.flipX = true;
                anim.SetBool("isWalking", true);
            }
            else if (Input.GetKey(KeyCode.D) && pos.x <= 2.8f)
            {
                pos.x += speed * Time.deltaTime;
                playerSpriteRenderer.flipX = false;
                anim.SetBool("isWalking", true);
            }
            else if (Input.GetKey(KeyCode.W) && pos.y <= 1.2f)
            {
                pos.y += speed * Time.deltaTime;
                anim.SetBool("isWalking", true);
            }
            else if (Input.GetKey(KeyCode.S) && pos.y >= -3.0f)
            {
                pos.y -= speed * Time.deltaTime;
                anim.SetBool("isWalking", true);
            }
            else anim.SetBool("isWalking", false);
            transform.position = pos;
        }
        else if (GameManager.Instance.isCannon1 == true)
        {
            if (Input.GetKey(KeyCode.A) && pos.x >= -2.8f)
            {
                pos.x -= speed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.D) && pos.x <= 2.8f)
            {
                pos.x += speed * Time.deltaTime;
            }
            transform.position = pos;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Cannon1")
        {
            if (Input.GetKey(KeyCode.E))
            {
                GameManager.Instance.isCannon1 = true;
            }
        }
    }
}
