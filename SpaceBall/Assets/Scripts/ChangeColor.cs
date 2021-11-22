using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] int numberColor = 4;
    private int currentColor;
    public SpriteRenderer colorShip;
    public Sprite[] listColor;


    // Start is called before the first frame update
    void Start()
    {
        colorShip = gameObject.GetComponent<SpriteRenderer>();
        // Create a random color
        currentColor = UnityEngine.Random.Range(1, listColor.Length - 1);

        try
        {
            colorShip.sprite = listColor[currentColor];
        }catch(Exception e)
        {
            print(e);
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
