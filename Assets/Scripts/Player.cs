using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

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

	public Animator animator;

	public float runSpeed = 20.0f;

	void Start ()
	{
		body = GetComponent<Rigidbody2D>(); 
	}

	void Update ()
	{
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
			animator.SetFloat("last_horizontal", horizontal);
			animator.SetFloat("last_vertical", vertical);
		}

		if (Input.GetKeyUp(KeyCode.E))  {
            // pressed X
            Debug.Log("Pressed E");

			// Cast a ray straight down.
			RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);

			// If it hits something...
			if (hit.collider != null)
			{
				Debug.Log("We hit something");
				Debug.Log(hit.collider);
			}
        }
	}

	private void FixedUpdate()
	{  
		// This is what moves us up/down/right/left
		body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
		// Debug.Log ("Horizontal: " + horizontal.ToString ());
		// Debug.Log ("Vertical: " + vertical.ToString ());
	}

	private void SetDirection() 
	{
		// if last_horizontal is 1 & last_vertical is 0
		// we are facing right
		if (last_horizontal == 1 & last_vertical == 0) 
		{
			direction = "right";
		} 
		// if last_horizontal is -1 & last_vertical is 0
		// we are facing left
		else if (last_horizontal == -1 & last_vertical == 0)
		{
			direction = "left";
		}
		// if last_horizontal is 0 & last_vertical is 1
		// we are facing up
		else if (last_horizontal == 0 & last_vertical == 1)
		{
			direction = "up";
		}
		// if last_horizontal is 0 & last_vertical is -1
		// we are facing down
		else if (last_horizontal == 0 & last_vertical == -1)
		{
			direction = "down";
		}
	}
}
