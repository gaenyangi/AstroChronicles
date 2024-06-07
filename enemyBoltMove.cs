using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyBoltMove : MonoBehaviour
{
    Transform tr;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        StartCoroutine(DestroySelf());
    }

    // Update is called once per frame
    void Update()
    {
        tr.Translate(Vector2.down * speed); // Vecotr2.up = new Vecotr2(0,1) ; (0,1)�� ���͸� ������ ����.
    }
    IEnumerator DestroySelf() // �ռ��� �����ϰ� �Ѿ� �������� ���ִ� �ڷ�ƾ.
    {
        yield return new WaitForSeconds(10.0f);
        Destroy(this.gameObject); // �Է¹��� ������ ���� ������Ʈ�� ����.
    }
}
