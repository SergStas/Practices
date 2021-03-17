package com.company.ui;

import com.company.entity.Cell;
import com.company.entity.Direction;
import com.company.entity.RotationInfo;
import com.company.entity.TurnInfo;

import java.awt.*;
import java.util.Scanner;

import static java.lang.System.in;
import static java.lang.System.out;

public class CLUI implements PentagoUserInterface {
    @Override
    public void drawTurn(Cell[][] cells, int turnNumber, Cell player) {
        out.println("=".repeat(50));
        out.println("Turn #" + turnNumber);
        out.println("-".repeat(50));
        drawMap(cells);
    }

    @Override
    public void displayWinner(Cell[][] finalMap, int totalTurns, Cell winner) {
        out.println("\033[32mGame finished in " + totalTurns + " turns\033[0m");
        out.println(winner == Cell.FREE ? "Draw!" : (winner == Cell.WHITE ? "\033[31mRed" : "\033[34mBlue") + " wins!!!\033[0m");
        drawMap(finalMap);
    }

    @Override
    public TurnInfo getTurn(Cell player) {
        out.println((player == Cell.WHITE ? "Red" : "Blue") + " player's turn");
        int x = getCoordinate("x = ");
        int y = getCoordinate("y = ");
        return new TurnInfo(player, new Point(x, y));
    }

    private int getCoordinate(String label) {
        Scanner scanner = new Scanner(in);
        int c = -1;
        while (c == -1) {
            out.print(label);
            String str = scanner.next();
            try {
                c = Integer.parseInt(str);
            }
            catch (Exception e) {
                out.println("\033[31mInvalid value\033[0m");
            }
        }
        return c;
    }

    @Override
    public RotationInfo getRotation() {
        out.println("Coordinates of tile to rotate (0 or 1):");
        int x = getCoordinate("x = ");
        int y = getCoordinate("y = ");
        out.println("Direction (0 = left, 1 = right):");
        int d = getCoordinate("Direction = ");
        while (!(d == 0 || d == 1)) {
            out.println("\033[31mValue must be 0 or 1\033[0m");
            d = getCoordinate("Direction = ");
        }
        return new RotationInfo(d == 0 ? Direction.LEFT : Direction.RIGHT, new Point(x, y));
    }

    @Override
    public void displayErrorMessage() {
        out.println("\033[31mIncorrect turn, try again\033[0m");
    }

    private void drawMap(Cell[][] cells) {
        out.println("\033[43m" + " ".repeat(9) + "\033[0m");
        for (int i=0;i<6;i++) {
            out.print("\033[43m \033[0m");
            for (int j=0;j<6;j++)
                out.print(
                        (cells[i][j] == Cell.WHITE ? "\033[41m \033[0m" : cells [i][j] == Cell.BLACK ? "\033[46m \033[0m" : " ") +
                                (j == 2 ? "\033[43m \033[0m" : j == 5 ? "\033[43m \033[0m\n" : "")
                );
            if (i == 2 || i == 5)
                out.println("\033[43m" + " ".repeat(9) + "\033[0m");
        }
    }
}
