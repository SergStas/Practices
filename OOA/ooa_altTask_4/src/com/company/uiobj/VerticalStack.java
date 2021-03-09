package com.company.uiobj;

import com.company.cl.Drawer;

public class VerticalStack extends UIObject {
    private final UIObject[] children;

    public VerticalStack(UIObject... children) {
        this.children = children;
        width = calculateWidth();
        height = calculateHeight();
    }

    @Override
    public int calculateWidth() {
        int maxWidth = -1;
        for (UIObject child : children)
            maxWidth = Integer.max(maxWidth, child.width);
        for (UIObject child : children)
            child.width = maxWidth;
        return maxWidth;
    }

    @Override
    public int calculateHeight() {
        int result = 0;
        for (UIObject child : children)
            result += child.height;
        return result;
    }

    @Override
    public void draw(Drawer drawer, int x, int y) {
        drawer.setCursor(x, y);
        int curHeight = y;
        for (UIObject child : children) {
            child.draw(drawer, x, curHeight);
            curHeight += child.height;
        }
    }
}