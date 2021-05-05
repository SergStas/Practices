package com.company;

public class Task1 {
    private static final IntState _x = new IntState();
    private static final IntState _result = new IntState();

    static class LuckyThread extends Thread {
        @Override
        public void run() {
            int curX;
            while ((curX = _x.inc()) < 999999) {
                if ((curX % 10) + (curX / 10) % 10 + (curX / 100) % 10 ==
                        (curX / 1000) % 10 + (curX / 10000) % 10 + (curX / 100000) % 10) {
                    System.out.println(curX);
                    _result.inc();
                }
            }
        }
    }

    public static void main(String[] args) throws InterruptedException {
        Thread t1 = new LuckyThread();
        Thread t2 = new LuckyThread();
        Thread t3 = new LuckyThread();
        t1.start();
        t2.start();
        t3.start();
        t1.join();
        t2.join();
        t3.join();
        System.out.println("Total: " + _result.get());
    }

    private static class IntState {
        private int _value;

        synchronized int inc() {
            return _value++;
        }

        synchronized int get() {
            return _value;
        }
    }
}
