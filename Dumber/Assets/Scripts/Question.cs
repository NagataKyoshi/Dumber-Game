
[System.Serializable]
public class Question 
{

    public string question;
    public string answerA;
    public string answerB;
    public string trueAnswer;

    public void Questions(string a, string b, string answer, string questionText)
    {
        answerA = a;
        answerB = b;
        trueAnswer = answer;
        question = questionText;
    }
}
