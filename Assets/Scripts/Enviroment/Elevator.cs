using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    private float movementSpeed;
    private int startingPoint = 0;
    public Transform[] points;
    private int i;
    void Start()
    {
        transform.position = points[startingPoint].position;
    }
    void Update()
    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++;
            movementSpeed = 0;//platforma zatrzymuje się na każdym piętrze
            if(i == points.Length)
            {
                i = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, movementSpeed * Time.deltaTime);
    }

//funkcje do płynnego poruszania się na platformie
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))//wykrywam gracza
        {
            if (other.transform.position.y > transform.position.y)//tylko gdy gracz będzie na górze platformy
            {
                movementSpeed = 4;//platforma porusza się tylko kiedy gracz na niej stoi
                //other.transform.SetParent(transform);//ustawiamy platforme jako parent gracza
            }
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //other.transform.SetParent(null);//gdy gracz zejdzie, przestaje być childem platformy
        }
    }//ustawienie parentów przydaje się bardziej gdy platformy poruszają się poziomo, 
    //dlatego zostawię część kodu zakomentowaną
}
