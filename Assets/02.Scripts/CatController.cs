using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatController : MonoBehaviour
{
    public float moveSpeed;
    public float moveForce = 30.0f; // 직접 움직일때 사용 
    float maxMoveSpeed = 2.0f; //애니메이션에서 사용
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;

    //점프 구현
    float jumpForce = 800.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        // 플레이어 속도
        float speedX = Mathf.Abs(rb.velocity.x);

        float sppedY = Mathf.Abs(rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && sppedY == 0)
        {
            anim.SetTrigger("Jump");
            rb.AddForce(transform.up * jumpForce);
        }

        //좌우이동 좀 다르게
        int key = 0;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            key = 1;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            key = 1;
            transform.localRotation = Quaternion.Euler(0, 0, 0);

        }





        if (speedX < maxMoveSpeed)
        {
            //rb.AddForce(transform.right * key * moveForce);
            rb.AddForce(transform.right * key * moveForce);
        }

        //움직이는 방향에 따라 반전
        if (key != 0)
        {
            //transform.localScale = new Vector3(key, 1, 1); 
            //scale을 통한 방향 반전
            //이 경우엔 key가 왼쪽 오른쪽 입력에 따라 +-가 바뀌어야 함


            
            //localRotation 
            
            
            //if(key < 0)
            //{
            //    sr.flipX = true;
            //}
            //else
            //{
            //    sr.flipX = false;
            //}
            
            //3. flip체크
        }

        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("GameScene");
        }


        //플레이어의 속도에 맞춰 애니메이션 속도를 바꾼다
        anim.speed = speedX / 2.0f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("골인");
        SceneManager.LoadScene("ClearScene");
    }
}
