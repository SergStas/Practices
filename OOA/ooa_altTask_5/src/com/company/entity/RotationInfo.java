package com.company.entity;

import java.awt.*;

public class RotationInfo {
    public final Direction dir;
    public final Point tilePos;

    public RotationInfo(Direction dir, Point tilePos) {
        this.dir = dir;
        this.tilePos = tilePos;
    }
}
