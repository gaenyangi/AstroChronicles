using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Transform tr;
    public float speed;
    public GameObject prefabBullet;
    AudioSource[] audioSources;
    void Start()
    {
        tr = GetComponent<Transform>();
        audioSources = GetComponents<AudioSource>();
        StartCoroutine(DestroySelf());
        StartCoroutine(FireBullet());
    }

    // Update is called once per frame
    void Update()
    {
        tr.Translate(Vector2.down * speed);

    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(10.0f);
        Destroy(this.gameObject);
    }

    IEnumerator FireBullet() // 일정시간마다 반복되는 코루틴 함수 선언. 해당 함수의 자료형은 IEnumerator.
    {
        while (true)
        {
            Instantiate(prefabBullet, tr.position, Quaternion.identity); // 게임 오브젝트 생성함수 instantiate. Quaternion.identity = 회전없음(원래 각도 그대로 발사)
            audioSources[1].enabled = true;
            audioSources[1].Play();
            yield return new WaitForSeconds(2.0f); 
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Score.killcount += 1;
            audioSources[0].enabled = true;
            audioSources[0].Play();
            //GameObject.Find("GameManager").GetComponent<Score>().score += 10;//GameManger gameobject의 Score script componenet를 가져오고 거기의 score 변수를 변경.
            Destroy(this.gameObject, 0.05f);
            Destroy(collision.gameObject);
        }
    }
}
