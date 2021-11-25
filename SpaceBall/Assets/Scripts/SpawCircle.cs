using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawCircle : MonoBehaviour
{
    public int maximumCircle = 50;
    public int currentCircles = 0;
    [SerializeField] float spawTime;
    [SerializeField] GameObject prefabStar;
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
            RandomSpawStar();
            currentCircles++;

            spawTime = 0.0f;
        }
        spawTime += Time.deltaTime;
    }

    IEnumerator WaitForTheTime(GameObject star, float time, float posX, float posY)
    {
        yield return new WaitForSeconds(time);
        Destroy(star);
        SpawCircleAtPos(posX, posY);
    }

    void RandomSpawStar()
    {
        //Get random position
        float posX = UnityEngine.Random.Range(spawPointLeftBottom.position.x, spawPointRightUp.position.x);
        float posY = UnityEngine.Random.Range(spawPointLeftBottom.position.y, spawPointRightUp.position.y);

        GameObject newStar = Instantiate(prefabStar, new Vector3(posX, posY, 1), Quaternion.identity);
        print(prefabStar.GetComponent<Animation>().clip.length);
        StartCoroutine(WaitForTheTime(newStar, prefabStar.GetComponent<Animation>().clip.length, posX, posY));

    }

    void SpawCircleAtPos(float posX, float posY)
    {
        GameObject a = Instantiate(prefabCircle, new Vector3(posX, posY, 1), Quaternion.identity);
        a.GetComponent<CircleController>().SetStartSpaw(true);
    }

    void reDuceCurrentCircles()
    {
        currentCircles--;
    }

}
