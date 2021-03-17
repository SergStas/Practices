package com.company;

import com.company.game.GameController;
import com.company.ui.CLUI;

public class Main {

    public static void main(String[] args) {
        new GameController(new CLUI()).begin();
    }
}
