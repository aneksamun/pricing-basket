package com.bjss.exercise.persistence;

import com.bjss.exercise.domain.Offer;
import com.bjss.exercise.domain.Product;
import org.springframework.stereotype.Repository;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.TypedQuery;
import javax.persistence.criteria.*;
import java.util.ArrayList;
import java.util.Collection;
import java.util.List;

@Repository
public class ProductRepositoryImpl implements ProductRepository {

    @PersistenceContext
    private EntityManager manager;

    @Override
    public Collection<Product> findByNames(String[] names) {
        List<Product> products = new ArrayList<>();

        for (String name: names) {
            CriteriaBuilder builder = manager.getCriteriaBuilder();
            CriteriaQuery<Product> query = builder.createQuery(Product.class);

            Root<Product> product = query.from(Product.class);
            Fetch<Product, Offer> offers = product.fetch("offers", JoinType.LEFT);
            offers.fetch("rules", JoinType.LEFT);
            query.select(product).where(builder.equal(builder.upper(product.get("name")), name.toUpperCase()));

            TypedQuery<Product> typedQuery = manager.createQuery(query);
            List<Product> result = typedQuery.getResultList();

            if (!result.isEmpty())
                products.addAll(result);
        }

        return products;
    }
}
