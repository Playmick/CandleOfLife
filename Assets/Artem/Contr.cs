using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contr : MonoBehaviour
{
	public float speed;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.D))//если нажата клавиша D
		{
			transform.Translate(Vector2.right * speed * 0.1f);//передвигаем объект вправо с заданной скоростью
		}
		
		//if (transform.position.x > -FieldX)//если позиция объекта меньше чем позиция "стенки" по оси Х(меньше нуля)
		
		if(Input.GetKey(KeyCode.A))//если нажата клавиша А
		{
			transform.Translate(-Vector2.right * speed * 0.1f);//передвигаем объект влево с заданной скоростью
			//if 
		}
		
		if(Input.GetKey(KeyCode.W))//если нажата клавиша D
		{
			transform.Translate(Vector2.up * speed * 0.1f);//передвигаем объект вправо с заданной скоростью
		}
		
		//if (transform.position.x > -FieldX)//если позиция объекта меньше чем позиция "стенки" по оси Х(меньше нуля)
		
		if(Input.GetKey(KeyCode.S))//если нажата клавиша А
		{
			transform.Translate(-Vector2.up * speed * 0.1f);//передвигаем объект влево с заданной скоростью
		}
		
    }
}
