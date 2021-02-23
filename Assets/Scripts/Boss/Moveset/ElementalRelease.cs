using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Perform a fire or thunder attack depending on the element charged from Elemental Charge.
/// </summary>
public class ElementalRelease : Ability
{
	//Private Fields---------------------------------------------------------------------------------------------------------------------------------

	//Serialized Fields----------------------------------------------------------------------------

	[SerializeField] private float moveSpeed;
	[SerializeField] private float radius;

	//Non-Serialized Fields------------------------------------------------------------------------

	private float angleT;
	private float posX, posY, posZ;
	private float currentMoveSpeed;
	private float direction = 1f;

	//Initialization Methods-------------------------------------------------------------------------------------------------------------------------

	/// <summary>
	/// Awake() is run when the script instance is being loaded, regardless of whether or not the script is enabled. 
	/// Awake() runs before Start().
	/// </summary>
	private void Awake()
	{
		abilityName = "Elemental Release";
	}

	/// <summary>
	/// Start() is run on the frame when a script is enabled just before any of the Update methods are called for the first time. 
	/// Start() runs after Awake().
	/// </summary>
	void Start()
    {
		currentMoveSpeed = moveSpeed;
	}

	//Core Recurring Methods-------------------------------------------------------------------------------------------------------------------------

	/// <summary>
	/// Update() is run every frame.
	/// Functionality: Runs Release() if time has not exceeded duration.
	/// </summary>
	protected override void Update()
	{
		base.Update();
		if (timePassed >= abilityDuration)
			isUsing = false;
		if (isUsing)
			Release();
	}

	//Triggered Methods------------------------------------------------------------------------------------------------------------------------------

	private void Release()
	{
		angleT += Mathf.Deg2Rad * moveSpeed * direction * Time.deltaTime;

		posX = radius * Mathf.Cos(angleT);
		posY = transform.localPosition.y;
		posZ = radius * Mathf.Sin(angleT);

		transform.localPosition = new Vector3(posX, posY, posZ);
	}
}
