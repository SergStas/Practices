package com.company.ui;

import com.company.entity.Cell;
import com.company.entity.RotationInfo;
import com.company.entity.TurnInfo;

public interface PentagoUserInterface {
    void drawTurn(Cell[][] cells, int turnNumber, Cell player);

    void displayWinner(Cell[][] finalMap, int totalTurns, Cell winner);

    TurnInfo getTurn(Cell player);

    RotationInfo getRotation();

    void displayErrorMessage();
}
