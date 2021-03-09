package com.company.uiobj;

import com.company.cl.Drawer;

public class Text extends UIObject {
    public final String content;

    public Text(String content) {
        if (content.length() > 50)
            throw new IllegalArgumentException("Max length of text - 10 symbols");
        this.content = content;
        width = calculateWidth();
        height = calculateHeight();
    }

    @Override
    public int calculateWidth() {
        return content.length();
    }

    @Override
    public int calculateHeight() {
        return 1;
    }

    @Override
    public void draw(Drawer drawer, int x, int y) {
        drawer.setCursor(x, y)
            .write(content);
    }
}