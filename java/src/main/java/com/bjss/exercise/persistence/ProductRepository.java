package com.bjss.exercise.persistence;

import com.bjss.exercise.domain.Product;

import java.util.Collection;

public interface ProductRepository {
    public Collection<Product> findByNames(String[] names);
}
