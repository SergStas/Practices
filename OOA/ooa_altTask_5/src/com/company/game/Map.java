package com.company.game;

import com.company.entity.Cell;
import com.company.entity.Direction;

import java.awt.*;

public class Map {
    final static Point SIZE = new Point(6, 6);
    private final Cell[][] cells = new Cell[SIZE.y][SIZE.x];

    Map() {
        for (int i=0;i<6;i++)
            for (int j=0;j<6;j++)
                cells[i][j] = Cell.FREE;
    }

    void rotateTile(Direction dir, int x, int y) {
        Cell[][] tile = getTile(x, y);
        Cell[][] rotated = rotate(dir, tile);
        for (int i=0;i<3;i++)
            for (int j=0;j<3;j++)
                setCell(rotated[i][j], j+3*x, i+3*y);
    }

    Cell[][] getTile(int x, int y) {
        Cell[][] result = new Cell[3][3];
        for (int i=3*y;i<3*y+3;i++)
            System.arraycopy(cells[i], 3 * x, result[i - 3 * y], 0, 3);
        return result;
    }

    void setCell(Cell cell, int x, int y) {
        cells[y][x] = cell;
    }

    Cell getCell(int x, int y) {
        return cells[y][x];
    }

    Cell getWinner() {
        boolean b = false, w = false;
        for (int i=0;i<6;i++) {
            if (checkRow(getRow(true, i)) == Cell.WHITE)
                w = true;
            else if (checkRow(getRow(true, i)) == Cell.BLACK)
                b = true;
            if (checkRow(getRow(false, i)) == Cell.WHITE)
                w = true;
            else if (checkRow(getRow(false, i)) == Cell.BLACK)
                b = true;
            if (b && w)
                return Cell.FREE;
        }
        return !b && !w ? null : b ? Cell.BLACK : Cell.WHITE;
    }

    private Cell checkRow(Cell[] row) {
        return hasLineWithColor(Cell.BLACK, row) ? Cell.BLACK :
            hasLineWithColor(Cell.WHITE, row) ? Cell.WHITE : null;
    }

    private boolean hasLineWithColor(Cell target, Cell[] row) {
        int count = 0;
        for (Cell cell : row)
            if (cell == target)
                count++;
        return count > 4;
    }

    private Cell[] getRow(boolean horizontal, int pos) {
        Cell[] result = new Cell[6];
        if (horizontal)
            System.arraycopy(cells[pos], 0, result, 0, 6);
        else
            for (int i=0;i<6;i++)
                result[i] = cells[i][pos];
        return result;
    }

    private Cell[][] rotate(Direction dir, Cell[][] source) {
        int size = source.length;
        Cell[][] result = new Cell[size][size];
        for (int i=0;i<size;i++)
            for (int j=0;j<size;j++)
                if (dir == Direction.LEFT)
                    result[size - j - 1][i] = source[i][j];
                else
                    result[j][size - i - 1] = source[i][j];
        return result;
    }

    public Cell[][] getCells() {
        return cells;
    }
}
