namespace Tennis;

public class TennisGame2(string playerOneName, string playerTwoName) : ITennisGame
{
    private int _playerOneScore = 0;
    private int _playerTwoScore;
    private string p1res = "";
    private string p2res = "";
    private string _playerOneName = playerOneName;
    private string _playerTwoName = playerTwoName;
    public void SetP1Score(int number) => _playerOneScore += number;
    public void SetP2Score(int number) => _playerTwoScore += number;

    public void WonPoint(string player)
    {
        if (player == _playerOneName)
            _playerOneScore++;
        else if (player == _playerTwoName)
            _playerTwoScore++;
    }

    public string GetScore()
    {
        var score = "";
        if (_playerOneScore == _playerTwoScore && _playerOneScore < 3)
        {
            if (_playerOneScore == 0)
                score = "Love";
            if (_playerOneScore == 1)
                score = "Fifteen";
            if (_playerOneScore == 2)
                score = "Thirty";
            score += "-All";
        }

        if (_playerOneScore == _playerTwoScore && _playerOneScore > 2)
            score = "Deuce";

        if (_playerOneScore > 0 && _playerTwoScore == 0)
        {
            if (_playerOneScore == 1)
                p1res = "Fifteen";
            if (_playerOneScore == 2)
                p1res = "Thirty";
            if (_playerOneScore == 3)
                p1res = "Forty";

            p2res = "Love";
            score = p1res + "-" + p2res;
        }

        if (_playerTwoScore > 0 && _playerOneScore == 0)
        {
            if (_playerTwoScore == 1)
                p2res = "Fifteen";
            if (_playerTwoScore == 2)
                p2res = "Thirty";
            if (_playerTwoScore == 3)
                p2res = "Forty";

            p1res = "Love";
            score = p1res + "-" + p2res;
        }

        if (_playerOneScore > _playerTwoScore && _playerOneScore < 4)
        {
            if (_playerOneScore == 2)
                p1res = "Thirty";
            if (_playerOneScore == 3)
                p1res = "Forty";
            if (_playerTwoScore == 1)
                p2res = "Fifteen";
            if (_playerTwoScore == 2)
                p2res = "Thirty";
            score = p1res + "-" + p2res;
        }

        if (_playerTwoScore > _playerOneScore && _playerTwoScore < 4)
        {
            if (_playerTwoScore == 2)
                p2res = "Thirty";
            if (_playerTwoScore == 3)
                p2res = "Forty";
            if (_playerOneScore == 1)
                p1res = "Fifteen";
            if (_playerOneScore == 2)
                p1res = "Thirty";
            score = p1res + "-" + p2res;
        }

        if (_playerOneScore > _playerTwoScore && _playerTwoScore >= 3)
        {
            score = "Advantage player1";
        }

        if (_playerTwoScore > _playerOneScore && _playerOneScore >= 3)
        {
            score = "Advantage player2";
        }

        if (_playerOneScore >= 4 && _playerTwoScore >= 0 && (_playerOneScore - _playerTwoScore) >= 2)
        {
            score = "Win for player1";
        }

        if (_playerTwoScore >= 4 && _playerOneScore >= 0 && (_playerTwoScore - _playerOneScore) >= 2)
        {
            score = "Win for player2";
        }

        return score;
    }
}