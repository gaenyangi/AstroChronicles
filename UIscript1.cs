using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIscript1 : MonoBehaviour
{
    public GameObject character;
    public GameObject enemy;
    public GameObject deathcount;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.deathcount.GetComponent<Text>().text = "death count";
    }
}
