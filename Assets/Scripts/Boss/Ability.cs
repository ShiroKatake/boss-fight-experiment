using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for every boss ability.
/// </summary>
public abstract class Ability : MonoBehaviour
{
	//Protected Fields---------------------------------------------------------------------------------------------------------------------------------

	//Serialized Fields----------------------------------------------------------------------------

	[SerializeField] protected float abilityDuration;

	//Non-Serialized Fields------------------------------------------------------------------------

	protected bool isUsing;
	protected float timePassed;

	//Basic Public Properties----------------------------------------------------------------------

	public bool Finished { get => timePassed >= abilityDuration; }

	private void Update()
	{
		if (timePassed < abilityDuration)
			timePassed += Time.deltaTime;
		if (timePassed > abilityDuration)
			timePassed = abilityDuration;
	}

	/// <summary>
	/// Executes boss ability.
	/// </summary>
	/// <param name="element">Passes boss' element if required.</param>
	public virtual void Execute(int element = 0)
	{
		isUsing = true;
		timePassed = 0f;
	}
}
