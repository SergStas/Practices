package com.company;

public class ExceptionUtil {
    public static Throwable merge(Throwable throwable, StackTraceElement[] stackTrace) {
        StackTraceElement[] resultStack = new StackTraceElement[throwable.getStackTrace().length + stackTrace.length];
        System.arraycopy(throwable.getStackTrace(), 0, resultStack, 0, throwable.getStackTrace().length);
        System.arraycopy(stackTrace, 0, resultStack, throwable.getStackTrace().length, stackTrace.length);
        throwable.setStackTrace(resultStack);
        return throwable;
    }
}