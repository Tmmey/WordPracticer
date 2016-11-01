using System.Collections.Generic;

namespace WordPractice.Util
{
    public class Answer
    {
        public bool IsCorrect { get; set; }
        public string RightAnswer { get; set; }
        public List<string> AdditionalInfo { get; set; }      
    }
}