using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
internal sealed class ShootSetup : MonoBehaviour
{
    private Button button;

    private void Awake()
    {
        this.button = this.GetComponent<Button>();
    }

    private void OnEnable()
    {
        BattleManager.Instance.BattleStarted += this.OnBattleStarted;
    }

    private void OnDisable()
    {
        BattleManager.Instance.BattleStarted -= this.OnBattleStarted;
        this.button.onClick.RemoveAllListeners();
    }

    private void OnBattleStarted()
    {
        this.button.onClick.AddListener(BattleManager.Instance.CurrentBattle.TokenPlayer.GetComponent<PlayerFight>().Shoot);
    }
}