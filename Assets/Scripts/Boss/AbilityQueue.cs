using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AbilityQueue : MonoBehaviour
{
	//Private Fields---------------------------------------------------------------------------------------------------------------------------------

	//Serialized Fields----------------------------------------------------------------------------
	private Queue<KeyValuePair<float, Ability>> abilityQueue = new Queue<KeyValuePair<float, Ability>>();
	private Dictionary<string, Ability> abilityDictionary = new Dictionary<string, Ability>();
	private Ability lastAbility;
	private Ability currentAbility;

	private ElementalCharge elementalCharge;
	private ElementalRelease elementalRelease;

	private const string CSV_PATH = "Assets/CSV/BossTimeline.csv";

	public Queue<KeyValuePair<float, Ability>> BossAbilityQueue { get => abilityQueue; set => abilityQueue = value; }
	
	private void Awake()
	{
		InitializeAbility(elementalCharge);
		InitializeAbility(elementalRelease);
		ReadCSV();
	}

	private void ReadCSV()
	{
		StreamReader streamReader = new StreamReader(CSV_PATH);
		bool endOfFile = false;
		while (!endOfFile)
		{
			string data_string = streamReader.ReadLine();
			if (data_string == null)
			{
				endOfFile = true;
				break;
			}
			var data_values = data_string.Split(',');
			abilityQueue.Enqueue(new KeyValuePair<float, Ability>(float.Parse(data_values[0]), GetAbility(data_values[1])));
		}
	}

	private void InitializeAbility<T>(T abilityType)
	{
		abilityType = GetComponent<T>();
		Ability ability = abilityType as Ability;
		abilityDictionary.Add(ability.AbilityName, abilityType as Ability);
	}

	private Ability GetAbility(string abilityName)
	{
		return abilityDictionary[abilityName];
	}
}
