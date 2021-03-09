package com.company.uiobj;

import com.company.cl.Drawer;

public class Box extends UIObject {
    public final UIObject child;

    public Box(UIObject child) {
        this.child = child;
        width = calculateWidth();
        height = calculateHeight();
    }

    @Override
    public int calculateWidth() {
        return 4 + child.calculateWidth();
    }

    @Override
    public int calculateHeight() {
        return 2 + child.calculateHeight();
    }

    @Override
    public void draw(Drawer drawer, int x, int y) {
        drawer.setCursor(x, y)
            .write('┌' + "─".repeat(width - 2) + '┐');
        for (int i = 1; i < height - 1; i++)
            drawer.setCursor(x, y + i).write("│")
                .setCursor(x + width - 1, y + i).write("│");
        drawer.setCursor(x, y + height - 1)
            .write('└' + "─".repeat(width - 2) + '┘');
        child.draw(drawer, x + 2, y + 1);
    }
}