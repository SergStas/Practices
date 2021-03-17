package com.company.game;

import com.company.entity.Cell;
import com.company.entity.RotationInfo;
import com.company.entity.TurnInfo;
import com.company.ui.PentagoUserInterface;

public class GameController {
    private final Map map = new Map();
    private final PentagoUserInterface ui;
    private Cell player = Cell.WHITE;
    private int turnsCount = 1;

    public GameController(PentagoUserInterface ui) {
        this.ui = ui;
    }

    public void begin() {
        boolean result = false;
        while (!result) {
            result = processTurn();
            turnsCount++;
            player = player == Cell.WHITE ? Cell.BLACK : Cell.WHITE;
        }
    }

    private boolean processTurn() {
        ui.drawTurn(map.getCells(), turnsCount, player);
        TurnInfo turn = ui.getTurn(player);
        while (!checkTurn(turn)) {
            ui.displayErrorMessage();
            turn = ui.getTurn(player);
        }
        map.setCell(player, turn.position.x, turn.position.y);
        if (map.getWinner() != null) {
            ui.displayWinner(map.getCells(), turnsCount, map.getWinner());
            return true;
        }
        RotationInfo rotation = ui.getRotation();
        while (!checkRotation(rotation)) {
            ui.displayErrorMessage();
            rotation = ui.getRotation();
        }
        map.rotateTile(rotation.dir, rotation.tilePos.x, rotation.tilePos.y);
        if (map.getWinner() != null) {
            ui.displayWinner(map.getCells(), turnsCount, map.getWinner());
            return true;
        }
        return false;
    }

    private boolean checkTurn(TurnInfo turn) {
        return turn.position.x >= 0 && turn.position.x < 6 &&
            turn.position.y >= 0 && turn.position.y < 6 &&
            map.getCell(turn.position.x, turn.position.y) == Cell.FREE;
    }

    private boolean checkRotation(RotationInfo rotation) {
        return (rotation.tilePos.x == 0 || rotation.tilePos.x == 1) &&
            (rotation.tilePos.y == 0 || rotation.tilePos.y == 1);
    }
}
