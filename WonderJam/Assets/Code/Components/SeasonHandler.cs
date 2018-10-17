using UnityEngine;

public class SeasonHandler : MonoBehaviour
{
    public SeasonVariable currentSeasonVar;
    public FloatVariable currentYearRatio;
    public Season startingSeason;
    public GameEvent changedSeasonEvent;

    public int stepPerSeason = 4;
    public float ratioPerSeason = 0.25f;

    public FloatVariable currentStep;

    private float ratioPerStep;

    void OnEnable()
    {
        ratioPerStep = ratioPerSeason / stepPerSeason;
    }

    public void Step()
    {
        if (++currentStep.Value >= stepPerSeason)
        {
			currentStep.Value = 0;
            ForwardSeason();
        }

		UpdateYearRatio();
        changedSeasonEvent.Raise();
    }

    public void UpdateYearRatio()
    {
        currentYearRatio.Value = currentSeasonVar.Value.seasonStartRatio + currentStep.Value * ratioPerStep;
    }

    private void ForwardSeason()
    {
        currentSeasonVar.Value = currentSeasonVar.Value.nextSeason;
	}
}
