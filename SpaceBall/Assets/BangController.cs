using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BangController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
       // anim.Play("Bang");
        StartCoroutine(DestroyAfterPlay(animator.GetCurrentAnimatorStateInfo(0).length));
    }

    IEnumerator DestroyAfterPlay(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }
}
