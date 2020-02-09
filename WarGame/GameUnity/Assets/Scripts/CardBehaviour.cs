using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBehaviour : MonoBehaviour
{
	#region Fields
	private Vector3 startPosition;
	private bool dragged = false;
	#endregion

	#region Methods
	// Start is called before the first frame update
	void Start()
	{
		startPosition = transform.position;
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void DragCard(Transform parent)
	{
		dragged = true;
		this.transform.SetParent(parent);
	}

	public void ReleaseCard()
	{
		if (dragged)
		{
			this.transform.SetParent(null);
			playTileCheck();
			dragged = false;
		}
	}

	private void playTileCheck()
	{
		Vector3 rayPoint = transform.position;
		Vector3 direction = Vector3.down * 10;
		direction.x = rayPoint.x;
		direction.z = rayPoint.z;

		if (Physics.Raycast(rayPoint, direction, out RaycastHit hit))
		{
			direction = Vector3.down * hit.distance;
			Debug.DrawLine(rayPoint, direction, Color.green);
			if (hit.transform.tag.ToUpper() == Constants.Tags.PLAYTILE)
				this.transform.position = hit.transform.position;
		}
		else
		{
			Debug.DrawLine(rayPoint, direction, Color.red);
			this.transform.position = startPosition;
		}
	}
	#endregion
}
