using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controler : MonoBehaviour {

    Rigidbody rb;

	public float max_walking_speed ; 
	public float walk_acceleration ; 
	public float dash_force ; 
	public float walking_brake ; 



	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 dir_in = new Vector3(Input.GetAxis("Horizontal"), 0 , Input.GetAxis("Vertical"));



		if(dir_in.magnitude > 0.01f)
		{

/* 			if(Vector3.Dot(transform.forward, dir_in.normalized) < 0)
			{
				rb.velocity *= 0.5f; 
				rb.angularVelocity = Vector3.zero; 
				Debug.Log("STOP");
			} */

			transform.forward = dir_in;

			//Dashing
			if(Input.GetKeyDown(KeyCode.LeftShift))
			{
				if(rb.velocity.magnitude < max_walking_speed + 2f)
				{
					rb.AddForce(dir_in * dash_force, ForceMode.Impulse);
					Debug.Log("DASH");
				}
			}
			
			//Walking
			else
			{
				if(rb.velocity.magnitude < max_walking_speed)
				{
					rb.AddForce(dir_in * walk_acceleration * Time.deltaTime, ForceMode.VelocityChange);
					Debug.Log("WALK");
				}
				else
				{
					Debug.Log("STOP_WALK");
					rb.velocity = Vector3.Lerp(rb.velocity, rb.transform.forward * max_walking_speed, walking_brake);
				} 
			}
		}
		else
		{
			rb.angularVelocity = Vector3.zero; 
			if(rb.velocity.magnitude > 0.2f)
			{
				rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, 1f - walking_brake);
			}
			else
			{
				rb.velocity = Vector3.zero; 
			}
		}
	}
}
