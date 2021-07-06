
[System.Serializable]
public class Question 
{

    public string question;
    public string answerA;
    public string answerB;
    public string answerC;
    public string answerD;

    
    public string trueAnswer;

    public void Questions(string a, string b,string c, string answer, string questionText)
    {
        answerA = a;
        answerB = b;
        answerC = c;
        //answerD = d;

        trueAnswer = answer;
        question = questionText;
    }
}
