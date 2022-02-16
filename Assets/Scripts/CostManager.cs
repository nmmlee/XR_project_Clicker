using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostManager : MonoBehaviour
{
	[System.Serializable]
	public class Building // �ǹ� ����
	{
		public string name; // �ǹ� �̸�
		public int levelCount = 0; // �ǹ� level
		public int[] levels = new int[10]; // �ǹ� ����
	}

	[System.Serializable]
	public class BuildingList
	{
		public Building[] building; // �ǹ���
	}

	public BuildingList buildingList = new BuildingList();
	void Awake()
	{

		List<Dictionary<string, object>> data_test = CSVReader.Read("Build");
		buildingList.building = new Building[data_test.Count];
		for (var i = 0; i < data_test.Count; i++)
		{
			buildingList.building[i] = new Building();
			buildingList.building[i].name = (string)data_test[i]["name"];

			for (var j = 0; j < 10; j++)
			{
				buildingList.building[i].levels[j] = (int)data_test[i]["level" + (j + 1).ToString()];
			}
		}

	}
}
