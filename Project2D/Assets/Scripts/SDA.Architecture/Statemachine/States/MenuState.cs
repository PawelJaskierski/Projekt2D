using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using SDA.Architecture;
using SDA.UI;

public class MenuState : BaseState
{
    private MenuView menuView;
    private UnityAction transition;
    public MenuState(UnityAction transition, MenuView menuView){
        this.transition = transition;
        this.menuView  = menuView;
    }
    public override void DestroyState(){
        menuView?.HideView();
    }

    public override void InitState(){
        menuView?.ShowView();
        menuView.StartButtton.onClick.AddListener(transition);
    }

    public override void UpdateState(){
    }
}
