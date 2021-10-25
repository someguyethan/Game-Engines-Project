using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class Translate : MonoBehaviour
{
    public Text text;

    [DllImport("TranslateDLL", CallingConvention = CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.BStr)]
    private static extern string TranslateMenu(string input);

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            text.text = TranslateMenu(text.text);
    }
}
