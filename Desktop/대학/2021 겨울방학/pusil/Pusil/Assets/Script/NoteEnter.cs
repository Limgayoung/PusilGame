using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteEnter : MonoBehaviour
{
    public GameObject newNotePosition;
    bool onPressedEnter;

    // Start is called before the first frame update
    void Start()
    {
        //처음 시작 위치 노트 생성 위치로 옮겨주기
        transform.position = newNotePosition.GetComponent<Transform>().position;
        onPressedEnter = false;

    }

    // Update is called once per frame
    void Update()
    {
        //노트 아래로 내리기
        transform.Translate(Vector2.down * Time.deltaTime);

        //엔터키 입력받기 키를 누를 때는 onPerssedEnter 값 true, 뗄 때는 false
        if (Input.GetKeyDown(KeyCode.Return))
        {
            onPressedEnter = true;
            Debug.Log(onPressedEnter);
        }
    }

    //충돌 감지 함수
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("충돌함 "+ collision.tag);

        if (onPressedEnter) //엔터키 눌렀을 때만 실행
        {
            Debug.Log("엔터키 눌렀을 때 충돌함 " + collision.tag);
            onPressedEnter = false;
            gameObject.SetActive(false);
        }

        if (collision.name == "missAfterGreat")
        {
            Debug.Log("누르지 않아서 miss " + collision.tag);
            onPressedEnter = false;
            gameObject.SetActive(false);

        }
    }
}
