using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreate : MonoBehaviour
{
    public GameObject prefabEnemy;
    public Vector2 limitMin;
    public Vector2 limitMax;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CreateEnemy()
    {
        yield return new WaitForSeconds(2.0f);
        while (true)
        {
            float r=Random.Range(limitMin.x, limitMax.x);
            Vector2 creatingPoint= new Vector2(r, limitMin.y);

            Instantiate(prefabEnemy, creatingPoint, Quaternion.identity);

            float creatingTime = Random.Range(0.5f, 3.0f);
            yield return new WaitForSeconds(creatingTime);
        }
    }
}
