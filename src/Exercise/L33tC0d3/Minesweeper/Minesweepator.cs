using System;

namespace Exercise.L33tC0d3.Minesweeper;

// https://leetcode.com/problems/minesweeper/ (529)
public class Minesweepator
{
    public char[][] UpdateBoard(char[][] board, int[] click)
    {
        var row = click[0];
        var col = click[1];

        ArgumentOutOfRangeException.ThrowIfNegative(row);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(row, board.Length);

        ArgumentOutOfRangeException.ThrowIfNegative(col);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(col, board[0].Length);

        if (board[row][col] == 'M')
        {
            // bad luck, mine hit ಠ_ಠ
            board[row][col] = 'X';
        }
        else
        {
            // Depth-First Search (DFS) to expose all blank cells nearby
            ExposeCell(board, row, col);
        }

        return board;
    }

    private static void ExposeCell(char[][] board, int row, int col)
    {
        // base case when called recursively when exposing adjacent cells
        if (!IsPlayableCell(board, row, col) || board[row][col] != 'E')
        {
            return;
        }

        // when uncovered cell has a mine nearby (represented by number), we expose just that cell;
        var numOfSurroundingMines = GetNumOfAdjacentMines(board, row, col);
        if (numOfSurroundingMines > 0)
        {
            board[row][col] = (char)('0' + numOfSurroundingMines);
            return;
        }

        // when exposed cell is blank, we also expose all blank cells nearby
        // until we reach a cell with adjacent mines (represented by number)
        board[row][col] = 'B';
        ExposeAdjacentCells(board, row, col);
    }

    private static void ExposeAdjacentCells(char[][] board, int row, int col)
    {
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                // skip the cell itself (this would add to [row][col])
                if (i == 0 && j == 0)
                {
                    continue;
                }

                ExposeCell(board, row + i, col + j);
            }
        }
    }

    private static int GetNumOfAdjacentMines(char[][] board, int row, int col)
    {
        var mines = 0;
        for (var i = -1; i <= 1; i++)
        {
            for (var j = -1; j <= 1; j++)
            {
                // skip the cell itself (this would add to [row][col])
                if (i == 0 && j == 0)
                {
                    continue;
                }

                var newRow = row + i;
                var newCol = col + j;

                if (!IsPlayableCell(board, newRow, newCol))
                {
                    continue;
                }

                if (board[newRow][newCol] == 'M')
                {
                    ++mines;
                }
            }
        }

        return mines;
    }

    private static bool IsPlayableCell(char[][] board, int row, int col) =>
        row >= 0
        && row < board.Length
        && col >= 0
        && col < board[0].Length;
}
