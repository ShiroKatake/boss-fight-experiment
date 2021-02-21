using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityProcessor : MonoBehaviour
{
	private Boss boss;
	private AbilityQueue abilityQueue;
	private float timePassed;
	private KeyValuePair<float, Ability> currentAbility = new KeyValuePair<float, Ability>();
	private KeyValuePair<float, Ability> nextAbility = new KeyValuePair<float, Ability>();

	private void Awake()
	{
		abilityQueue = GetComponent<AbilityQueue>();
		boss = GetComponent<Boss>();
	}

	private void Start()
	{
		currentAbility = abilityQueue.BossAbilityQueue.Dequeue();
	}

	// Update is called once per frame
	void Update()
    {
		timePassed += Time.deltaTime;
		ExecuteAbility();
	}

	/// <summary>
	/// Gets a random element for an attack.
	/// </summary>
	private void GetRandomElement()
	{
		boss.Element = (EElement)Random.Range(0, 2);
	}

	private void ExecuteAbility()
	{
		Debug.Log("Executing");
		if (abilityQueue.BossAbilityQueue.Count != 0)
			nextAbility = abilityQueue.BossAbilityQueue.Dequeue();

		if (!currentAbility.Value.IsUsing && timePassed >= currentAbility.Key)
		{
			Debug.Log(currentAbility.Value.AbilityName);
			currentAbility.Value.Execute();
			currentAbility = nextAbility;
		}
	}

}
