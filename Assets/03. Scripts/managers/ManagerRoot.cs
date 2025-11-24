public class ManagerRoot : Singleton<ManagerRoot>
{
    /*전역 유지 필수*/
    public GameManager gameManager;
    public DataManager dataManager;
    public UIManager uiManager;
    public ResourceManager resourceManager;
    public SoundManager audioManager;

    /*인 게임에서만 유지하면 됨*/
    public BattleManager battleManager;
    public CharacterManager characterManager;
    public StageManager stageManager;
    public ItemManager itemManager;

    protected override void Awake()
    {
        /*동적 할당*/
        gameManager = new();
        dataManager = new();
        uiManager = new();
        resourceManager = new();
        audioManager = new();

        battleManager = new();
        characterManager = new();
        stageManager = new();
        itemManager = new();


        /*초기화 순서*/
        gameManager.Init();
        dataManager.Init();
        uiManager.Init();
        resourceManager.Init();
        audioManager.Init();

        battleManager.Init();
        characterManager.Init();
        stageManager.Init();
        itemManager.Init();
    }
}