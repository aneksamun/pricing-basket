package com.bjss.exercise.domain;

import org.jetbrains.annotations.Contract;
import org.jetbrains.annotations.NotNull;

import java.util.Arrays;
import java.util.Collection;
import java.util.stream.Collectors;

public final class Basket {

    private final Collection<Product> products;

    private Basket(Collection<Product> products) {
        this.products = products;
    }

    public Collection<Product> getProducts() {
        return products;
    }

    public Collection<String> findAbsent(String[] items) {
        return Arrays.stream(items)
                .filter(item -> products.stream().noneMatch(product -> product.getName().equalsIgnoreCase(item)))
                .collect(Collectors.toList());
    }

    @Contract("_ -> !null")
    public static Basket placeItems(@NotNull Collection<Product> products) {
        return new Basket(products);
    }
}
