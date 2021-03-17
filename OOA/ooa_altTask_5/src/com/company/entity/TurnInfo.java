package com.company.entity;

import java.awt.*;

public class TurnInfo {
    public final Cell player;
    public final Point position;

    public TurnInfo(Cell player, Point position) {
        this.player = player;
        this.position = position;
    }
}
