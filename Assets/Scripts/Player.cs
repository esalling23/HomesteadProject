using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Used for actual movement
	private Rigidbody2D body;

	// Used for Walk animation
	private float horizontal;
	private float vertical;

	// Used for Idle "animation"
	private float last_horizontal;
	private float last_vertical;

	// Direction string value
	// Not sure yet what Ill need this for...
	private string direction;

	// Player animator
	public Animator animator;

	// Movement speed
	public float runSpeed = 20.0f;

	// Selected tool
	// currentTool is a Tool class
	private Tool currentTool;

	void Start ()
	{
		body = GetComponent<Rigidbody2D>(); 
	}

	void Update ()
	{
		// Manages walking movement + animation
		Walk();

		// Determine if we've pressed a number on the keyboard to select a tool
		int pressedNumber = GetPressedNumber();

		// Manage keyboard input
		if (Input.GetKeyUp(KeyCode.E))  {
            // pressed E to use tool
            UseTool();
        } else if (pressedNumber != -1) {
			// Tool bar change - select tools 1 - 9
			Debug.Log("Pressed number " + pressedNumber.ToString());
			// ToolBar.ChangeTool(pressedNumber)
		}
	}

	private void FixedUpdate()
	{  
		// This is what moves us up/down/right/left
		body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
		// Debug.Log ("Horizontal: " + horizontal.ToString ());
		// Debug.Log ("Vertical: " + vertical.ToString ());
	}

	private void Walk() {
		// WASD and the arrow keys make up the vertical/horizontal axes
		vertical = Input.GetAxisRaw("Vertical");
		horizontal = Input.GetAxisRaw ("Horizontal");

		// Set animator's vertical & horizontal float variables
		// to match the current vertical & horizontal axis values
		animator.SetFloat ("vertical", vertical);
		animator.SetFloat ("horizontal", horizontal);

		// if either vertical or horizontal is not 0
		// then we made movement
		if (vertical != 0 ^ horizontal != 0) 
		{
			last_horizontal = horizontal;
			last_vertical = vertical;
			animator.SetFloat("last_horizontal", last_horizontal);
			animator.SetFloat("last_vertical", last_vertical);
		}
	}

	private void UseTool() 
	{
		Debug.Log("Pressed E");

		Debug.Log((Vector2)transform.position);
		Debug.Log(new Vector2(last_horizontal, last_vertical));

		// Cast a ray straight down in front of us.
		Vector2 position = (Vector2)transform.position + new Vector2(last_horizontal, last_vertical);
		Debug.Log(position);
		RaycastHit2D hit = Physics2D.Raycast(position, Vector2.down);

		// If it hits something that is not the player (ourself)...
		if (hit.collider != null && hit.transform != null && (string)hit.transform.name != "Player")
		{
			Debug.Log("We hit something");
			Debug.Log(hit.transform.name);
			Tile tileScript = hit.collider.gameObject.GetComponent<Tile>();
			tileScript.Activate();
		}
	}

	// https://forum.unity.com/threads/setting-an-integer-to-a-number-pressed.510688/
	// Loops over nums 1 - 9 & checks for input from each
	// If it finds input, returns the number. Otherwise returns -1
	private int GetPressedNumber() {
		for (int number = 0; number <= 9; number++) {
			if (Input.GetKeyDown(number.ToString()))
				return number;
		}
	
		return -1;
	}

	// private void SetDirection() 
	// {
	// 	// if last_horizontal is 1 & last_vertical is 0
	// 	// we are facing right
	// 	if (last_horizontal == 1 & last_vertical == 0) 
	// 	{
	// 		direction = "right";
	// 	} 
	// 	// if last_horizontal is -1 & last_vertical is 0
	// 	// we are facing left
	// 	else if (last_horizontal == -1 & last_vertical == 0)
	// 	{
	// 		direction = "left";
	// 	}
	// 	// if last_horizontal is 0 & last_vertical is 1
	// 	// we are facing up
	// 	else if (last_horizontal == 0 & last_vertical == 1)
	// 	{
	// 		direction = "up";
	// 	}
	// 	// if last_horizontal is 0 & last_vertical is -1
	// 	// we are facing down
	// 	else if (last_horizontal == 0 & last_vertical == -1)
	// 	{
	// 		direction = "down";
	// 	}
	// }
}
