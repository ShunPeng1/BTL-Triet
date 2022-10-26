using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MultipleChoice : Question
{
    // Start is called before the first frame update
    
    private int choosenAnswer = 0;
    [SerializeField] private Sprite initialSprite;
    [SerializeField] private string [] answerText;
    [SerializeField] private Button [] answerButton ; 
    public override void OnChoosingButton(int index){
        for(int i = 0; i<answerButton.Length ; i++){
            if(index-1 == i) {
                answerButton[i].image.sprite =  answerButton[i].spriteState.selectedSprite;
            }
            else{
                answerButton[i].image.sprite =  initialSprite;
            }
        }
        choosenAnswer = index-1;

    }

    public override string ToStringAnswer(){
        return answerText[choosenAnswer].ToString();
    }

}
