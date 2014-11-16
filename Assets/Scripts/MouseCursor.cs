using UnityEngine;
using System.Collections;

public class MouseCursor : MonoBehaviour {
	//마우스 포인터로 사용할 텍스쳐	
	public Texture2D cursorTexture;
	//텍스처의 중심을 마우스 좌표로할것인지체크박스로입력
	public bool hotSpotIsCenter = false;
	//택스쳐의좌표입력
	public Vector2 adjustHotSpot = Vector2.zero;
	
	private Vector2 hotSpot;
	
	// Use this for initialization
	void Start () {
		
		StartCoroutine ("MyCorsor");
		
	}

	IEnumerator MyCorsor(){
		
		yield return new WaitForEndOfFrame();
		
		if (hotSpotIsCenter) {
			hotSpot.x = cursorTexture.width / 2;
			hotSpot.y = cursorTexture.height / 2;
		} else {
			hotSpot = adjustHotSpot;
		}
		
		Cursor.SetCursor (cursorTexture, hotSpot, CursorMode.Auto);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
