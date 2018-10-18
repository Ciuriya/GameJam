using System.Collections.Generic;
using UnityEngine;

public class BuildingBehaviour : MonoBehaviour {

    public BuildingLevelVariable currentLevel;
    public SeasonVariable currentSeason;
    public GameEvent buildingUpgratedEvent;

    // public UIComponent buildingUI;

    public bool canLevelUp()
    {
        if (currentLevel.Value.nextLevel == null)
            return false;

        foreach (var cost in currentLevel.Value.upgradeCosts)
        {
            if (cost.ressourceType.valueReference.Value < cost.delta)
                return false;
        }

        return true;
    }

    public bool LevelUp()
    {
        if (currentLevel.Value.nextLevel != null && canLevelUp())
        {
            List<RessourceTransaction> levelUpCosts = currentLevel.Value.upgradeCosts;

            currentLevel.Value.ressourceGenTransaction.ressourceType.maxValueReference.Value +=
                currentLevel.Value.maxStorageIncrement;

			currentLevel.Value = currentLevel.Value.nextLevel;

			foreach (var cost in levelUpCosts)
				ModifyRessource(cost.ressourceType, -cost.delta);

			buildingUpgratedEvent.Raise();
			currentLevel.Value.ressourceGenTransaction.ressourceType.ressourceChangedEvent.Raise();
            return true;
        }

        return false;
    }

    public void GenerateRessources()
    {
        RessourceType generationType = currentLevel.Value.ressourceGenTransaction.ressourceType;
        float generationQt = currentLevel.Value.ressourceGenTransaction.delta;

        RessourceTransaction rt = currentSeason.Value.seasonModifiers.Find(sm => sm.ressourceType == generationType);

        ModifyRessource(generationType, generationQt + (rt != null ? rt.delta : 0));
    }

    // Buster proof
    private void ModifyRessource(RessourceType type, float delta)
    {
        // If delta value make your value bust, it assign max value 
        type.valueReference.Value = (type.valueReference.Value + delta > type.maxValueReference.Value) ?
            type.maxValueReference.Value : type.valueReference.Value + delta;

		if(type.valueReference.Value < 0) type.valueReference.Value = 0;

        type.ressourceChangedEvent.Raise();
    }
}
