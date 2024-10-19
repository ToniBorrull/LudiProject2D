using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeSprite : MonoBehaviour
{
    public Sprite brokenHouse;
    public SpriteRenderer sR;
    // Start is called before the first frame update
    void Start()
    {
        sR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSprite()
    {
        sR.sprite = brokenHouse;
    }
}
