using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_shoot : MonoBehaviour
{
    public Transform arrow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    public void Shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(arrow.position, arrow.right);

        if (hitInfo)
        {
            Debug.Log(hitInfo.transform.name);
        }
    }
}
