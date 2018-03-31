using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnTriggerEvent : EventTrigger {
    //通过委托事件让UIScene来分配事件
    public delegate void ClickListener();
    public event ClickListener onBeginDrag;
    public event ClickListener onDrag;
    public event ClickListener onEndDrag;
    public event ClickListener onPointerClick;
    public event ClickListener onPointerUp;
    ///UI的相关监听//鼠标进入

    public override void OnBeginDrag(PointerEventData eventdata)
    {
        if (onBeginDrag != null)
            onBeginDrag();
    }
    public override void OnDrag(PointerEventData eventdata)
    {
        if (onDrag != null)
            onDrag();
    }

    public override void OnEndDrag(PointerEventData eventdata)
    {
        if (onEndDrag != null)
            onEndDrag();
    }
    public override void OnPointerClick(PointerEventData eventdata)
    {
        if (onPointerClick != null)
            onPointerClick();
    }

    //public override void OnPointerUp(PointerEventData eventdata)
    //{
    //    if (onPointerUp != null)
    //        onPointerUp();
    //}

}
