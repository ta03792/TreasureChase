using UnityEngine;
using UnityEngine.UI;

public class BattleInterface : MonoBehaviour
{
    public void ActivateWin()
    {
        BattleManager.Instance.EndBattle(true);
    }

    public void ActivateLose()
    {
        BattleManager.Instance.EndBattle(false);
    }
}
