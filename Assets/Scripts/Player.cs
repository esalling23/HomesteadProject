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
	public int stamina = 50;

	private Tile activeTile;

	void Start ()
	{
		body = GetComponent<Rigidbody2D>(); 
		animator = GetComponent<Animator>();
		itemBar = GameObject.Find("UI").GetComponent<ItemBar>();
	}

	void Update ()
	{
		// Manages walking movement + animation
		Walk();
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

	public Tile FindTile ()  
	{
        // Cast a ray straight down in "front" of the player.
		// Combines the current "direction" using the  last_horizontal & last_vertical values
		// with the player's current position
        Vector2 position = new Vector2(last_horizontal, last_vertical) + (Vector2)transform.position;
        // Debug.Log(position);
        RaycastHit2D hit = Physics2D.Raycast(position, Vector2.down);
		Debug.DrawRay(position, Vector2.down, Color.green);

        // If it hits something that is not the player...
        if (hit.collider != null && hit.transform != null && (string)hit.transform.name != "Player")
        {
            Debug.Log("We hit something");
            Debug.Log(hit.transform.name);
            return hit.collider.gameObject.GetComponent<Tile>();
        }

		return null;
	}

	public void Consume(int h, int s) 
	{
		health += h;
		stamina += s;
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
