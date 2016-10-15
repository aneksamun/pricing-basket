package com.bjss.exercise.validation;

import com.bjss.exercise.domain.Product;
import com.bjss.exercise.domain.Rule;
import org.springframework.stereotype.Component;

import java.util.Collection;

@Component
public class ProductUnitsValidator {

    public boolean isValid(Rule rule, Collection<Product> products) {
        long total = products.stream().filter(product -> rule.getProduct().getName().equals(product.getName())).count();
        return total == rule.getAmount().longValue();
    }
}
