using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_rangedAttack : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    private GameObject arrowPrefab;
    private Transform bow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        GameObject go = Instantiate(arrowPrefab, bow.position, Quaternion.identity);

        Vector3 dir = new Vector3(transform.localScale.x, 0);
    }
}
