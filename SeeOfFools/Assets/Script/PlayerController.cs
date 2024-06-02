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
        playerSpriteRenderer = GetComponent<SpriteRenderer>();//스프라이트 관리
        anim.SetBool("isWalking", false); //초기 애니메이션 설정
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
            if (GameManager.Instance.isCannon1 == false) //대포 비활성화시
            {
                if (Input.GetKey(KeyCode.A) && this.transform.position.x >= -1.2f) //키입력, 오브젝트 이동범위 제한
                {
                    movement(); //동작 함수
                    playerSpriteRenderer.flipX = true; //스프라이트 반전
                    anim.SetBool("isWalking", true); //애니매이션 관리
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
                else anim.SetBool("isWalking", false); //키입력 없을때 애니메이션 종료
            }
            else //대포 활성화시 좌우 이동만 활성화
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
            if (Input.GetKey(KeyCode.A) && this.transform.position.x >= -6.5f) //키입력, 오브젝트 이동범위 제한
            {
                movement(); //동작 함수
                playerSpriteRenderer.flipX = true; //스프라이트 반전
                anim.SetBool("isWalking", true); //애니매이션 관리
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
            else anim.SetBool("isWalking", false); //키입력 없을때 애니메이션 종료

        }

    }

    void movement() //이동 관리 함수
    {
        float x = Input.GetAxisRaw("Horizontal");//키보드 좌우
        float y = Input.GetAxisRaw("Vertical");//키보드 상하
        Vector3 moveVelocity = new Vector3(x, y, 0) * speed * Time.deltaTime; // 입력받은 상하좌우로 이동
        this.transform.position += moveVelocity; //오브젝트 이동
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Cannon1") //대포 활성화 부분과 충돌시
        {
            if (Input.GetKey(KeyCode.E))
            {
                GameManager.Instance.isCannon1 = true;//대포 활성화
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
