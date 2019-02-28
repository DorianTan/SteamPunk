using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLightPanel : MonoBehaviour
{
    [SerializeField] private CanvasGroup UIelement;

    public void BtnOpaque()
    {
        UIelement.alpha = 1;
    }
    public void Btndfa()
    {
        UIelement.alpha = 0;
    }

}
