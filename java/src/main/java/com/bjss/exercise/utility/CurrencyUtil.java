package com.bjss.exercise.utility;

import org.jetbrains.annotations.NotNull;

import java.math.BigDecimal;
import java.text.NumberFormat;
import java.util.Locale;

public final class CurrencyUtil {

    @NotNull
    public static String getBritainCurrencyFormat(BigDecimal amount) {
        Locale greatBritainLocale = new Locale("en", "gb");
        return NumberFormat.getCurrencyInstance(greatBritainLocale).format(amount);
    }
}
