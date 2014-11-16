using UnityEngine;
using System.Collections;

public class EnemyBlack : MonoBehaviour {

	public GameObject top;
	
	NavMeshAgent NavMesh;
	public Transform movePoint1;
	public Transform movePoint2;
	bool enable;
	// Use this for initialization
	void Start () {

		NavMesh = GetComponent<NavMeshAgent> ();
		enable = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (enable == false) 
		{
			NavMesh.SetDestination (movePoint1.position);
		}
		else if (enable == true) 
		{
			NavMesh.SetDestination (movePoint2.position);
		}
		Debug.Log (enable);
	}

	void OnTriggerEnter(Collider coll)
	{
		if (coll.tag == "WayPoint1") 
		{
			enable = true;
		} 
		else if (coll.tag == "WayPoint2")
		{ 
			enable = false;
		}
	}
}
