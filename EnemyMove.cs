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

    IEnumerator FireBullet() // �����ð����� �ݺ��Ǵ� �ڷ�ƾ �Լ� ����. �ش� �Լ��� �ڷ����� IEnumerator.
    {
        while (true)
        {
            Instantiate(prefabBullet, tr.position, Quaternion.identity); // ���� ������Ʈ �����Լ� instantiate. Quaternion.identity = ȸ������(���� ���� �״�� �߻�)
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
            //GameObject.Find("GameManager").GetComponent<Score>().score += 10;//GameManger gameobject�� Score script componenet�� �������� �ű��� score ������ ����.
            Destroy(this.gameObject, 0.05f);
            Destroy(collision.gameObject);
        }
    }
}
