using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeTrapScript : MonoBehaviour
{
    public Transform[] Points;
    private int _currentPoint;
    private float speedGeberal;
    public float speedOn = 4f;
    public float speedOff = 2f;
    private float Distance = 0.1f;

    private Contr2 other;
    private Animator anim;

    void FixedUpdate()
    {
        
        float _currentDistance = Vector2.Distance(transform.position, Points[_currentPoint].position);
        if (_currentDistance <= Distance) _currentPoint++;

        if (_currentPoint == Points.Length) _currentPoint = 0;

        if (_currentPoint == 0) speedGeberal = speedOn; else speedGeberal = speedOff ;

        transform.position = Vector2.MoveTowards(transform.position, Points[_currentPoint].transform.position, speedGeberal * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim = collision.GetComponent<Animator>();
            other = collision.GetComponent<Contr2>() as Contr2;
            anim.SetBool("die", true);
            other.isDead = true;
        }
    }
}
