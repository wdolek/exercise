using System;
using System.Collections.Generic;

namespace Exercise.L33tC0d3.Minesweeper;

// https://leetcode.com/problems/minesweeper/ (529)
public class QueueyMinesweepator
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
            // Breadth-First Search (BFS) to expose all blank cells nearby
            ExposeCell(board, row, col);
        }

        return board;
    }

    private static void ExposeCell(char[][] board, int row, int col)
    {
        var queue = new Queue<(int Row, int Col)>();
        queue.Enqueue((row, col));

        while (queue.Count > 0)
        {
            var (currentRow, currentCol) = queue.Dequeue();

            if (!IsPlayableCell(board, currentRow, currentCol) || board[currentRow][currentCol] != 'E')
            {
                continue;
            }

            var numOfSurroundingMines = GetNumOfAdjacentMines(board, currentRow, currentCol);
            if (numOfSurroundingMines > 0)
            {
                board[currentRow][currentCol] = (char)('0' + numOfSurroundingMines);
                continue;
            }

            board[currentRow][currentCol] = 'B';
            AddAdjacentCellsForDiscovery(queue, currentRow, currentCol);
        }
    }

    private static void AddAdjacentCellsForDiscovery(Queue<(int Row, int Col)> queue, int currentRow, int currentCol)
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

                queue.Enqueue((currentRow + i, currentCol + j));
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
