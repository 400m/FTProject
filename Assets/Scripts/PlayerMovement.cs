using UnityEngine;
using System.Collections;

namespace ftProject
{
	public class PlayerMovement : MonoBehaviour
	{
		//public float speed = 6f;            // The speed that the player will move at.
		public GameObject top;
		//Vector3 movement;                   // The vector to store the direction of the player's movement.
		//Animator anim;                      // Reference to the animator component.
		//Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
		int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
		float camRayLength = 100f;          // The length of the ray from the camera into the scene.
		//private Camera cam;
		private RaycastHit hit;
		//Vector3 targetPosition;
		NavMeshAgent NavMesh;
		public static Transform playerTranform;


		void Awake ()
		{
			// Create a layer mask for the floor layer.
			floorMask = LayerMask.GetMask ("Floor");
			// Player 의 NavMesh를 얻어온다.
			NavMesh = GetComponent<NavMeshAgent> ();
			playerTranform = this.transform;
			// Set up references.
			//anim = GetComponent <Animator> ();
			//playerRigidbody = GetComponent <Rigidbody> ();
			//top = GameObject.Find ("top");
			//targetPosition = this.transform.position;

			//cam = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ();
		}

		
		void FixedUpdate ()
		{
			//LookAt 을이용 한방향전환
			/*
			Vector3 m = Input.mousePosition;
			m = cam.ScreenToWorldPoint (new Vector3 (m.x, m.y, m.z));
			m.y = 0f;
			top.transform.LookAt (m);
			*/

			// Turn the player to face the mouse cursor.
			Turning(); // top.rigid

			//mouse right button click -> player move.
			Move();




		}

		void Move()
		{
			if (Input.GetMouseButtonDown (1))
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray, out hit))
					NavMesh.SetDestination(hit.point);
				
				//targetPosition = test.transform.position;
				//test2.SetDestination (targetPosition);
			}
			playerTranform = this.transform;
		}

		void Turning ()
		{
			// Create a ray from the mouse cursor on screen in the direction of the camera.
			Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
			
			// Create a RaycastHit variable to store information about what was hit by the ray.
			RaycastHit floorHit;
			
			// Perform the raycast and if it hits something on the floor layer...
			if(Physics.Raycast (camRay, out floorHit, camRayLength, floorMask))
			{
				// Create a vector from the player to the point on the floor the raycast from the mouse hit.
				//Vector3 playerToMouse = floorHit.point - transform.position;
				
				// Ensure the vector is entirely along the floor plane.
				//playerToMouse.y = 0f;
				
				// Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
				//Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
				
				// Set the player's rotation to this new rotation.
				//playerRigidbody.MoveRotation (newRotation);
				//top.rigidbody.MoveRotation (newRotation);

				top.transform.LookAt (floorHit.point);
			}
		}
		
	
	}
}