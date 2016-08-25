using UnityEngine;
using System.Collections;

public class PlayerInput: MonoBehaviour {

    public PlayerInputs Current;
    public string PlayerNumber = "1";

	// Use this for initialization
	void Start () {
        Current = new PlayerInputs();
	}
	
	// Update is called once per frame
	void Update () {
        

        // Retrieve our current WASD or Arrow Key input
        // Using GetAxisRaw removes any kind of gravity or filtering being applied to the input
        // Ensuring that we are getting either -1, 0 or 1   
        Vector2 moveInput = Vector2.zero;
        float temptolerance = 0.1f;
        if (Input.GetAxis("Horizontal") > temptolerance)
            moveInput.x = 1;
        else if (Input.GetAxis("Horizontal") < -temptolerance)
            moveInput.x = -1;
        if (Input.GetAxis("Vertical") > temptolerance)
            moveInput.y = 1;
        else if (Input.GetAxis("Vertical") < -temptolerance)
            moveInput.y = -1;
        
        bool attackInput = Input.GetButtonDown("Fire1");
        //bool jumpInput = Input.GetButtonDown("A Button" + PlayerNumber);
        //bool continuousJumpInput = Input.GetButton("X Button" + PlayerNumber);
        
        //bool sticky = Input.GetButtonDown("X Button" + PlayerNumber);
        //bool debug = Input.GetButton("X Button" + PlayerNumber);
        //bool recall = Input.GetButtonDown("Y Button" + PlayerNumber);
        //bool leftbumper = Input.GetButtonDown("Swap Left" + PlayerNumber);
        //bool rightbumper = Input.GetButtonDown("Swap Right" + PlayerNumber);

        Current = new PlayerInputs()
        {
            MoveInput = moveInput,
            AttackInput = attackInput,
            //ContinuousJumpInput = continuousJumpInput,
            //Sticky = sticky,
            //Debug = debug,
            //LeftBumper = leftbumper,
            //RightBumper = rightbumper,
            //Recall = recall
            
        };
	}
}

public struct PlayerInputs
{
    public Vector2 MoveInput;
    public bool AttackInput;
    public bool JumpInput;
    public bool ContinuousJumpInput;
    public bool Sticky;
    public bool Debug;
    public bool LeftBumper;
    public bool RightBumper;
    public bool Recall;
}