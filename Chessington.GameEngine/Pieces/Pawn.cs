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
                return new Square[] {Square.At(square.Row - 1, square.Col)};
            }
            return new Square[] {Square.At(square.Row + 1, square.Col)};
        }
    }
}