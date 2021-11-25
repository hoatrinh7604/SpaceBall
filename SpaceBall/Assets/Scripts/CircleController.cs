using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CircleController : MonoBehaviour
{
    private int indexCircle=0;
    private float minSize = 0.01f;

    [SerializeField] SpriteRenderer spriteCircle;
    [SerializeField] Rigidbody2D ridCircle;
    
    [SerializeField] float[] sizeCircle = {0.2f, 0.3f, 0.35f, 0.4f};
    [SerializeField] int[] pointCircle = {5, 10, 15, 20};
    public Sprite[] colorCircle;
    public float speedCircle = 100;
    public int damageCircle;
    
    private GameObject Points;
    [SerializeField] GameObject prefabCircle;
    private bool canSpaw = false;
    private bool isStar = false;
    
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

        Points = gameObject.transform.Find("Canvas").gameObject;
        Points = Points.transform.Find("Points").gameObject;
    }

    private void FixedUpdate()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("OnTriggerEnter2D");
        if(collision.gameObject.tag == "Bullet" && !isStar)
        {
            pointCircle[indexCircle]-=5;
            
            if (pointCircle[indexCircle] <= 0)
            {
                indexCircle--;
                SpawChildCircle(this.gameObject.transform, indexCircle);
                Destroy(this.gameObject);
            }
            else
            {
                Points.GetComponent<TextMeshProUGUI>().text = pointCircle[indexCircle].ToString();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "BGSpace")
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpaw)
        {
            //Size
            if (indexCircle < 0)
            {
                transform.localScale = new Vector3(minSize, minSize, 1);
                ridCircle.AddForce(new Vector2(RandomDirection() * speedCircle / minSize, RandomDirection() * speedCircle / minSize));
            }
            else
            {
                //Points
                Points.GetComponent<TextMeshProUGUI>().text = pointCircle[indexCircle].ToString();
                transform.localScale = new Vector3(sizeCircle[indexCircle], sizeCircle[indexCircle], 1);
                ridCircle.AddForce(new Vector2(RandomDirection() * speedCircle / sizeCircle[indexCircle], RandomDirection() * speedCircle / sizeCircle[indexCircle]));
            }

            //Random color
            spriteCircle.sprite = colorCircle[UnityEngine.Random.Range(0, colorCircle.Length - 1)];

            //Random moving
            
            canSpaw = false;
        }
    }

    int GetPointCircle()
    {
        return pointCircle[indexCircle];
    }

    void SpawChildCircle(Transform positionToSpaw, int index)
    {
        GameObject a = Instantiate(prefabCircle, positionToSpaw.position, Quaternion.identity);
        GameObject b = Instantiate(prefabCircle, positionToSpaw.position, Quaternion.identity);
        print("Index = " + indexCircle);
        a.GetComponent<CircleController>().SetCircleFolowIndex(index);
        b.GetComponent<CircleController>().SetCircleFolowIndex(index);

        a.GetComponent<CircleController>().SetStartSpaw(false);
        b.GetComponent<CircleController>().SetStartSpaw(false);
    }

    void SetCircleFolowIndex(int index)
    {
        indexCircle = index;
    }

    public void SetStartSpaw(bool isRandomSize)
    {
        if(isRandomSize)
        {
            indexCircle = UnityEngine.Random.Range(0, sizeCircle.Length - 1);
        }

        if (indexCircle < 0)
        {
            isStar = true;
        }
        else
        {
            isStar = false;
        }
        canSpaw = true;
    }

}
