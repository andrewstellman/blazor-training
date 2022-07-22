public static class ScoreTracker
{
    public static float LowestScore { get; set; } = 0;

    public static string SubmitScore(float score)
    {
        if ((LowestScore == 0) || (score < LowestScore))
        {
            LowestScore = score;
            return "You got the best time!";
        }
        else
            return string.Empty;
    }
}
