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
            var square = board.FindPiece(this);
            if (this.Player == Player.White)
            {
                var moves = new List<Square> {Square.At(square.Row - 1, square.Col)};
                if (!HasMoved) { moves.Add(Square.At(square.Row - 2, square.Col)); }
                
                return moves;
            }
            
            var movess = new List<Square> {Square.At(square.Row + 1, square.Col)};  // Why can't i name this moves?
            if (!HasMoved) { movess.Add(Square.At(square.Row + 2, square.Col)); }
                
            return movess;
        }
    }
}