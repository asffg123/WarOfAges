using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect : MonoBehaviour
{
    //public bool EntityDetected { get; private set; } = false;

    [System.NonSerialized]
    public Collider2D selfCollider;
    /*
    private IEnumerator OnTriggerStay2D(Collider2D collision)
    {
        yield return new WaitForFixedUpdate();
        if (collision.CompareTag("Entity"))
            EntityDetected = true;
    }
    */
    // Detection box size
    public float boxWidth;
    public float boxHeight;

    public TeamID unitDetector()
    {
        Vector2 center = transform.position;
        Vector2 offset = ((boxWidth / 2) * Vector2.right) + ((boxHeight / 2) * Vector2.up);
        Vector2 pointA = center + offset;
        Vector2 pointB = center - offset;

        var colliders = Physics2D.OverlapAreaAll(pointA, pointB);

        //EntityDetected = false;

        foreach (var collider in colliders)
        {
            if (collider == selfCollider)
            {
                continue;
            }

            if (collider.CompareTag("Entity"))
            {
                //EntityDetected = true;
                Entity entity = collider.GetComponent<Entity>();
                TeamID team = entity.team;
                return team;
            }
        }

        return TeamID.none;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
