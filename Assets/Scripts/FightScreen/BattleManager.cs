using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityObject = UnityEngine.Object;

internal sealed class BattleManager : MonoBehaviour
{
    [SerializeField]
    private string
        arenaSceneName = "MainScreen",
        battleSceneName = "FightScreen";

    private static BattleManager instance;

    private Scene battleScene;
    private GameObject[] objectsInArenaScene;

    public bool HasActiveBattle { get; private set; }
    public Battle CurrentBattle { get; private set; }

    public static BattleManager Instance
    {
        get
        {
            if (!instance)
            {
                var instances = GameObject.FindObjectsOfType<BattleManager>();
                if (instances.Length > 1)
                {
                    Debug.LogError("More than one BattleManager");
                }

                instance = instances.SingleOrDefault();

                if (!instance)
                {
                    instance = new GameObject("BattleManager").AddComponent<BattleManager>();
                }
            }

            return instance;
        }
    }

    public event Action BattleStarted;

    public void StartBattle(Player player, Character character)
    {
        if (this.HasActiveBattle)
        {
            Debug.LogError("Can't start battle: Battle already active");
            return;
        }

        this.objectsInArenaScene = GameObject.FindObjectsOfType<GameObject>();

        this.StartCoroutine(this.LoadBattleScene(player, character));
    }

    private IEnumerator LoadBattleScene(Player player, Character character)
    {
        var loadingOperation = SceneManager.LoadSceneAsync(this.battleSceneName, LoadSceneMode.Additive);

        yield return new WaitUntil(() => loadingOperation.isDone);

        this.battleScene = SceneManager.GetSceneByName(this.battleSceneName);
        SceneManager.SetActiveScene(this.battleScene);

        var copiedPlayer = UnityObject.Instantiate(player.gameObject).GetComponent<Player>();
        var copiedCharacter = UnityObject.Instantiate(character.gameObject).GetComponent<Character>();

        this.CurrentBattle = new Battle(player, character, copiedPlayer, copiedCharacter);

        this.SetArenaSceneActive(false);

        this.HasActiveBattle = true;
        this.BattleStarted?.Invoke();
    }

    private void SetArenaSceneActive(bool isActive)
    {
        for (int i = 0; i < this.objectsInArenaScene.Length; i++)
        {
            this.objectsInArenaScene[i].SetActive(isActive);
        }
    }

    public void EndBattle(bool playerWon)
    {
        if (!this.HasActiveBattle)
        {
            Debug.LogError("Can't end battle: No battle active");
            return;
        }

        if (playerWon)
        {
            UnityObject.Destroy(this.CurrentBattle.OriginalCharacter.gameObject);
        }
        else
        {
            UnityObject.Destroy(this.CurrentBattle.OriginalPlayer.gameObject);
        }

        this.SetArenaSceneActive(true);
        this.objectsInArenaScene = null;
        SceneManager.UnloadSceneAsync(this.battleScene);

        this.CurrentBattle = default;
        this.HasActiveBattle = false;
    }

    public struct Battle
    {
        public Battle(
            Player originalPlayer, Character originalcharacter,
            Player tokenPlayer, Character tokenCharacter)
        {
            this.OriginalPlayer = originalPlayer;
            this.OriginalCharacter = originalcharacter;
            this.TokenPlayer = tokenPlayer;
            this.TokenCharacter = tokenCharacter;
        }

        public readonly Player OriginalPlayer, TokenPlayer;
        public readonly Character OriginalCharacter, TokenCharacter;
    }
}
