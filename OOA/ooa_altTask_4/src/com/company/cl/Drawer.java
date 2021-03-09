package com.company.cl;

import java.util.HashMap;
import java.util.function.Consumer;

public class Drawer {
    private int cX;
    private int cY;
    private int maxRow;
    private final HashMap<Integer, StringBuilder> rows = new HashMap<>();

    public Drawer setCursor(int x, int y) {
        if (!rows.containsKey(y))
            rows.put(y, new StringBuilder(" ".repeat(x + 1)));
        else if (rows.get(y).length() < x)
            rows.get(y).append(" ".repeat(x - rows.get(y).length()));
        cX = x;
        cY = y;
        maxRow = Integer.max(y, maxRow);
        return this;
    }

    public Drawer write(String text) {
        StringBuilder builder = rows.get(cY);
        builder.delete(cX, cX + text.length());
        builder.insert(cX, text);
        return this;
    }

    public void draw(Consumer<String> out) {
        StringBuilder result = new StringBuilder();
        for (int i = 0; i <= maxRow; i++)
            if (rows.containsKey(i))
                result.append(rows.get(i).toString()).append('\n');
            else
                result.append('\n');
        out.accept(result.toString());
    }
}