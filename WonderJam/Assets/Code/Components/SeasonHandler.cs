using UnityEngine;

public class SeasonHandler : MonoBehaviour
{
    public SeasonVariable currentSeasonVar;
    public FloatVariable currentYearRatio;
    public Season startingSeason;
    public GameEvent changedSeasonEvent;

    public int stepPerSeason = 4;
    public float ratioPerSeason = 0.25f;

    private int currentStep;

    private float ratioPerStep;

    void OnEnable()
    {
        if (startingSeason != null)
            currentSeasonVar.Value = startingSeason;

        ratioPerStep = ratioPerSeason / stepPerSeason;
        currentYearRatio.Value = ratioPerStep;

        UpdateYearRatio();
        changedSeasonEvent.Raise();
    }

    public void Step()
    {
        if (++currentStep >= stepPerSeason)
        {
            currentStep = 0;
            ForwardSeason();
        }

        UpdateYearRatio();
        changedSeasonEvent.Raise();
    }

    public void UpdateYearRatio()
    {
        currentYearRatio.Value = currentSeasonVar.Value.seasonStartRatio + currentStep * ratioPerStep + ratioPerStep;
    }

    private void ForwardSeason()
    {
        currentSeasonVar.Value = currentSeasonVar.Value.nextSeason;  
    }
}
