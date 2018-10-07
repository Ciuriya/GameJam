using System.Collections.Generic;
using UnityEngine;

public class BuildingBehaviour : MonoBehaviour {

    public BuildingLevel currentLevel;
    public SeasonVariable currentSeason;
    public GameEvent buildingUpgratedEvent;

    // public UIComponent buildingUI;

    public bool canLevelUp()
    {
        if (currentLevel.nextLevel == null)
            return false;

        foreach (var cost in currentLevel.upgradeCosts)
        {
            if (cost.ressourceType.valueReference.Value < cost.delta)
                return false;
        }

        return true;
    }

    public bool LevelUp()
    {
        if (currentLevel.nextLevel != null && canLevelUp())
        {
            List<RessourceTransaction> levelUpCosts = currentLevel.upgradeCosts;

            foreach (var cost in levelUpCosts)
                ModifyRessource(cost.ressourceType, cost.delta);

            currentLevel.ressourceGenTransaction.ressourceType.maxValueReference.Value +=
                currentLevel.maxStorageIncrement;

            currentLevel = currentLevel.nextLevel;

            buildingUpgratedEvent.Raise();
            return true;
        }

        return false;
    }

    public void GenerateRessources()
    {
        RessourceType generationType = currentLevel.ressourceGenTransaction.ressourceType;
        float generationQt = currentLevel.ressourceGenTransaction.delta;

        RessourceTransaction rt = currentSeason.Value.seasonModifiers.Find(sm => sm.ressourceType == generationType);

        ModifyRessource(generationType, generationQt + (rt != null ? rt.delta : 0));
    }

    // Buster proof
    private void ModifyRessource(RessourceType type, float delta)
    {
        // If delta value make your value bust, it assign max value 
        type.valueReference.Value = (type.valueReference.Value + delta > type.maxValueReference.Value) ?
            type.maxValueReference.Value : type.valueReference.Value + delta;

        type.ressourceChangedEvent.Raise();
    }
}
