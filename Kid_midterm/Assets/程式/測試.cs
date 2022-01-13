using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class 測試 : MonoBehaviour
{
    public List<Transform> points;
    public int nextID = 0;
    int idChangeVaule = 1;
    public float speed = 2;
 
    private void Update()
    {
        MoveToNextPoint();
    }

    void MoveToNextPoint()
    {
        Transform goalpoint = points[nextID];

        if (goalpoint.transform.position.x > transform.position.x)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);
        transform.position = Vector2.MoveTowards(transform.position,goalpoint.position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, goalpoint.position) < 1f)
        {
            if (nextID == points.Count - 1)
                idChangeVaule = -1;
            if (nextID == 0)
                idChangeVaule = 1;
            nextID += idChangeVaule;
        }

    }    
}