using UnityEngine;

public class ManagerRoot : Singleton<ManagerRoot>
{
    /*전역 유지 필수*/
    public GameManager GameManager;
    public DataManager DataManager;
    public UIManager UiManager;
    public ResourceManager ResourceManager;
    public SoundManager AudioManager;

    /*인 게임에서만 유지하면 됨*/
    public BattleManager BattleManager;
    public CharacterManager CharacterManager;
    public StageManager StageManager;
    public InventoryManager ItemManager;

    protected override void Awake()
    {
        base.Awake();

        /*동적 할당*/
        GameManager = new();
        DataManager = new();
        UiManager = new();
        ResourceManager = new();
        AudioManager = new();

        BattleManager = new();
        CharacterManager = new();
        StageManager = new();
        ItemManager = new();

        /*초기화 순서*/
        GameManager.Init();
        DataManager.Init();
        UiManager.Init();
        ResourceManager.Init();
        AudioManager.Init();

        BattleManager.Init();
        CharacterManager.Init();
        StageManager.Init();
        ItemManager.Init();
    }
}