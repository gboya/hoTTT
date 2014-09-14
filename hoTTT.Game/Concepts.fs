namespace hoTTT.Game

open System 
module Concepts = 
    
    /// <summary>
    /// A piece, either one of the two players or an empty one
    /// </summary>
    [<Flags>]
    type Piece = | E = 0 | X = 1 | O = 2

    /// <summary>
    /// A Position as a pair of int pairs.
    /// The first gives the position of the sub-board
    /// The second gives the position within the sub board
    /// </summary>
    type Position = (int * int) * (int * int)

    /// <summary>
    /// Maps a Position to an integer index.
    /// </summary>
    let positionIndex pos = 
        let between0And2 x = x >= 0 && x <= 2
        match pos with
        | ((i, j),(k, l)) when List.forall between0And2 [i;j;k;l] -> i * 27 + j * 9 + k * 3 + l
        | _ -> failwith "Wrong position"

    /// <summary>
    /// The game board, as a list of pieces
    /// </summary>
    type Board = Piece list

    /// <summary>
    /// A Move, combining a Piece and a Position
    /// </summary>
    type Move = {Piece : Piece ; Position : Position}