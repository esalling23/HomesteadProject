using UnityEngine;
using System.Collections;

public class Player : BaseObject {

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

	// Item Bar
	private ItemBar itemBar;
	private Item selectedItem;

	// Health and other stats
	public int health = 50;

	void Start ()
	{
		body = GetComponent<Rigidbody2D>(); 
		animator = GetComponent<Animator>();
		itemBar = GameObject.Find("ItemBar").GetComponent<ItemBar>();
	}

	void Update ()
	{
		// Manages walking movement + animation
		Walk();

		// Manage keyboard input
		if (Input.GetKeyUp(KeyCode.E))  {
			// Get the currently selected item from the item bar
			selectedItem = itemBar.GetItem();
            // pressed E to use item
			Debug.Log("Time to use the selected item called: " + selectedItem.name);

			// Tell the item about our position & which direction we're facing
			selectedItem.Use(transform.position, new Vector2(last_horizontal, last_vertical));
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

	// UseItem method controls the 
    private void UseItem(Vector2 direction) 
	{
		Debug.Log("How should we use this " + selectedItem.type + "?");

		
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
