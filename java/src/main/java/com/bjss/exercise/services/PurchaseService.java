package com.bjss.exercise.services;

import com.bjss.exercise.domain.*;
import com.bjss.exercise.validation.ProductUnitsValidator;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.math.BigDecimal;
import java.util.Collection;

@Service
public class PurchaseService {

    private final ProductUnitsValidator unitsValidator;

    @Autowired
    public PurchaseService(ProductUnitsValidator unitsValidator) {
        this.unitsValidator = unitsValidator;
    }

    public Receipt purchase(Basket basket) {
        Receipt receipt = new Receipt();

        for (Product product : basket.getProducts()) {
            receipt.addSubtotal(product.getPrice());
            if (product.getOffers().isEmpty()) {
                receipt.addTotal(product.getPrice());
            } else {
                receipt.addTotal(calculateTotal(product, basket.getProducts(), receipt.getDiscounts()));
            }
        }

        return receipt;
    }

    private BigDecimal calculateTotal(Product current, Collection<Product> all, Collection<Discount> discounts) {
        BigDecimal finalPrice = current.getPrice();

        for (Offer offer: current.getOffers()) {
            if (offer.getRules().isEmpty()) {
                Discount discount = Discount.apply(current, offer);
                finalPrice = finalPrice.subtract(discount.getSavedAmount());
                discounts.add(discount);
            } else {
                for (Rule rule: offer.getRules()) {
                    if (unitsValidator.isValid(rule, all)) {
                        Discount discount = Discount.apply(current, offer);
                        finalPrice = finalPrice.subtract(discount.getSavedAmount());
                        discounts.add(discount);
                    }
                }
            }
        }

        return finalPrice.compareTo(BigDecimal.ZERO) >= 0 ? finalPrice : BigDecimal.ZERO;
    }
}
