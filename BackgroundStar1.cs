using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundStar1 : MonoBehaviour
{
    Material mat;
    float currnetYoffset = 0;
    public float speed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        currnetYoffset += speed*Time.deltaTime;
        mat.mainTextureOffset = new Vector2(0, currnetYoffset);
    }
}
