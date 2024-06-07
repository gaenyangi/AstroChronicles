using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playermovement : MonoBehaviour
{
    public float speed;
    Transform tr;
    Vector2 mousePosition;
    public Vector2 limitPoint1;
    public Vector2 limitPoint2;

    public GameObject prefabBullet;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        StartCoroutine(FireBullet()); // coroutine 함수 실행
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            mousePosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (mousePosition.x < limitPoint1.x)
            {
                mousePosition = new Vector2(limitPoint1.x, mousePosition.y);
            }
            if (mousePosition.x > limitPoint2.x)
            {
                mousePosition = new Vector2(limitPoint2.x, mousePosition.y);
            }
            if (mousePosition.y < limitPoint1.y)
            {
                mousePosition = new Vector2(mousePosition.x, limitPoint1.y);
            }
            if (mousePosition.y > limitPoint2.y)
            {
                mousePosition = new Vector2(mousePosition.x,limitPoint2.y);
            } // 화면 범위 밖으로 나가지 않게 마우스 위치 강제 고정.

        }
    }

    IEnumerator FireBullet() // 일정시간마다 반복되는 코루틴 함수 선언. 해당 함수의 자료형은 IEnumerator.
    {
        while (true)
        {
            Instantiate(prefabBullet, tr.position, Quaternion.identity); // 게임 오브젝트 생성함수 instantiate. Quaternion.identity = 회전없음(원래 각도 그대로 발사)
            GetComponent<AudioSource>().enabled = true;
            GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(0.3f);  // 0.3초 기다렸다가 다음 루프 실행.
        }
    }


    private void FixedUpdate()
    {
        tr.position = Vector2.MoveTowards(tr.position, mousePosition, Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}