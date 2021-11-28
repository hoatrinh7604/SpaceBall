using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawStars : MonoBehaviour
{

    [SerializeField] GameObject starPrefab;
    [SerializeField] Transform leftBottomSpawPoint;
    [SerializeField] Transform rightUpSpawPoint;
    [SerializeField] int numberOfStars = 80;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfStars; i++)
        {
            float posX = UnityEngine.Random.Range(leftBottomSpawPoint.position.x, rightUpSpawPoint.position.x);
            float posY = UnityEngine.Random.Range(leftBottomSpawPoint.position.y, rightUpSpawPoint.position.y);
            Instantiate(starPrefab, new Vector3(posX, posY, 1), Quaternion.identity);
            //print("hoa: " + star.GetComponent<Animation>().clip.name);
            // anim["StarBG"].speed = UnityEngine.Random.Range(1.0f, 10.0f);
            //anim["StarBG"].time = UnityEngine.Random.Range(1.0f, 10.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
