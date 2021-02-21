using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Elemental charging ability.
/// </summary>
public class ElementalCharge : AbilityBase
{
	//Private Fields---------------------------------------------------------------------------------------------------------------------------------

	//Serialized Fields----------------------------------------------------------------------------

	[SerializeField] private GameObject fireFX;
	[SerializeField] private GameObject thunderFX;

	[SerializeField] private float moveSpeed;
	[SerializeField] private float radius;
	[SerializeField] private float pitch;
	[SerializeField] private float maxHeight;

	//Non-Serialized Fields------------------------------------------------------------------------

	private Boss boss;

	private float currentMoveSpeed;
	private float startHeight;

	private float direction = 1f;
	private float posX, posY, posZ;
	private float angleT;

	//Initialization Methods-------------------------------------------------------------------------------------------------------------------------

	/// <summary>
	/// Awake() is run when the script instance is being loaded, regardless of whether or not the script is enabled. 
	/// Awake() runs before Start().
	/// Functionality: Get components.
	/// </summary>
	private void Awake()
	{
		boss = GetComponent<Boss>();
	}

	/// <summary>
	/// Start() is run on the frame when a script is enabled just before any of the Update methods are called for the first time. 
	/// Start() runs after Awake().
	/// Functionality: Initialize values.
	/// </summary>
	private void Start()
    {
		currentMoveSpeed = moveSpeed;
		startHeight = transform.position.y;
	}

	//Core Recurring Methods-------------------------------------------------------------------------------------------------------------------------

	/// <summary>
	/// Update() is run every frame.
	/// Functionality: Runs Orbit() if time has not exceeded duration.
	/// </summary>
	private void Update()
	{
		if (timePassed < abilityDuration)
			timePassed += Time.deltaTime;
		else
			isUsing = false;

		if (isUsing)
			Orbit();
	}

	//Triggered Methods------------------------------------------------------------------------------------------------------------------------------

	/// <summary>
	/// Orbits the boss in a spiral, then a circle when reached maximum height.
	/// </summary>
	private void Orbit()
	{
		angleT += Mathf.Deg2Rad * moveSpeed * direction * Time.deltaTime;

		posX = radius * Mathf.Cos(angleT);
		posY = transform.position.y < maxHeight ? pitch * angleT : transform.localPosition.y;
		posZ = radius * Mathf.Sin(angleT);

		transform.localPosition = new Vector3(posX, posY, posZ);
	}

	/// <summary>
	/// Enables particle fx based on element given.
	/// </summary>
	/// <param name="element">Current boss' element.</param>
	private void EnableFX(EElement element)
	{
		switch (element)
		{
			case EElement.Fire:
				fireFX.SetActive(true);
				thunderFX.SetActive(false);
				break;
			case EElement.Thunder:
				fireFX.SetActive(false);
				thunderFX.SetActive(true);
				break;
			default:
				Debug.Log("Element number went out of range.");
				break;
		}
	}

	public override void Execute(int element = 0)
	{
		//EnableFX((EElement)element);
		base.Execute(element);
	}
}
