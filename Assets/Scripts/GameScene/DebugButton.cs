using UnityEngine;

public class DebugButton : MonoBehaviour
{
    [SerializeField] GameDirector gameDirector;
   
    public void onDayPassClicked() {
        gameDirector.debugDayPass();
    }

    public void onFriendlyPlusClicked() {
        gameDirector.debugStatus(0, 0, 10);
    }

    public void onFriendlyMinusClicked() {
        gameDirector.debugStatus(0, 1, 10);
    }

    public void onPowerPlusClicked() {
        gameDirector.debugStatus(1, 0, 100);
    }

    public void onPowerMinusClicked()
    {
        gameDirector.debugStatus(1, 1, 100);

    }

    public void onIntelligentPlusClicked() {
        gameDirector.debugStatus(2, 0, 100);
    }

    public void onIntelligentMinusClicked()
    {
        gameDirector.debugStatus(2, 1, 100);
    }

    public void onMentalPlusClicked() {
        gameDirector.debugStatus(3, 0, 100);
    }

    public void onMentalMinusClicked()
    {
        gameDirector.debugStatus(3, 1, 100);
    }

    public void onAverageClicked() {
        gameDirector.debugStatusAverage();
    }
}
