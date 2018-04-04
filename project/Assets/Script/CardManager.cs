using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{

    bool clickingChack = false;
    bool actReady = false;
    public Ray ray;
    Transform card;
    Vector3 clickMousePosition; //클릭한 위치 벡터
    Vector3 moveMousePosition;  //움직이는 마우스 위치 벡터
    Vector3 oldCardPosition;    //카드의 원래 위치.
    Vector3 CardPosition;       //갱신되는 카드의 위치.
    float correctuon = 0.025f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        Drag();



    }
    void Drag()
    {
        /*
         버튼을 클릭한 순간의 벡터와 움직이는 벡터로 운동량 벡터를 만든다.
         이후 카드의 현 위치에서 운동량 벡터만큼 움직이게 한다. 버튼을 놓으면 초기 위치로 돌아오게 한다.
         position 을 사용하면 계속해서 더해지기 때문에 카드의 위치벡터를 하나 더 만들어서 마우스가 움직일때만 카드위치의 값이 바뀌게한다.
         
         */
        if (Input.GetMouseButtonDown(0))
        {

            clickMousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (RayCasting(ray, ref card))
            {
                clickingChack = true;
                oldCardPosition = card.position;
                CardPosition = card.position;
            }
        }
        if (clickingChack)
        {
            moveMousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            card.position = CardPosition + ((moveMousePosition - clickMousePosition) * correctuon);
        }

        if (Input.GetMouseButtonUp(0))
        {
            clickingChack = false;
            card.position = oldCardPosition;

            if (actReady)//카드를 드래그해서 놓았을때 그 위치가 발동선을 넘었다면.
            {

            }
            else
            {

            }

        }

    }
    bool RayCasting(Ray ray, ref Transform tmp)//카드를 클릭시 그 카드의 정보를 리턴.
    {
        RaycastHit hitObject;
        if (Physics.Raycast(ray, out hitObject, Mathf.Infinity))
        {
            if (hitObject.transform.tag.Equals("Card"))
            {
                tmp = hitObject.transform;
                return true;
            }
            else return false;
        }
        else return false;
    }

   
}
