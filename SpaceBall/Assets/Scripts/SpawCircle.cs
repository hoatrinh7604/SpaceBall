using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawCircle : MonoBehaviour
{
    public int maximumCircle = 50;
    public int currentCircles = 0;
    [SerializeField] float spawTime;
    [SerializeField] GameObject prefabCircle;
    [SerializeField] Transform spawPointLeftBottom;
    [SerializeField] Transform spawPointRightUp;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(spawTime > 3.0f && currentCircles <= maximumCircle)
        {
            RandomSpawCircle();
            currentCircles++;

            spawTime = 0.0f;
        }
        spawTime += Time.deltaTime;
    }

    void RandomSpawCircle()
    {
        //Get random position
        float posX = UnityEngine.Random.Range(spawPointLeftBottom.position.x, spawPointRightUp.position.x);
        float posY = UnityEngine.Random.Range(spawPointLeftBottom.position.y, spawPointRightUp.position.y);

        Instantiate(prefabCircle, new Vector3(posX, posY, 1), Quaternion.identity);
        
    }

    void reDuceCurrentCircles()
    {
        currentCircles--;
    }

}
