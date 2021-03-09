package com.company.uiobj;

import com.company.cl.Drawer;

public class Frame extends UIObject {
    public final String title;
    public final UIObject child;

    public Frame(String title, UIObject child) {
        this.title = title;
        this.child = child;
        width = calculateWidth();
        height = calculateHeight();
    }

    @Override
    public int calculateWidth() {
        if (title.length() <= child.calculateWidth())
            return 4 + child.calculateWidth();
        child.width = 6 + title.length();
        return 6 + title.length();
    }

    @Override
    public int calculateHeight() {
        return child.calculateHeight() + 2;
    }

    @Override
    public void draw(Drawer drawer, int x, int y) {
        drawer.setCursor(x, y)
            .write("╔═ " + title + " " + "═".repeat(width - 5 - title.length()) + '╗');
        for (int i = 1; i < height - 1; i++)
            drawer.setCursor(x, y + i).write("║")
                    .setCursor(x + width - 1, y + i).write("║");
        drawer.setCursor(x, y + height - 1)
            .write('╚' + "═".repeat(width - 2) + '╝');
        child.draw(drawer, x + 2, y + 1);
    }
}