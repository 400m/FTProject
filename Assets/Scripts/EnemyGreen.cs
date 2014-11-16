using UnityEngine;
using System.Collections;

namespace ftProject
{
	public class EnemyGreen : MonoBehaviour {

		float timer;
		public GameObject shootPoint;
		public float timeBetweenBullets = 0.5f;
		public Transform bullet;
		//public float enemyTimeBetweenBullets = 0.15f;

//		private float rotSpeed = 50.0f;

		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
			timer += Time.deltaTime;
				// ... shoot the gun.
			if (timer >= timeBetweenBullets)
			{
				// ... shoot the gun.
				//shoot ();
			}

			Rotation ();
		}

		void Rotation()
		{
			//float amtToRot = rotSpeed * Time.deltaTime;
			//float ang = Input.GetAxis ("Horizontal");

			//top.transform.Rotate(new Vector3(0, ang * amtToRot, 0));
			transform.LookAt (PlayerMovement.playerTranform);
		}

		void shoot()
		{
			timer = 0f;
			Instantiate (bullet, shootPoint.transform.position, shootPoint.transform.rotation);
		}
	}
}

