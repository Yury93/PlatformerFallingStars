using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;
	[SerializeField] private DynamicJoystick joystick;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool dash = false;

	//bool dashAxis = false;
	
	// Update is called once per frame
	void Update () {

		//horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		
		if(joystick.Direction.x > 0)
        {
			Time.timeScale = 0.7f;
			horizontalMove = 1 * runSpeed;
        }
		else if (joystick.Direction.x < 0)
        {
			Time.timeScale = 0.7f;
			horizontalMove = 1 * -runSpeed;
		}
        else
        {
			horizontalMove = 0;
			Time.timeScale = 0.01f;
		}
		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (joystick.Direction.y > 0)
		{
			Time.timeScale = 0.7f;
			jump = true;
		}

		//if (Input.GetKeyDown(KeyCode.C))
		//{
		//	dash = true;
		//}

		/*if (Input.GetAxisRaw("Dash") == 1 || Input.GetAxisRaw("Dash") == -1) //RT in Unity 2017 = -1, RT in Unity 2019 = 1
		{
			if (dashAxis == false)
			{
				dashAxis = true;
				dash = true;
			}
		}
		else
		{
			dashAxis = false;
		}
		*/

	}

	public void OnFall()
	{
		animator.SetBool("IsJumping", true);
	}

	public void OnLanding()
	{
		animator.SetBool("IsJumping", false);
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
		jump = false;
		dash = false;
	}
}
