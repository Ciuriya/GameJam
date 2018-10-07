using UnityEngine;
using UnityEngine.UI;

public class BuildingUpdater : MonoBehaviour
{
    public GameObject form;

    public Text oldProduction;
    public Text oldCapacity;
    public Text newProduction;
    public Text newCapacity;

    public Text goldCost;
    public Text stoneCost;
    public Text woodCost;

    public Image oldProductionIcon;
    public Image oldCapacityIcon;
    public Image newProductionIcon;
    public Image newCapacityIcon;

    public Button upgradeButton;
    public Button cancelButton;

    private BuildingBehaviour behavior;
    private bool hasBeenSetup = false;

    void OnEnable()
    {
        behavior = gameObject.GetComponentInParent<BuildingBehaviour>();
    }

    public void Setup(BuildingLevel buildingLevel)
    {
        oldProduction.text = "" + buildingLevel.ressourceGenTransaction.delta;
        oldCapacity.text = "" + buildingLevel.ressourceGenTransaction.ressourceType.maxValueReference.Value;
        oldProductionIcon.sprite = buildingLevel.ressourceGenTransaction.ressourceType.icon;
        oldCapacityIcon.sprite = buildingLevel.ressourceGenTransaction.ressourceType.icon;

        newProductionIcon.sprite = buildingLevel.nextLevel.ressourceGenTransaction.ressourceType.icon;
        newCapacityIcon.sprite = buildingLevel.ressourceGenTransaction.ressourceType.icon;

        if (!buildingLevel.isLastLevel)
        {
            goldCost.text = "" + buildingLevel.upgradeCosts[0].delta;
            stoneCost.text = "" + buildingLevel.upgradeCosts[1].delta;
            woodCost.text = "" + buildingLevel.upgradeCosts[2].delta;

            newProduction.text = "" + buildingLevel.nextLevel.ressourceGenTransaction.delta;
            newCapacity.text = "" + (buildingLevel.ressourceGenTransaction.ressourceType.maxValueReference.Value +
                buildingLevel.maxStorageIncrement);
        }
        else
        {
            goldCost.text = "---";
            stoneCost.text = "---";
            woodCost.text = "---";

            newProduction.text = "---";
            newCapacity.text = "---";
        }

        upgradeButton.interactable = behavior.canLevelUp();
        upgradeButton.onClick.AddListener(delegate
        {
            behavior.LevelUp();
            gameObject.GetComponentInParent<BuildingBehaviour>().gameObject.GetComponentInChildren<InteractableBuilding>().currentLevel = behavior.currentLevel;
            HideForm();
        });
        cancelButton.onClick.AddListener(delegate { HideForm(); });

        hasBeenSetup = true;
    }

    public void ShowForm()
    {
        if (hasBeenSetup) form.SetActive(true);
    }

    public void HideForm()
    {
        form.SetActive(false);
        hasBeenSetup = false;
    }
}
