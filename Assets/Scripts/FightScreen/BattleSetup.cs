using UnityEngine;

public class BattleSetup : MonoBehaviour
{
    [SerializeField]
    private Transform
        playerPosition,
        characterPosition;

    private void OnEnable()
    {
        BattleManager.Instance.BattleStarted += this.OnBattleStarted;
    }

    private void OnDisable()
    {
        // Without this check, an instance of BattleManager might be instantiated when the game closes
        if (BattleManager.Exists)
        {
            BattleManager.Instance.BattleStarted -= this.OnBattleStarted;
        }
    }

    private void OnBattleStarted()
    {
        var battle = BattleManager.Instance.CurrentBattle;

        battle.TokenPlayer.enabled = false;
        battle.TokenCharacter.enabled = false;

        battle.TokenPlayer.transform.position = this.playerPosition.position;
        battle.TokenCharacter.transform.position = this.characterPosition.position;
    }
}
