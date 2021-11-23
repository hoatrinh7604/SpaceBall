using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    private int indexCircle;

    [SerializeField] SpriteRenderer spriteCircle;
    [SerializeField] Rigidbody2D ridCircle;
    
    [SerializeField] float minSizeCircle = 0.05f;
    [SerializeField] float[] sizeCircle = {0.1f, 0.15f, 0.2f, 0.25f};
    [SerializeField] int[] pointCircle = {5, 10, 15, 20};
    public Sprite[] colorCircle;
    public float speedCircle = 100;
    public int damageCircle;


    private void ChangeColor(int currentColor)
    {
        try
        {
            int getNextColor;
            do
            {
                getNextColor = UnityEngine.Random.Range(0, colorCircle.Length - 1);
            } while (getNextColor != currentColor);

            spriteCircle.sprite = colorCircle[getNextColor];
        }
        catch (Exception e)
        {
            print(e);
        }
    }

    private int RandomDirection()
    {
        int direct = UnityEngine.Random.Range(-1, 1);
        return (direct < 0) ? -1 : 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteCircle = gameObject.GetComponent<SpriteRenderer>();
        ridCircle = gameObject.GetComponent<Rigidbody2D>();

        //Random size
        indexCircle = UnityEngine.Random.Range(0, sizeCircle.Length - 1);
        transform.localScale = new Vector3(sizeCircle[indexCircle], sizeCircle[indexCircle], 1);

        //Random color
        spriteCircle.sprite = colorCircle[UnityEngine.Random.Range(0, colorCircle.Length - 1)];

        //Random moving
        ridCircle.AddForce(new Vector2(RandomDirection() * speedCircle * sizeCircle[indexCircle], RandomDirection() * speedCircle * sizeCircle[indexCircle]));
    }

    // Update is called once per frame
    void Update()
    {

    }


}
