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
            var square = board.FindPiece(this);
            var moves = new List<Square>();

            if (this.Player == Player.White) {
                next = Square.At(square.Row - 1, square.Col);
                nextNext = Square.At(square.Row - 2, square.Col);
            } else {
                next = Square.At(square.Row + 1, square.Col);
                nextNext = Square.At(square.Row + 2, square.Col);
            }

            if (board.GetPiece(next) == null) {
                moves.Add(next);
                if (!HasMoved && board.GetPiece(nextNext) == null) { moves.Add(nextNext); }
            }
                
            return moves;
        }
    }
}