using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Image 컴포넌트를 기반으로 현재 값과 최대 값을 가지고
/// 시각적 정보를 제공하는 오브젝트의 컨트롤러 스크립트
/// </summary>
public class ValueBarController : ValueUIController<int, int>
{
    [Header("Component")]
    [SerializeField] Image image;

    [Header("Stats")]
    [SerializeField] Stat type;
    [SerializeField] Stat maxType;

    CharacterManager characterManager;

#if UNITY_EDITOR
    private void Reset()
    {
        image = GameObject.Find("fill").GetComponent<Image>();
    }
#endif

    #region Unity LifeCycle
    private void Awake()
    {
        characterManager = ManagerRoot.Instance.CharacterManager;

        if(characterManager == null )
        {
            Debug.Log($"characterManager is null");
            return;
        }
    }

    private void OnEnable()
    {
        // 유효하지 않은 키
        Debug.Assert(
            characterManager.StatEvents.ContainsKey(type),
            $"{type} is not Valid"
        );

        // 이벤트가 없는 경우
        if (characterManager.StatEvents.ContainsKey(type)
            && characterManager.StatEvents[type] == null
        )
        {
            Debug.Log($"StatEvents is null");
            return;
        }

        characterManager.StatEvents[type] += ValueChangedHandler;
    }

    private void OnDisable()
    {
        characterManager.StatEvents[type] -= ValueChangedHandler;
    }

    private void Start()
    {
        if (image == null)
        {
            Debug.Log($"[{name}] image is null so, Find component already");
            image = GameObject.Find("fill").GetComponent<Image>();

            Debug.Assert(image != null, $"fill image is not Exist");
        }

        image.fillAmount = (float)characterManager.Stats[type] / characterManager.Stats[maxType];
    }

    #endregion

    protected override void ValueChangedHandler(int value1, int value2)
    {
        image.fillAmount = (float)value1 / value2;
    }
}