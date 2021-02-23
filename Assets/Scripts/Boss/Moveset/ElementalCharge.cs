using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Elemental charging ability.
/// </summary>
public class ElementalCharge : Ability
{
	//Private Fields---------------------------------------------------------------------------------------------------------------------------------

	//Serialized Fields----------------------------------------------------------------------------

	[SerializeField] private GameObject fireFX;
	[SerializeField] private GameObject thunderFX;

	[SerializeField] private float moveSpeed;
	[SerializeField] private float acceleratedSpeed;
	[SerializeField] private float accelerationDuration;
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

	private float accelerationTimePassed;

	private float test;

	//Initialization Methods-------------------------------------------------------------------------------------------------------------------------

	/// <summary>
	/// Awake() is run when the script instance is being loaded, regardless of whether or not the script is enabled. 
	/// Awake() runs before Start().
	/// Functionality: Get components.
	/// </summary>
	private void Awake()
	{
		abilityName = "Elemental Charge";
		boss = GetComponent<Boss>();
	}

	/// <summary>
	/// Start() is run on the frame when a script is enabled just before any of the Update methods are called for the first time. 
	/// Start() runs after Awake().
	/// Functionality: Initialize values.
	/// </summary>
	private void Start()
    {
		Initialize();
	}

	//Core Recurring Methods-------------------------------------------------------------------------------------------------------------------------

	/// <summary>
	/// Update() is run every frame.
	/// Functionality: Runs Orbit() if time has not exceeded duration.
	/// </summary>
	protected override void Update()
	{
		base.Update();
		if (timePassed >= abilityDuration)
			isUsing = false;

		SpeedControl();

		if (isUsing)
			Coil();
	}

	//Triggered Methods------------------------------------------------------------------------------------------------------------------------------

	private void Initialize()
	{
		accelerationTimePassed = 0f;
		currentMoveSpeed = 0f;
		startHeight = transform.position.y;
	}

	/// <summary>
	/// Orbits the boss in a spiral, then a circle when reached maximum height.
	/// </summary>
	private void Coil()
	{
		angleT += Mathf.Deg2Rad * currentMoveSpeed * direction * Time.deltaTime;

		posX = radius * Mathf.Cos(angleT);
		posY = transform.position.y < maxHeight ? pitch * angleT : transform.localPosition.y;
		posZ = radius * Mathf.Sin(angleT);

		transform.localPosition = new Vector3(posX, posY, posZ);
	}

	/// <summary>
	/// Controls boss' speed.
	/// </summary>
	private void SpeedControl()
	{
		if (transform.position.y < maxHeight)
		{
			if (currentMoveSpeed < moveSpeed)
				currentMoveSpeed = Accelerate(0f, moveSpeed, true);
			else
				accelerationTimePassed = 0f;
		}
		else
		{
			if (currentMoveSpeed < acceleratedSpeed)
				currentMoveSpeed = Accelerate(moveSpeed, acceleratedSpeed, false);
			else
				accelerationTimePassed = 0f;
		}
	}

	/// <summary>
	/// Accelerate boss' speed.
	/// </summary>
	private float Accelerate(float startSpeed, float endSpeed, bool easeIn)
	{
		accelerationTimePassed += Time.deltaTime;
		float t = accelerationTimePassed / accelerationDuration;
		if (easeIn)
			t = 1f - Mathf.Cos(t * Mathf.PI * 0.5f);
		return Mathf.Lerp(startSpeed, endSpeed, t);
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

	public override void Execute()
	{
		Initialize();
		Element = boss.Element;
		//EnableFX((EElement)element);
		base.Execute();
	}
}
