using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {


	public Transform start_position; 
	Rigidbody rb ; 
	MeshRenderer mr; 
	public ParticleSystem ps;

    public float Kick_Cooldown = 0.5f;

	bool _spawning = false; 

	
	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody>();
		mr = this.GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	private void OnTriggerEnter(Collider other) {

		if(other.gameObject.tag == "Cage" && !_spawning)
		{
			ps.Play();
			mr.enabled = false;
			_spawning = true;
			Invoke("Reset_Position", 1.5f);
		}

	}

    bool can_Kick = true; 

    public void Kick(Vector3 direction, float force)
    {
        if(can_Kick)
        {
            rb.AddForce(direction * force, ForceMode.Impulse);
            can_Kick = false;
            Invoke("Reset_Kick", Kick_Cooldown);
        }
    }

    public void Reset_Kick()
    {
        can_Kick = true;
    }

    private void Reset_Position()
	{
		mr.enabled = true;
		_spawning = false; 
		transform.position = start_position.position; 
		transform.rotation = start_position.rotation; 
		rb.velocity = Vector3.zero; 
		rb.angularVelocity = Vector3.zero;
		ps.Stop();
	}

}
