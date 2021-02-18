using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coil : MonoBehaviour
{
	[SerializeField] private float moveSpeed;
	[SerializeField] private float rotateSpeed;
	[SerializeField] private float pitchSpeed;
	[SerializeField] private float maxHeight;

	float currentMoveSpeed;
	float currentRotateSpeed;
	float currentPitchSpeed;
	float startHeight;

	float moving = 1f;
    // Start is called before the first frame update
    void Start()
    {
		currentMoveSpeed = moveSpeed;
		currentRotateSpeed = rotateSpeed;
		currentPitchSpeed = pitchSpeed;
		startHeight = transform.position.y;
		Debug.Log(transform.position.y < maxHeight);
	}

	// Update is called once per frame
	void Update()
	{
		Debug.Log(moving);
		Orbit();
		MoveUp();
		MoveDown();
		if (transform.position.y > maxHeight)
		{
			moving = -1;
		}

		if (transform.position.y < startHeight)
		{
			moving = 0;
		}
	}

	void Orbit()
	{
		transform.Rotate(Vector3.up, currentRotateSpeed * Time.deltaTime);
		transform.Translate(Vector3.forward * currentMoveSpeed * Time.deltaTime);
	}

	void MoveUp()
	{
		if (moving == 1)
			transform.Translate(Vector3.up * currentPitchSpeed * Time.deltaTime);
		
	}

	void MoveDown()
	{
		Debug.Log("movedown");
		if (moving == -1)
			transform.Translate(Vector3.up * -currentPitchSpeed * Time.deltaTime);
	}

	IEnumerator Charge()
	{
		Orbit();

		yield return null;
	}
}
