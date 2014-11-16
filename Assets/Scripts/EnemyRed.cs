using UnityEngine;
using System.Collections;

namespace ftProject
{
	public class EnemyRed : MonoBehaviour {

		public GameObject top;

		NavMeshAgent NavMesh;
		float rotSpeed = 1.0f;
		Quaternion rotate;
		float timer;

		// Use this for initialization
		void Start () {
		
			NavMesh = GetComponent<NavMeshAgent> ();
		}
		
		// Update is called once per frame
		void Update () {

			Move ();
		}

		void Move()
		{

			//Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			//if (Physics.Raycast(ray, out hit))
			NavMesh.SetDestination(PlayerMovement.playerTranform.position);
				
			//targetPosition = test.transform.position;
			//test2.SetDestination (targetPosition);

		}

		void OnTriggerStay(Collider coll)
		{
			if (coll.tag == "Player") 
			{
				topRotate ();
				EnemyRedShoot.enable = true;
			}
		}

		void OnTriggerExit(Collider coll)
		{
			EnemyRedShoot.enable = false;

		}

		void topRotate()
		{
			rotate = Quaternion.LookRotation (PlayerMovement.playerTranform.position - this.transform.position);
			top.transform.rotation = Quaternion.Slerp (top.transform.rotation, rotate, Time.deltaTime * rotSpeed);
		}
	}
}
