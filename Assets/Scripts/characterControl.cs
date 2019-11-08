using UnityEngine;
using System.Collections;

public class characterControl : MonoBehaviour {

	public float jumpForce = 1000f;
	public float speed = 1.0f;
	public string axisName = "Horizontal";
	public int health = 100; 
	public float deathTimer = 2f;
	public float jumpTimer = 1f; 
	//public float bump = 500f; 

	private bool jumpButtonPressed = false;
	public bool moveLeftPressed = false;
	public bool moveRightPressed = false;

	private Transform groundCheck;
	private bool grounded = false; 
	private Animator animator; 

	public bool alive = true; 
	public bool floating = false; 

	public GameObject NoGoingBack; 
	public AudioClip wilhelm; 

	void Awake()
	{
		//Reference 
		groundCheck = transform.Find ("groundCheck");
		animator = GetComponent<Animator> (); 
	}


	// Use this for initialization
	void Start () {
	
	}

	void FixedUpdate()
	{
		if (alive) 
		{
			/*if (Input.GetAxis (axisName) < 0)
			{
				MoveLeftPress();
				MoveRightRelease();
			} 
			if (Input.GetAxis (axisName) > 0)
			{
				MoveRightPress ();  
				MoveLeftRelease();
			}
			if( Input.GetAxis( axisName) == 0){
				MoveLeftRelease();
				MoveRightRelease();
			}*/
			if( moveLeftPressed ){
				Vector3 newScale = transform.localScale;
				newScale.y = 1.0f;
				newScale.x = -1.0f;
				transform.localScale = newScale;
				transform.position += transform.right *-1* speed * Time.deltaTime;
			}
			if( moveRightPressed ){
				Vector3 newScale =transform.localScale;
				newScale.x = 1.0f;
				transform.localScale = newScale; 
				transform.position += transform.right *1* speed * Time.deltaTime;
			}

			

		}
		
		//moveLeftPressed = false;
		//moveRightPressed = false;
	}

	
	// Update is called once per frame
	void Update () {
	
		if (alive) {
			if( Input.GetButtonDown ("Jump")){
				Jump ();
			}
			//Jumping
			// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
			grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("ground"));

			if (grounded) {
				animator.SetBool ("player_jumping", false);
				floating = false;
				GetComponent<Rigidbody2D>().gravityScale = 1f;

			}

			// If the jump button is pressed and the player is grounded then the player should jump.

			if (jumpButtonPressed && grounded) {
					animator.SetBool ("player_jumping", true);
					GetComponent<Rigidbody2D>().AddForce (new Vector2 (0f, jumpForce));
			}
						
			if (jumpButtonPressed && !grounded && !floating){
				//GetComponent<Rigidbody2D>().AddForce (Vector2.up * bump); 
				floating = true; 
				GetComponent<Rigidbody2D>().gravityScale = 0.0f; 
				GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			}
			
			if(floating) {	
				jumpTimer -= Time.deltaTime; 
				if (jumpTimer < 0) {
					GetComponent<Rigidbody2D>().gravityScale = 1f;
					floating = false;
					jumpTimer = 1f;
				}
			}
		}
		//check if i'm dead 
		if (health < 1 && alive) {
				//Destroy (gameObject);
				alive = false;
				GameManager.instance.playerLiving = false;
				GetComponent<Rigidbody2D>().fixedAngle = false;
				GetComponent<Rigidbody2D>().gravityScale = 0f;
				GetComponent<Rigidbody2D>().mass = .5f;
				GetComponent<Rigidbody2D>().AddForce (Vector2.up * 100);
				GetComponent<Rigidbody2D>().AddTorque (90f);

				animator.SetTrigger ("player_dead"); 
			AudioSource.PlayClipAtPoint(wilhelm, transform.position);
				
		}

		if( !alive){
			deathTimer -= Time.deltaTime;
			GameManager.instance.PopMenu();
			NoGoingBack.SetActive(false); 
			
			if (deathTimer < 0) {
				//Application.LoadLevel (Application.loadedLevel);
			}
		}

		jumpButtonPressed = false;
	}

	public void TakeDamage () {
		animator.SetTrigger ("player_damage"); 
		health -= 10; 
	}

	void OnCollisionEnter2D (Collision2D other){
		if (other.gameObject.tag == "enemy") {
			TakeDamage (); 
			Destroy (other.gameObject); 

		}
		if (other.gameObject.tag == "meteor") {
			TakeDamage (); 
			Destroy (other.gameObject); 
			
		}
	}

	public void Jump(){
		jumpButtonPressed = true;
	}

	public void MoveLeftPress() {
		moveLeftPressed = true;
	}

	public void MoveLeftRelease() {
		moveLeftPressed = false;
	}

	public void MoveRightPress() {
		moveRightPressed = true;
	}

	public void MoveRightRelease() {
		moveRightPressed = false;
	}
}
