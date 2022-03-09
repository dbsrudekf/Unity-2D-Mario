using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    float fTime = 0.0f;
    float fLimitTime = 0.02f;
    float fSpeed = 5.0f;
    public float jumpPower = 10.0f;
    bool bIsFloor = false;
    bool bIsOverPower = false;

    float fPlayerHalfSize = 0.28f;
    float fWallHalfSize = 0.32f;

    public GameObject BulletPrefab;

    Rigidbody2D rRigidbody;
    SpriteRenderer spriteRenderer;
    Animator anim;
    BoxCollider2D BoxCollider;


    // Start is called before the first frame update
    void Awake()
    {
        rRigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        BoxCollider = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            //ºæ·¿»ý¼º          
            GameObject instance = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
        }
        if(Input.GetButtonUp("Horizontal"))
        {
            rRigidbody.velocity = new Vector2(rRigidbody.velocity.normalized.x * 0.5f, rRigidbody.velocity.y);
        }

        if (Input.GetButtonDown("Horizontal"))
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
 
        }

        if (Input.GetButtonDown("Jump") && !anim.GetBool("IsJumping") && !anim.GetBool("IsBigJumping"))
        {
            if(anim.GetBool("IsMushroomItem"))
            {
                rRigidbody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                anim.SetBool("IsBigJumping", true);
            }
            else
            {
                if(anim.GetBool("IsFireItem"))
                {
                    rRigidbody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                    anim.SetBool("IsJumping", true);
                }
                else
                {
                    rRigidbody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                    anim.SetBool("IsJumping", true);
                    anim.SetBool("IsWalkingFinish", false);
                }

            }
        }

        if (Input.GetButtonUp("Horizontal"))
            anim.SetBool("IsWalkingFinish", true);
        else
            anim.SetBool("IsWalkingFinish", false);

        if (Mathf.Abs(rRigidbody.velocity.x) < 0.3)
        {
            if (anim.GetBool("IsMushroomItem"))
            {
                anim.SetBool("IsBigWalking", false);
            }
            else
            {
                anim.SetBool("IsWalking", false);
            }
            
        }
        else
        {
            if (anim.GetBool("IsMushroomItem"))
            {
                anim.SetBool("IsBigWalking", true);
            }
            else
            {
                anim.SetBool("IsWalking", true);
            }
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");

        rRigidbody.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (rRigidbody.velocity.x > fSpeed)
            rRigidbody.velocity = new Vector2(fSpeed, rRigidbody.velocity.y);
        else if(rRigidbody.velocity.x < fSpeed * (-1))
            rRigidbody.velocity = new Vector2(fSpeed * (-1), rRigidbody.velocity.y);

        if(rRigidbody.velocity.y < 0)
        {
            //bIsFloor = true;
            Debug.DrawRay(rRigidbody.position, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(rRigidbody.position, Vector3.down, 1, LayerMask.GetMask("Floor"));

            if (rayHit.collider != null)
            {
                if (anim.GetBool("IsMushroomItem"))
                {
                    if (rayHit.distance < 1.0f)
                    {
                        anim.SetBool("IsBigJumping", false);
                    }
                }
                else
                {
                    if (rayHit.distance < 0.5f)
                    {
                        anim.SetBool("IsJumping", false);
                    }
                }
                    
            }
        }
        //else
        //{
        //    Debug.DrawRay(rRigidbody.position, Vector3.right, new Color(0, 1, 0));
        //    RaycastHit2D rayHit = Physics2D.Raycast(rRigidbody.position, Vector3.right, 1, LayerMask.GetMask("Floor"));
        //    if(rayHit.collider != null)
        //    {
        //        bIsFloor = true;
        //    }
        //    else
        //    {
        //        bIsFloor = false;
        //    }
        //}
        
        if (spriteRenderer.sprite.name == "UpgradeMario")
        {
            BoxCollider.size = new Vector2(0.16f, 0.16f);
        }
        if (spriteRenderer.sprite.name == "UpgradeMario1")
        {
            BoxCollider.size = new Vector2(0.16f, 0.33f);
        }
        if (spriteRenderer.sprite.name == "UpgradeMario2")
        {
            BoxCollider.size = new Vector2(0.16f, 0.33f);
        }

        if (spriteRenderer.sprite.name == "BigFireMarioUpgrade0R")
        {
            BoxCollider.size = new Vector2(0.16f, 0.16f);
        }
        if (spriteRenderer.sprite.name == "BigFireMarioUpgrade1")
        {
            BoxCollider.size = new Vector2(0.16f, 0.33f);
        }
        if (spriteRenderer.sprite.name == "BigFireMarioUpgrade2")
        {
            BoxCollider.size = new Vector2(0.16f, 0.33f);
        }
        if (spriteRenderer.sprite.name == "NormalMario1")
        {
            BoxCollider.size = new Vector2(0.16f, 0.16f);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            if (rRigidbody.velocity.y >= 0 && transform.position.y < collision.transform.position.y)
            {
                if(transform.position.x > (collision.transform.position.x - fWallHalfSize) 
                    || transform.position.x < collision.transform.position.x + fWallHalfSize)
                {
                    Destroy(collision.gameObject);
                }
            }

        }
        if(collision.gameObject.tag == "MushRoomItem")
        {
            anim.SetBool("IsMushroomItem", true);
            anim.SetBool("IsJumping", false);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "MonsterMushroom")
        {
            if(rRigidbody.velocity.y < 0 && transform.position.y > collision.transform.position.y)
            {
                OnAttack(collision.transform);
            }
            else
            {
                if(!bIsOverPower)
                {
                    OnDamaged();
                }
            }
            
        }
        if (collision.gameObject.tag == "MonsterTurtle")
        {
            if (rRigidbody.velocity.y < 0 && transform.position.y > collision.transform.position.y)
            {
                OnAttack(collision.transform);
            }
            else
            {
                if (!bIsOverPower)
                {
                    OnDamaged();
                }
            }

        }
        if(collision.gameObject.tag == "FireFlowerItem")
        {
            anim.SetBool("IsFireItem", true);
            Destroy(collision.gameObject);
            if(anim.GetBool("IsMushroomItem"))
            {
                anim.SetBool("IsBigFireUpgrade", false);
            }
            else
            {
                anim.SetBool("IsBigFireUpgrade", true);
            }
        }
        if(collision.gameObject.tag == "Flag")
        {
            anim.SetBool("IsFlag", true);
            transform.position = new Vector3(59.7f, transform.position.y, transform.position.z);
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        fTime += Time.deltaTime;

        if (fTime > fLimitTime && collision.gameObject.tag == "MushRoomItem")
        {
            anim.SetBool("IsMushroomItem", true);
            anim.SetBool("IsJumping", false);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Castle")
        {
            SceneManager.LoadScene("BossStage");
        }
    }
    void OnAttack(Transform Monster)
    {
        rRigidbody.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
        if (Monster.gameObject.tag == "MonsterMushroom")
        {
            MushRoomMonster mushroomMonster = Monster.gameObject.GetComponent<MushRoomMonster>();
            mushroomMonster.OnDamaged();
        }
        if(Monster.gameObject.tag == "MonsterTurtle")
        {
            TutleMonster turtleMonster = Monster.gameObject.GetComponent<TutleMonster>();
            turtleMonster.OnDamaged();
        }
    }

    void OnDamaged()
    {
        if(anim.GetBool("IsMushroomItem"))
        {
            if(anim.GetBool("IsFireItem"))
            {
                anim.SetBool("IsFireItem", false);
            }
            else
            {
                anim.SetBool("IsMushroomItem", false);
                bIsOverPower = true;
                spriteRenderer.color = new Color(1, 1, 1, 0.4f);
                Invoke("OnDamagedOff", 3.0f);
            }
        }
        else
        {
            if(anim.GetBool("IsFireItem"))
            {
                anim.SetBool("IsFireItem", false);
            }
            else
            {
                anim.SetBool("IsDeath", true);
                rRigidbody.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
                BoxCollider.enabled = false;
            }
            
        }
    }

    void OnDamagedOff()
    {
        bIsOverPower = false;
        spriteRenderer.color = new Color(1, 1, 1, 1.0f);
    }
}
