package com.company.uiobj;

import com.company.cl.Drawer;

public class HorizontalStack extends UIObject {
    private final UIObject[] children;

    public HorizontalStack(UIObject... children) {
        this.children = children;
        width = calculateWidth();
        height = calculateHeight();
    }

    @Override
    public int calculateWidth() {
        int result = 0;
        for (UIObject child : children)
            result += child.width + 1;
        return result - 1;
    }

    @Override
    public int calculateHeight() {
        int maxHeight = -1;
        for (UIObject child : children)
            maxHeight = Integer.max(maxHeight, child.height);
        for (UIObject child : children)
            child.height = maxHeight;
        return maxHeight;
    }

    @Override
    public void draw(Drawer drawer, int x, int y) {
        drawer.setCursor(x, y);
        int curWidth = x;
        for (UIObject child : children) {
            child.draw(drawer, curWidth, y);
            curWidth += child.width + 1;
        }
    }
}