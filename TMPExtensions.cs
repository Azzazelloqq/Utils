using TMPro;
using UnityEngine;

namespace Utils
{
public static class TMPExtensions
{
    public static void SetTextAlpha(this TMP_Text text, float alpha)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
    }
}
}