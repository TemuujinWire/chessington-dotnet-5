using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square next;
            Square nextNext;
            Square takeLeft;
            Square takeRight;

            var square = board.FindPiece(this);
            var moves = new List<Square>();

            if (this.Player == Player.White) {
                next = Square.At(square.Row - 1, square.Col);
                nextNext = Square.At(square.Row - 2, square.Col);
                takeLeft = Square.At(square.Row - 1, square.Col - 1);
                takeRight = Square.At(square.Row - 1, square.Col + 1);
                if (square.Row == 0) { return moves; }
            } else {
                next = Square.At(square.Row + 1, square.Col);
                nextNext = Square.At(square.Row + 2, square.Col);
                takeLeft = Square.At(square.Row + 1, square.Col - 1);
                takeRight = Square.At(square.Row + 1, square.Col + 1);
                if (square.Row == GameSettings.BoardSize - 1) { return moves; }
            }

            if (board.GetPiece(next) == null) {
                moves.Add(next);
                if (!HasMoved && board.GetPiece(nextNext) == null) { moves.Add(nextNext); }
            }

            if (square.Col - 1 >= 0 &&
                board.GetPiece(takeLeft) != null &&
                board.GetPiece(takeLeft).Player != this.Player) {
                moves.Add(takeLeft);
            }
            if (square.Col + 1 < GameSettings.BoardSize &&
                board.GetPiece(takeRight) != null &&
                board.GetPiece(takeRight).Player != this.Player) {
                moves.Add(takeRight);
            }
                
            return moves;
        }
    }
}