package com.bjss.exercise;

import com.bjss.exercise.config.ApplicationConfig;
import com.bjss.exercise.domain.Basket;
import com.bjss.exercise.domain.Receipt;
import com.bjss.exercise.service.BasketService;
import com.bjss.exercise.service.PurchaseService;
import org.springframework.context.ApplicationContext;
import org.springframework.context.annotation.AnnotationConfigApplicationContext;

import static java.lang.String.format;

public class Application {

    public static void main(String[] args) {
        if (args.length == 0) {
            System.out.println("No items found in basket.");
            System.out.println("Usage: pricing-basket [item1] [item2] ... [itemN]");
            return;
        }

        ApplicationContext context =
                new AnnotationConfigApplicationContext(ApplicationConfig.class);

        BasketService basketService = context.getBean(BasketService.class);
        Basket basket = basketService.get(args);

        if (basket.getProducts().isEmpty()) {
            System.out.println("No matching products found.");
            return;
        }

        basket.findAbsent(args).forEach(item -> System.out.println(format("The item '%s' is not present in stock.", item)));

        System.out.println();

        PurchaseService purchaseService = context.getBean(PurchaseService.class);
        Receipt receipt = purchaseService.purchase(basket);
        System.out.println(receipt);
    }
}
