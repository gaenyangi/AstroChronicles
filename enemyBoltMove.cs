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
        tr.Translate(Vector2.down * speed); // Vecotr2.up = new Vecotr2(0,1) ; (0,1)의 벡터를 가지고 있음.
    }
    IEnumerator DestroySelf() // 앞서와 동일하게 총알 프리팹을 없애는 코루틴.
    {
        yield return new WaitForSeconds(10.0f);
        Destroy(this.gameObject); // 입력받은 인자의 게임 오브젝트를 제거.
    }
}
