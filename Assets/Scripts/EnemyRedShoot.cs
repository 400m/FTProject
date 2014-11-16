using UnityEngine;
using System.Collections;

namespace ftProject
{
	public class EnemyRedShoot : MonoBehaviour {

		float timer;
		public GameObject shootPoint;
		public float timeBetweenBullets;
		public Transform bullet;
		public static bool enable;

		// Use this for initialization
		void Start () {
			enable = false;
			timeBetweenBullets = 3.0f;
		}
		
		// Update is called once per frame
		void Update () {
		
			//Debug.Log (enable);
			if (enable == true)
			{
				timer += Time.deltaTime;
				// ... shoot the gun.
				if (timer >= timeBetweenBullets) 
				{
						// ... shoot the gun.
						shoot ();
				}
			}
		}

		void shoot()
		{
			timer = 0f;
			Instantiate (bullet, shootPoint.transform.position, shootPoint.transform.rotation);
		}
	}
}
