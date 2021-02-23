using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// Contains data on how to execute a boss ability for the Ability Processor.
/// </summary>
public class AbilityExecutionData
{
	public float timeOfExecution;
	public Ability ability;
	public EElement element;

	public AbilityExecutionData(float timeOfExecution, Ability ability, EElement element)
	{
		this.timeOfExecution = timeOfExecution;
		this.ability = ability;
		this.element = element;
	}
}

/// <summary>
/// Prepares a timeline of boss abilities for the Ability Processor to use and execute.
/// </summary>
public class AbilityQueue : MonoBehaviour
{
	//Private Fields---------------------------------------------------------------------------------------------------------------------------------

	//Non-Serialized Fields----------------------------------------------------------------------------
	private const string CSV_PATH = "Assets/CSV/BossTimeline.csv";

	private Queue<AbilityExecutionData> abilityQueue = new Queue<AbilityExecutionData>();
	private Dictionary<string, Ability> abilityDictionary = new Dictionary<string, Ability>();

	#region Boss Abilities
	private ElementalCharge elementalCharge;
	private ElementalRelease elementalRelease;
	#endregion

	private EElement firstElement;

	//Basic Public Properties----------------------------------------------------------------------

	public Queue<AbilityExecutionData> BossAbilityQueue { get => abilityQueue; set => abilityQueue = value; }

	//Initialization Methods-------------------------------------------------------------------------------------------------------------------------

	/// <summary>
	/// Awake() is run when the script instance is being loaded, regardless of whether or not the script is enabled. 
	/// Awake() runs before Start().
	/// </summary>
	private void Awake()
	{
		InitializeAbility(elementalCharge);
		InitializeAbility(elementalRelease);
		ReadCSV();
	}

	//Triggered Methods------------------------------------------------------------------------------------------------------------------------------

	/// <summary>
	/// Read the CSV file containing data on the timeline.
	/// </summary>
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
			//Debug.Log($"{data_values[0]}, {data_values[1]}, {data_values[2]}");
			EnqueueAbilities(data_values);
		}
	}

	/// <summary>
	/// Get component for the specified ability and add it to the dictionary of abilities.
	/// </summary>
	/// <typeparam name="T">Generic ability parameter.</typeparam>
	/// <param name="abilityType">Ability type that the function will get the component of.</param>
	private void InitializeAbility<T>(T abilityType)
	{
		abilityType = GetComponent<T>();
		Ability ability = abilityType as Ability;
		abilityDictionary.Add(ability.AbilityName, ability);
	}
	
	/// <summary>
	/// Add the ability to the timeline queue according to the line read from the CSV file.
	/// </summary>
	/// <param name="dataValues">Data read from the CSV file.</param>
	private void EnqueueAbilities(string[] dataValues)
	{
		abilityQueue.Enqueue(GenerateExecutionData(float.Parse(dataValues[0]), dataValues[1], dataValues[2]));
	}

	/// <summary>
	/// Generate the execution data for the ability to be added to the queue,
	/// </summary>
	/// <param name="executionTime">Time ability will be executed.</param>
	/// <param name="abilityName">Boss ability's name.</param>
	/// <param name="aElement">Element for the ability.</param>
	/// <returns></returns>
	private AbilityExecutionData GenerateExecutionData(float executionTime, string abilityName, string aElement)
	{
		EElement element = EElement.None;

		switch (aElement)
		{
			case "Random":
				element = GetRandomElement();
				firstElement = element;
				break;
			case "Other":
				element = firstElement == EElement.Fire ? EElement.Thunder : EElement.Fire;
				break;
			case "":
				break;
			default:
				element = (EElement)System.Enum.Parse(typeof(EElement), aElement);
				break;
		}

		return new AbilityExecutionData(executionTime, abilityDictionary[abilityName], element);
	}

	//TODO: Change this to GetElement instead.
	/// <summary>
	/// Gets a random element for an attack.
	/// </summary>
	private EElement GetRandomElement()
	{
		return (EElement)Random.Range((int)EElement.Fire, (int)EElement.Thunder + 1);
	}
}
