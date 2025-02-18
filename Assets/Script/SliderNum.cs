using UnityEngine;
using UnityEngine.UI;
public class SliderNum : MonoBehaviour
{
    public Text num_text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void SetNum(int n, int max)
    {
        num_text.text = $"{n}/{max}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
