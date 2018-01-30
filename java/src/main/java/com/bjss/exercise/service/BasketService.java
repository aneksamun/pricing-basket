package com.bjss.exercise.service;

import com.bjss.exercise.domain.Basket;
import com.bjss.exercise.domain.Product;
import com.bjss.exercise.persistence.ProductRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.Collection;

@Service
public class BasketService {

    private final ProductRepository productRepository;

    @Autowired
    public BasketService(ProductRepository productRepository) {
        this.productRepository = productRepository;
    }

    public Basket get(String[] items) {
        Collection<Product> products = productRepository.findByNames(items);
        return Basket.placeItems(products);
    }
}
