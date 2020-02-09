using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBehaviour : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePosition.y -= 1;
		transform.position = mousePosition;
		Vector3 direction = Vector3.down * 100;

		if (Physics.Raycast(mousePosition, direction, out RaycastHit hit))
		{
			direction = Vector3.down * hit.distance;
			Debug.DrawRay(mousePosition, direction, Color.yellow);
			rayCastHit(hit);
		}
		else
		{
			Debug.DrawRay(mousePosition, direction, Color.white);
		}
	}

	private void rayCastHit(RaycastHit hit)
	{
		switch (hit.collider.tag.ToUpper())
		{
			case Constants.Tags.PLAYTILE:
				FieldTile colliderScript = hit.collider.gameObject.GetComponent<FieldTile>();
				colliderScript.InvokeRayCast();
				break;
			case Constants.Tags.CARD:
				selectCard(hit);
				break;
			default:
				break;
		}
	}

	private void selectCard(RaycastHit card)
	{
		GameObject _card = card.collider.gameObject;
		if (Input.GetMouseButton(0))
		{
			_card.transform.SetParent(this.transform);
		}
		else
		{
			_card.transform.SetParent(null);
		}
	}
}
