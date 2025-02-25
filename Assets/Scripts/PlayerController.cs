﻿using UnityEngine;

// Include the namespace required to use Unity UI
using UnityEngine.UI;

using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	// Create public variables for player speed, and for the Text UI game objects

	public Text PickUp;
	public Text countText;
	public Text winText;
	public Text BestText;

	public Button ResetButton;

	// Create private references to the rigidbody component on the player, and the count of pick up objects picked up so far
	public Rigidbody rb;

	public GameObject Camara_end;
	public GameObject Main_Camera;

	public float count;
	public float speed;

	//private Vector3 CamaraNewPosision;

	// At the start of the game.
	void Start ()
	{
		Main_Camera.SetActive(true);
		Camara_end.SetActive(false);

		//CamaraNewPosision = new Vector3(250, 2, -2);


		// Set the count to zero 
		count = 0;

		// Assign the Rigidbody component to our private rb variable
		rb = GetComponent<Rigidbody>();

		

		// Run the SetCountText function to update the UI (see below)
		SetCountText ();

		// Set the text property of our Win Text UI to an empty string, making the 'You Win' (game over message) blank
		winText.text = "";
		BestText.text = "";
		PickUp.text = "Speed++!";

		ResetButton.gameObject.SetActive(false);

		PickUPTextDisble();
	}

	// Each physics step..
	void FixedUpdate ()
	{
		// Set some local float variables equal to the value of our Horizontal and Vertical Inputs
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		// Create a Vector3 variable, and assign X and Z to feature our horizontal and vertical float variables above
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		// Add a physical force to our Player rigidbody using our 'movement' Vector3 above, 
		// multiplying it by 'speed' - our public player speed that appears in the inspector
		rb.AddForce (movement * speed);
	}

	// When this game object intersects a collider with 'is trigger' checked, 
	// store a reference to that collider in a variable named 'other'..
	void OnTriggerEnter(Collider other) 
	{
		// ..and if the game object we intersect has the tag 'Pick Up' assigned to it..
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			// Make the other game object (the pick up) inactive, to make it disappear
			other.gameObject.SetActive (false);

			// Add one to the score variable 'count'
			count = count + 1;

			//Add +1 to speed variable with every pickup
			speed++;

			// Run the 'SetCountText()' function (see below)
			SetCountText ();

			PickUp.gameObject.SetActive(true);
			Invoke("PickUPTextDisble", 40f*Time.deltaTime);
			
		}
	}

	// Create a standalone function that can update the 'countText' UI and check if the required amount to win has been achieved
	public void SetCountText()
	{
		// Update the text field of our 'countText' variable
		countText.text = "Count: " + count.ToString();

		// Check if our 'count' is equal to or exceeded 12
		if (count >= 15 && count < 290)
		{
			// Set the text value of our 'winText'
			winText.text = "Again?";
			ResetButton.gameObject.SetActive(true);
		}
		if (count >= 290)
		{
			BestText.text = "You Win!!!";
			Main_Camera.SetActive(false);
			Camara_end.SetActive(true);
			ResetButton.gameObject.SetActive(true);
			//Destroy(BestText, 10f * Time.deltaTime);
		}
	}

	private void PickUPTextDisble()
    {	
		PickUp.gameObject.SetActive(false);
	}

	public void ResetTheGame()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		print("WORKING");
    }

		
}