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
	private EElement element = EElement.None;
	protected string abilityName;
	protected bool isUsing;
	protected float timePassed;

	//Basic Public Properties----------------------------------------------------------------------

	public bool IsUsing { get => isUsing; }
	public bool Finished { get => timePassed >= abilityDuration; }
	public string AbilityName { get => abilityName; }
	public EElement Element { get => element; set => element = value; }

	protected virtual void Update()
	{
		if (isUsing)
			{
				if (timePassed < abilityDuration)
					timePassed += Time.deltaTime;
				if (timePassed > abilityDuration)
					timePassed = abilityDuration;
			}
	}

	/// <summary>
	/// Executes boss ability.
	/// </summary>
	/// <param name="element">Passes boss' element if required.</param>
	public virtual void Execute()
	{
		isUsing = true;
		timePassed = 0f;
	}
}
