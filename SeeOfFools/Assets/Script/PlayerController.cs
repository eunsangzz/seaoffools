using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    GameObject manager;
    public Rigidbody2D rb;

    public float speed = 100;

    public Animator anim;

    private SpriteRenderer playerSpriteRenderer;

    void Start()
    {
        playerSpriteRenderer = GetComponent<SpriteRenderer>();//��������Ʈ ����
        anim.SetBool("isWalking", false); //�ʱ� �ִϸ��̼� ����
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "MainScene")
        {
            if (GameManager.Instance.isCannon1 == false) //���� ��Ȱ��ȭ��
            {
                if (Input.GetKey(KeyCode.A) && this.transform.position.x >= -1.2f) //Ű�Է�, ������Ʈ �̵����� ����
                {
                    movement(); //���� �Լ�
                    playerSpriteRenderer.flipX = true; //��������Ʈ ����
                    anim.SetBool("isWalking", true); //�ִϸ��̼� ����
                }
                else if (Input.GetKey(KeyCode.D) && this.transform.position.x <= 0.7f)
                {
                    movement();
                    playerSpriteRenderer.flipX = false;
                    anim.SetBool("isWalking", true);
                }
                else if (Input.GetKey(KeyCode.W) && this.transform.position.y <= -2.5f)
                {
                    movement();
                    anim.SetBool("isWalking", true);
                }
                else if (Input.GetKey(KeyCode.S) && this.transform.position.y >= -3.6f)
                {
                    movement();
                    anim.SetBool("isWalking", true);
                }
                else anim.SetBool("isWalking", false); //Ű�Է� ������ �ִϸ��̼� ����
            }
            else //���� Ȱ��ȭ�� �¿� �̵��� Ȱ��ȭ
            {
                if (Input.GetKey(KeyCode.A) && this.transform.position.x >= -1.2f)
                {
                    movement();
                    playerSpriteRenderer.flipX = true;
                    anim.SetBool("isWalking", true);
                }
                else if (Input.GetKey(KeyCode.D) && this.transform.position.x <= 0.7f)
                {
                    movement();
                    playerSpriteRenderer.flipX = false;
                    anim.SetBool("isWalking", true);
                }
                else anim.SetBool("isWalking", false);
            }
        }
        else if (scene.name == "SavePoint")
        {
            if (Input.GetKey(KeyCode.A) && this.transform.position.x >= -6.5f) //Ű�Է�, ������Ʈ �̵����� ����
            {
                movement(); //���� �Լ�
                playerSpriteRenderer.flipX = true; //��������Ʈ ����
                anim.SetBool("isWalking", true); //�ִϸ��̼� ����
            }
            else if (Input.GetKey(KeyCode.D) && this.transform.position.x <= 6.5f)
            {
                movement();
                playerSpriteRenderer.flipX = false;
                anim.SetBool("isWalking", true);
            }
            else if (Input.GetKey(KeyCode.W) && this.transform.position.y <= 3.0f)
            {
                movement();
                anim.SetBool("isWalking", true);
            }
            else if (Input.GetKey(KeyCode.S) && this.transform.position.y >= -3.0f)
            {
                movement();
                anim.SetBool("isWalking", true);
            }
            else anim.SetBool("isWalking", false); //Ű�Է� ������ �ִϸ��̼� ����

        }

    }

    void movement() //�̵� ���� �Լ�
    {
        float x = Input.GetAxisRaw("Horizontal");//Ű���� �¿�
        float y = Input.GetAxisRaw("Vertical");//Ű���� ����
        Vector3 moveVelocity = new Vector3(x, y, 0) * speed * Time.deltaTime; // �Է¹��� �����¿�� �̵�
        this.transform.position += moveVelocity; //������Ʈ �̵�
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Cannon1") //���� Ȱ��ȭ �κа� �浹��
        {
            if (Input.GetKey(KeyCode.E))
            {
                GameManager.Instance.isCannon1 = true;//���� Ȱ��ȭ
            }
        }
        if(collision.gameObject.name == "Brooks")
        {
            if(Input.GetKey(KeyCode.E))
            {
                GameManager.Instance.isUp = true;
            }
        }
        if(collision.gameObject.name == "Naiting")
        {
            if (Input.GetKey(KeyCode.E))
            {
                GameManager.Instance.isStory = true;
            }
        }
        if (collision.gameObject.name == "StartBattle")
        {
            GameManager.Instance.isStart = true;
        }
        if(collision.gameObject.name == "Key" && GameManager.Instance.isSlow == true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                GameManager.Instance.isRewind = true;
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "StartBattle")
        {
            GameManager.Instance.isStart = false;
        }
    }
}
