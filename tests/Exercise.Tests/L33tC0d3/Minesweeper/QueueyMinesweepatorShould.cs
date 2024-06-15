using Exercise.L33tC0d3.Minesweeper;
using Xunit;

namespace Exercise.Tests.L33tC0d3.Minesweeper;

public class QueueyMinesweepatorShould
{
    [Fact]
    public void UncoverWholeBlankMineField()
    {
        // arrange
        var initialBoard = new char[][]
        {
            ['E', 'E', 'E'],
            ['E', 'E', 'E'],
            ['E', 'E', 'E'],
        };

        var minesweepator = new QueueyMinesweepator();

        // act
        var updatedBoard = minesweepator.UpdateBoard(initialBoard, [1, 1]);

        // assert
        var expected = new char[][]
        {
            ['B', 'B', 'B'],
            ['B', 'B', 'B'],
            ['B', 'B', 'B'],
        };

        Assert.Equal(expected, updatedBoard);
    }

    [Fact]
    public void HitMine()
    {
        // arrange
        var initialBoard = new char[][]
        {
            ['E', 'E', 'E'],
            ['E', 'M', 'E'],
            ['E', 'E', 'E'],
        };

        var minesweepator = new QueueyMinesweepator();

        // act
        var updatedBoard = minesweepator.UpdateBoard(initialBoard, [1, 1]);

        // assert
        var expected = new char[][]
        {
            ['E', 'E', 'E'],
            ['E', 'X', 'E'],
            ['E', 'E', 'E'],
        };

        Assert.Equal(expected, updatedBoard);
    }

    [Fact]
    public void UncoverNumOfAdjacentMinesInSingleField()
    {
        // arrange
        var initialBoard = new char[][]
        {
            ['E', 'E', 'E'],
            ['E', 'M', 'E'],
            ['E', 'E', 'E'],
        };

        var minesweepator = new QueueyMinesweepator();

        // act
        var updatedBoard = minesweepator.UpdateBoard(initialBoard, [0, 0]);

        // assert
        var expected = new char[][]
        {
            ['1', 'E', 'E'],
            ['E', 'M', 'E'],
            ['E', 'E', 'E'],
        };

        Assert.Equal(expected, updatedBoard);
    }

    [Fact]
    public void UncoverAllBlankCellsNearby()
    {
        // arrange
        var initialBoard = new char[][]
        {
            ['E', 'E', 'E', 'E'],
            ['E', 'E', 'E', 'E'],
            ['E', 'E', 'M', 'E'],
            ['E', 'E', 'E', 'E'],
        };

        var minesweepator = new QueueyMinesweepator();

        // act
        var updatedBoard = minesweepator.UpdateBoard(initialBoard, [2, 0]);

        // assert
        var expected = new char[][]
        {
            ['B', 'B', 'B', 'B'],
            ['B', '1', '1', '1'],
            ['B', '1', 'M', 'E'],
            ['B', '1', 'E', 'E'],
        };

        Assert.Equal(expected, updatedBoard);
    }

    [Fact]
    public void UpdateBoardCorrectly()
    {
        // arrange
        var initialBoard = new char[][]
        {
            ['E', 'E', 'E', 'E', 'E'],
            ['E', 'E', 'M', 'E', 'E'],
            ['E', 'E', 'E', 'E', 'E'],
            ['E', 'E', 'E', 'E', 'E'],
        };

        var minesweepator = new QueueyMinesweepator();

        // act
        var updatedBoard = minesweepator.UpdateBoard(initialBoard, [3, 0]);

        // assert
        var expected = new char[][]
        {
            ['B', '1', 'E', '1', 'B'],
            ['B', '1', 'M', '1', 'B'],
            ['B', '1', '1', '1', 'B'],
            ['B', 'B', 'B', 'B', 'B'],
        };

        Assert.Equal(expected, updatedBoard);
    }
}
