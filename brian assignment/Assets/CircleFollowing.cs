using UnityEngine;
using System.Collections;

public class CircleFollowing : MonoBehaviour {
	
	private Vector3[] CirclePoints;
	public float _maxSpeed = 5f;
	
	void Start ()
	{
		//we assign the circlepoints array 
		//to the function because the function returns a vector3
		CirclePoints = CreateCircle(10,10);
	}
	
	void Update ()
	{
		DrawCircle();
		Seek();
	}

	//this vector3 function returns a vector3. 
	//The returned vector3 is automatically inserted in
	//to our CirclePoints array. 
	Vector3[] CreateCircle(int points, float radius)
	{
		Vector3[] CirclePoints = new Vector3[points];
		//formula for calculating angle of circle
		float angle = Mathf.PI * 2 / points;
		
		for (int i = 0; i < points; i++)
		{
			//calculate where this point goes
			CirclePoints[i] = new Vector3(
				Mathf.Cos(angle * i), 
				0,
				Mathf.Sin(angle * i)
				) * radius;
		}

		return CirclePoints;

	}
	
	void DrawCircle ()
	{
		for(int i = 0; i < CirclePoints.Length; i++)
		{
			Debug.DrawLine(CirclePoints[i], CirclePoints[(i + 1) % CirclePoints.Length], Color.red);
		}
	}

	void Seek()
	{
		//move along the radius of the circle
		transform.position = new Vector3(Mathf.Cos(Time.time * _maxSpeed), 0, Mathf.Sin(Time.time * _maxSpeed)) * 10;
	}

}