using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Executes various boss' abilities using the timeline created from Ability Queue.
/// </summary>
public class AbilityProcessor : MonoBehaviour
{
	//Private Fields---------------------------------------------------------------------------------------------------------------------------------

	//Non-Serialized Fields----------------------------------------------------------------------------
	private Boss boss;
	private AbilityQueue abilityQueue;
	private float timePassed;
	private AbilityExecutionData currentAbility;
	private AbilityExecutionData nextAbility;

	//Initialization Methods-------------------------------------------------------------------------------------------------------------------------

	/// <summary>
	/// Awake() is run when the script instance is being loaded, regardless of whether or not the script is enabled. 
	/// Awake() runs before Start().
	/// </summary>
	private void Awake()
	{
		abilityQueue = GetComponent<AbilityQueue>();
		boss = GetComponent<Boss>();
	}

	/// <summary>
	/// Start() is run on the frame when a script is enabled just before any of the Update methods are called for the first time. 
	/// Start() runs after Awake().
	/// </summary>
	private void Start()
	{
		currentAbility = abilityQueue.BossAbilityQueue.Dequeue();
	}

	//Core Recurring Methods-------------------------------------------------------------------------------------------------------------------------

	/// <summary>
	/// Update() is run every frame.
	/// Functionality: Keep track of time and use that to execute abilities according to timeline.
	/// </summary>
	void Update()
    {
		timePassed += Time.deltaTime;
		ExecuteAbilities(timePassed);
	}

	//Triggered Methods------------------------------------------------------------------------------------------------------------------------------

	/// <summary>
	/// Execute abilities according to the time passed relative to the timeline.
	/// </summary>
	/// <param name="timePassed"></param>
	private void ExecuteAbilities(float timePassed)
	{
		if (currentAbility != null && !currentAbility.ability.IsUsing && timePassed >= currentAbility.timeOfExecution)
		{
			boss.Element = currentAbility.element;
			Debug.Log($"Boss' Element: {boss.Element}");
			currentAbility.ability.Execute();
			Debug.Log($"Ability' Element: {currentAbility.ability.Element}");

			if (abilityQueue.BossAbilityQueue.Count != 0)
				currentAbility = abilityQueue.BossAbilityQueue.Dequeue();
			else
				currentAbility = null;
		}
	}

}
