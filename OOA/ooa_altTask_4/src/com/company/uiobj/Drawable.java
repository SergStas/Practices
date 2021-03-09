package com.company.uiobj;

import com.company.cl.Drawer;

public interface Drawable {
    int calculateWidth();
    int calculateHeight();
    void draw(Drawer drawer, int x, int y);
}