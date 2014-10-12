using UnityEngine;

[RequireComponent(typeof(PlatformerCharacter2D))]
public class Platformer2DUserControl : MonoBehaviour 
{
	private PlatformerCharacter2D character;
    private bool jump;


	void Awake()
	{
		character = GetComponent<PlatformerCharacter2D>();
	}

    void Update ()
    {
        // Read the jump input in Update so button presses aren't missed.
#if CROSS_PLATFORM_INPUT
        if (CrossPlatformInput.GetButtonDown("Jump")) jump = true;
#else
		if (Input.GetButtonDown("Jump")) jump = true;
#endif

    }

	void FixedUpdate()
	{
		if ( Input.GetKey(KeyCode.Escape))
			Application.LoadLevel("MainMenu");
		// Read the inputs.
		bool attack = Input.GetKey(KeyCode.Mouse0) | Input.GetKey(KeyCode.J);
		bool convert = Input.GetKey(KeyCode.F) | Input.GetKey(KeyCode.K);

		#if CROSS_PLATFORM_INPUT
		float h = CrossPlatformInput.GetAxis("Horizontal");
		#else
		float h = Input.GetAxis("Horizontal");
		#endif

		// Pass all parameters to the character control script.
		character.Move( h, attack , jump, convert );

        // Reset the jump input once it has been used.
	    jump = false;
	}
}
