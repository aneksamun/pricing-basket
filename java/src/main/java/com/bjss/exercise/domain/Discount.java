package com.bjss.exercise.domain;

import java.math.BigDecimal;
import java.math.RoundingMode;

import static com.bjss.exercise.utility.CurrencyUtil.getBritainCurrencyFormat;
import static java.lang.Enum.valueOf;
import static java.math.RoundingMode.HALF_UP;

public final class Discount {

    private static BigDecimal HUNDRED = new BigDecimal(100);

    private final String product;
    private final Integer percentage;
    private final BigDecimal savedAmount;

    private Discount(String product, Integer percentage, BigDecimal discountedPrice) {
        this.product = product;
        this.percentage = percentage;
        this.savedAmount = discountedPrice;
    }

    public String getProduct() {
        return product;
    }

    public Integer getPercentage() {
        return percentage;
    }

    public BigDecimal getSavedAmount() {
        return savedAmount;
    }

    @Override
    public String toString() {
        return String.format("%s %d%% off: -%s", product, percentage, getBritainCurrencyFormat(savedAmount));
    }

    public static Discount apply(Product product, Offer offer) {
        BigDecimal discountedPrice = calculateDiscount(offer.getDiscount(), product.getPrice());
        return new Discount(product.getName(), offer.getDiscount(), discountedPrice);
    }

    private static BigDecimal calculateDiscount(Integer discount, BigDecimal price) {
        BigDecimal multiplication = price.multiply(new BigDecimal(discount));
        return multiplication.divide(HUNDRED, 2, RoundingMode.HALF_UP);
    }
}
