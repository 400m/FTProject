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
	}
	
	// Update is called once per frame
	void Update () {
	
		NavMesh.SetDestination(movePoint1.position);
		if (this.transform.position == movePoint1.position) 
		{
			NavMesh.SetDestination(movePoint2.position);
		}
		else if(this.transform.position == movePoint2.position)
		{
			NavMesh.SetDestination(movePoint1.position);
		}
	}

	void OnTriggerEnter(Collider coll)
	{
		if(coll.tag)
	}
}
