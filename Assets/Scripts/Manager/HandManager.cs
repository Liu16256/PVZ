using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{

    public static HandManager instance { get; private set; }

    public List<Plant> plantPrefabList;

    private Plant currentPlant;
    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        FollowCurser();
    }
    public bool AddPlant(PlantType plantType)
    {
        if (currentPlant != null) return false;

        Plant plantPrefab = GetPlantPrefab(plantType);
        if (plantPrefab == null)
        {
            print("Don't existing");return false;
        }
        currentPlant=GameObject.Instantiate(plantPrefab);
        return true;
    }
    
    private Plant GetPlantPrefab(PlantType plantType)
    {
        foreach (Plant plant in plantPrefabList)
        {
            if(plant.plantType == plantType)
            {
                return plant;
            }
        }
        return null;
    }
    void FollowCurser()
    {
        if (currentPlant == null)
        {
            return;
        }
        Vector3 mouseWorldPosition =Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;
        currentPlant.transform.position = mouseWorldPosition; 
    }
    public void OnCellClick(Cell cell)
    {
        if (currentPlant == null) return;
        
        bool isSuccess = cell.AddPlant(currentPlant);

        if (isSuccess)
        {
            currentPlant = null;
            AudioManager.Instance.PlayClip(Config.plant);
        }
    }
}
