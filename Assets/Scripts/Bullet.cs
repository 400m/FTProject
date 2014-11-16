using UnityEngine;
using System.Collections;

namespace ftProject
{
	public class Bullet : MonoBehaviour {

		public LayerMask collisionMask;
		//public Vector3 firePos;
		public int count = 0;
		private float speed = 40;


		// Use this for initialization
		void Start () {
			//firePos = this.transform.position;
		}
		
		// Update is called once per frame
		void Update () {
			transform.Translate (Vector3.forward * Time.deltaTime * speed);
			//transform.Rotate (Vector3.forward * Time.deltaTime * rotSpeed);

			Ray ray = new Ray (transform.position, transform.forward);
			RaycastHit hit;

			if(Physics.Raycast(ray, out hit, Time.deltaTime * speed + .1f, collisionMask))
			{
				Vector3 reflectDir = Vector3.Reflect(ray.direction, hit.normal);
				float rot = 90 - Mathf.Atan2(reflectDir.z, reflectDir.x) * Mathf.Rad2Deg;
				transform.eulerAngles = new Vector3(0, rot, 0);
			}
		}

		void OnTriggerEnter(Collider coll)
		{
			switch (coll.tag) 
			{
			case "Wall":
				count++;
				if(count > 1)
				{
					Destroy(gameObject);
					Debug.Log("i'm die");
					PlayerShooting.bulletCount--;
				}
				else
				{

				}
				break;
			case "Enemy":
				Debug.Log("Enemy");
				Destroy(gameObject);
				PlayerShooting.bulletCount--;
				break;
			}

		}
	}
}
