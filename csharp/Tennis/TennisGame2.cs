namespace Tennis;

public class TennisGame2(string playerOneName, string playerTwoName) : ITennisGame
{
    private int _playerOneScore;
    private int _playerTwoScore;
    public void SetP1Score(int number) => _playerOneScore += number;
    public void SetP2Score(int number) => _playerTwoScore += number;

    public void WonPoint(string player)
    {
        if (player == playerOneName)
            _playerOneScore++;
        else if (player == playerTwoName)
            _playerTwoScore++;
    }

    public string GetScore() =>
        IsScoreTied() ? _playerOneScore >= 3 ? "Deuce" : $"{PointToString(_playerOneScore)}-All" :
        IsAdvantageOrWin() ? GetAdvantageOrWinScore() :
        $"{PointToString(_playerOneScore)}-{PointToString(_playerTwoScore)}";

    private bool IsScoreTied() => _playerOneScore == _playerTwoScore;
    private bool IsAdvantageOrWin() => _playerOneScore >= 4 || _playerTwoScore >= 4;

    private string GetAdvantageOrWinScore()
    {
        var scoreDifference = _playerOneScore - _playerTwoScore;
        return scoreDifference switch
        {
            1 => $"Advantage {playerOneName}",
            -1 => $"Advantage {playerTwoName}",
            >= 2 => $"Win for {playerOneName}",
            _ => $"Win for {playerTwoName}"
        };
    }

    private static string PointToString(int point) =>
        point switch
        {
            0 => "Love",
            1 => "Fifteen",
            2 => "Thirty",
            3 => "Forty",
            _ => ""
        };
}