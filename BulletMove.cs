using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    Transform tr;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        tr=GetComponent<Transform>();
        StartCoroutine(DestroySelf());
    }

    // Update is called once per frame
    void Update()
    {
        tr.Translate(Vector2.up*speed); // Vecotr2.up = new Vecotr2(0,1) ; (0,1)�� ���͸� ������ ����.
    }

    IEnumerator DestroySelf() // �ռ��� �����ϰ� �Ѿ� �������� ���ִ� �ڷ�ƾ.
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(this.gameObject); // �Է¹��� ������ ���� ������Ʈ�� ����.
    }
}
