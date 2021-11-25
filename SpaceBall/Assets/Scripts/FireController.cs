using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    [SerializeField] GameObject bulletFrefab;
    [SerializeField] Transform target;
    [SerializeField] Transform firingPoint; 
    private float fire;

    private BulletAttribute bulletAttribute;
    // Start is called before the first frame update
    void Start()
    {
        fire = 0f;
    }

    private void FixedUpdate()
    {
        fire -= Time.deltaTime;
        if(Input.GetKey(KeyCode.Space) && fire < 0f)
        {
            //Fire
            GameObject bullet = Instantiate(bulletFrefab, firingPoint);
            bulletAttribute = bullet.GetComponent<BulletAttribute>();

            Vector2 dir = new Vector2(target.position.x - firingPoint.position.x, target.position.y - firingPoint.position.y);
            bullet.GetComponent<Rigidbody2D>().AddForce(dir * bulletAttribute.GetSpeed());

            fire = bulletAttribute.GetLoadTime();
        }
    }

}
