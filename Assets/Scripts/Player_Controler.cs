using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controler : MonoBehaviour {


    public float Speed = 5f;
    public float JumpHeight = 2f;
    public float GroundDistance = 0.2f;
    public float DashDistance = 5f;
    public LayerMask Ground;

    private Rigidbody _body;
    private Vector3 _inputs = Vector3.zero;
    //private bool _isGrounded = true;
    //private Transform _groundChecker;

    void Start()
    {
        _body = GetComponent<Rigidbody>();
        //_groundChecker = transform.GetChild(0);
    }

    void Update()
    {

		/*         _isGrounded = Physics.CheckSphere(_groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore); */
        _inputs = Vector3.zero;
        _inputs.x = Input.GetAxis("Horizontal");
        _inputs.z = Input.GetAxis("Vertical");
		if(_inputs.magnitude > 0.1f)
		{
			_body.angularVelocity = Vector3.zero;
		}
        if (_inputs != Vector3.zero)
		{
			transform.forward = _inputs;
		}

		/*         if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _body.AddForce(Vector3.up * Mathf.Sqrt(JumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        } */
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Vector3 dashVelocity = Vector3.Scale(transform.forward, DashDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * _body.drag + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * _body.drag + 1)) / -Time.deltaTime)));
            _body.AddForce(dashVelocity, ForceMode.VelocityChange);
        }
    }


    void FixedUpdate()
    {
        _body.MovePosition(_body.position + _inputs * Speed * Time.fixedDeltaTime);
    }



///OLD//


/*     public float moveSpeed = 1;

    // Update is called once per frame
    void Update () 
    {

		Vector3 dir_in =  new Vector3(Input.GetAxis("Horizontal"), 0 , Input.GetAxis("Vertical"));

		if(dir_in.magnitude > 0.01f)
		{
			transform.forward = dir_in.normalized;
			transform.Translate(Vector3.forward * moveSpeed * dir_in.magnitude * Time.deltaTime);
		}

    } */




	

/*     Rigidbody rb;

	public float max_walking_speed ; 
	public float walk_acceleration ; 
	public float dash_force ; 
	public float walking_brake ;
    public float walk_inpulse; */


/* 
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 dir_in =  new Vector3(Input.GetAxis("Horizontal"), 0 , Input.GetAxis("Vertical"));



		if(dir_in.magnitude > 0.01f)
		{

			transform.forward = dir_in;

			//Dashing
			if(Input.GetKeyDown(KeyCode.LeftShift))
			{
				if(rb.velocity.magnitude < max_walking_speed + 2f)
				{
					rb.AddForce(dir_in * dash_force, ForceMode.Impulse);
					//Debug.Log("DASH");
				}
			}
			
			//Walking
			else
			{

                if (rb.velocity.magnitude < max_walking_speed * 0.2)
                {
                    rb.AddForce(dir_in * walk_inpulse, ForceMode.Impulse);
                    //Debug.Log("PULSE");
                }
                if (rb.velocity.magnitude < max_walking_speed)
				{
					rb.AddForce(dir_in * walk_acceleration, ForceMode.Force);
					//Debug.Log("WALK");
				}
				else
				{
					//Debug.Log("STOP_WALK");
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
	} */
}
