package com.bjss.exercise.domain;

import com.bjss.exercise.utility.CurrencyUtil;
import org.jetbrains.annotations.NotNull;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Collection;
import java.util.StringJoiner;

import static java.lang.String.format;
import static java.math.BigDecimal.ZERO;

public final class Receipt {

    private BigDecimal total;
    private BigDecimal subtotal;
    private Collection<Discount> discounts;

    public Receipt() {
        this(ZERO, ZERO, new ArrayList<>());
    }

    private Receipt(BigDecimal total, BigDecimal subtotal, Collection<Discount> discounts) {
        this.total = total;
        this.subtotal = subtotal;
        this.discounts = discounts;
    }

    public void addSubtotal(BigDecimal price) {
        this.subtotal = this.subtotal.add(price);
    }

    public void addTotal(BigDecimal price) {
        this.total = this.total.add(price);
    }

    public BigDecimal getSubtotal() {
        return subtotal;
    }

    public BigDecimal getTotal() {
        return total;
    }

    public Collection<Discount> getDiscounts() {
        return discounts;
    }

    @NotNull
    @Override
    public String toString() {
        return format("Subtotal: %s\n", CurrencyUtil.getBritainCurrencyFormat(subtotal)) +
                getDiscountsText() + "\n" +
                format("Total: %s\n", CurrencyUtil.getBritainCurrencyFormat(total));
    }

    private String getDiscountsText() {
        if (discounts.isEmpty()) {
            return "(No offers available)";
        }
        StringJoiner joiner = new StringJoiner("\n");
        discounts.forEach(discount -> joiner.add(discount.toString()));
        return joiner.toString();
    }
}
