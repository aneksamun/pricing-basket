package com.bjss.exercise.domain;

import java.math.BigDecimal;

import static com.bjss.exercise.utilities.CurrencyUtil.getBritainCurrencyFormat;

public final class Discount {

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
        BigDecimal valueOfDiscount = BigDecimal.valueOf(discount.longValue());
        BigDecimal valueOfHundred = BigDecimal.valueOf(100L);
        return price.multiply(valueOfDiscount).divide(valueOfHundred, 2);
    }
}
