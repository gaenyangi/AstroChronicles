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
        StartCoroutine(FireBullet()); // coroutine �Լ� ����
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
            } // ȭ�� ���� ������ ������ �ʰ� ���콺 ��ġ ���� ����.

        }
    }

    IEnumerator FireBullet() // �����ð����� �ݺ��Ǵ� �ڷ�ƾ �Լ� ����. �ش� �Լ��� �ڷ����� IEnumerator.
    {
        while (true)
        {
            Instantiate(prefabBullet, tr.position, Quaternion.identity); // ���� ������Ʈ �����Լ� instantiate. Quaternion.identity = ȸ������(���� ���� �״�� �߻�)
            GetComponent<AudioSource>().enabled = true;
            GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(0.3f);  // 0.3�� ��ٷȴٰ� ���� ���� ����.
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