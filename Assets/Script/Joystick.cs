using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public int JoystickType;

    public bool isDrag;
    //이 스크립트는 백그라운드에 어사인 해줌
    //터치에 반응할 부분은 백그라운드이기 때문

    //움직이는 범위를 제한하기 위해서 선언함
    [SerializeField] private RectTransform rect_Background;
    [SerializeField] private RectTransform rect_Joystick;

    //백그라운드의 반지름의 범위를 저장시킬 변수
    private float radius;

    [SerializeField] private GameObject obj;
    //화면에서 움직일 플레이어
    [SerializeField] private GameObject go_Player;
    //화면에서 스킬 방향 나타냄
    [SerializeField] private GameObject attackRange;
    //움직일 속도
    [SerializeField] private float moveSpeed;

    //터치가 시작됐을 때 움직이거라
    private bool isTouch = false;
    //움직일 좌표
    private Vector3 movePosition;

    // private Animation anim;
    //캐릭터 회전값을 만들기위해 value를 전역변수로 설정함
    private Vector2 value;

    void Start()
    {
        isDrag = false;
        //inspector에 그 rect Transform에 접근하는 거 맞음
        //0.5를 곱해서 반지름을 구해서 값을 넣어줌
        this.radius = rect_Background.rect.width * 0.5f;

        //    this.anim = this.go_Player.GetComponent<Animation>();
    }

    //이동 구현
    void Update()
    {
        attackRange.transform.position = GameObject.Find("Player").transform.position;
        if (isTouch)
        {
            switch (JoystickType)
            {
                case 1:
                    go_Player.transform.position += movePosition;
                    break;
            }
            
            //조이스틱 방향으로 캐릭터 회전
            if (value != null)
            {
                attackRange.transform.rotation = Quaternion.Euler(0f, 0f, -1 * Mathf.Atan2(value.x, value.y) * Mathf.Rad2Deg);
                /*Debug.Log(Quaternion.Euler(0f, 0f, -1 * Mathf.Atan2(value.x, value.y) * Mathf.Rad2Deg));*/
            }
        }
    }



    //인터페이스 구현

    //눌렀을 때(터치가 시작됐을 때)
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        isTouch = true;
        GameObject.Find("AttackRange").GetComponent<Attack>().isMAttack = true;
        switch (JoystickType)
        {
            case 1: // 이동
                break;
            case 2: // 기본
                GameObject.Find("AttackRange").GetComponent<Attack>().AttackType = 4;
                break;
            case 3: // 넉백
                GameObject.Find("AttackRange").GetComponent<Attack>().AttackType = 2;
                break;
            case 4: // 업글
                GameObject.Find("AttackRange").GetComponent<Attack>().AttackType = 3;
                break;
            case 5: // 스턴
                GameObject.Find("AttackRange").GetComponent<Attack>().AttackType = 1;
                break;
        }
    }

    //손 땠을 때
    public void OnPointerUp(PointerEventData eventData)
    {
        isDrag = false;
        GameObject.Find("AttackRange").GetComponent<Attack>().AttackType = 0;
        //손 땠을 때 원위치로 돌리기
        rect_Joystick.localPosition = Vector2.zero;

        isTouch = false;
        //움직이다 손을 놓았을 때 다시 클릭하면 방향 진행이 되는 현상을 고침
        movePosition = Vector2.zero;

        switch (JoystickType)
        {
            case 2:
                obj.GetComponent<Bullet>().property = Item.Property.Normal;
                break;
            case 3:
                obj.GetComponent<Bullet>().property = Item.Property.Knockback;
                break;
            case 4:
                obj.GetComponent<Bullet>().property = Item.Property.Upgrade;
                break;
            case 5:
                obj.GetComponent<Bullet>().property = Item.Property.Stun;
                break;
        }

        if (BackPack.Instance.FindItem(obj.GetComponent<Bullet>().property).item_Count > 0 && JoystickType != 1)
        {
            obj.GetComponent<Bullet>().dir = Quaternion.Euler(0f, 0f, -1 * Mathf.Atan2(value.x, value.y) * Mathf.Rad2Deg + 44) * new Vector3(1, 1, 1);
            Instantiate(obj);
        }

        //   this.anim.Play("보노보노");
    }

    //드래그 했을때
    public void OnDrag(PointerEventData eventData)
    {
        isDrag = true;
        //마우스 포지션(x축, y축만 있어서 벡터2)
        //마우스 좌표에서 검은색 백그라운드 좌표값을 뺀 값만큼 조이스틱(흰 동그라미)를 움직일 거임
        value = eventData.position - (Vector2)rect_Background.position;

        //가두기
        //벡터2인 자기자신의 값만큼, 최대 반지름만큼 가둘거임
        value = Vector2.ClampMagnitude(value, radius);
        //(1,4)값이 있으면 (-3 ~ 5)까지 가두기 함

        //부모객체(백그라운드) 기준으로 떨어질 상대적인 좌표값을 넣어줌
        rect_Joystick.localPosition = value;

        //value의 방향값만 구하기
        value = value.normalized;
        //x축에 방향에 속도 시간을 곱한 값
        //y축에 0, 점프 안할거라서
        //z축에 y방향에 속도 시간을 곱한 값
        movePosition = new Vector2(value.x * moveSpeed * Time.deltaTime, value.y * moveSpeed * Time.deltaTime);

    //    this.anim.Play("보노보노");
    }
}
