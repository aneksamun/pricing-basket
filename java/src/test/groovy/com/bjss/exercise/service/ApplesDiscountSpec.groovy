package com.bjss.exercise.service

import com.bjss.exercise.domain.Basket
import com.bjss.exercise.domain.Offer
import com.bjss.exercise.domain.Product
import com.bjss.exercise.domain.Rule
import com.bjss.exercise.validation.ProductUnitsValidator
import spock.lang.Specification

class ApplesDiscountSpec extends Specification {

    def 'Pricing apples with discount'() {
        given: 'I have basket full of items'
        def milk = new Product(
            name: 'Milk',
            price: 1.30,
            offers: [] as Set<Offer>
        )

        def apples = new Product(
            name: 'Apples',
            price: 1,
            offers: [new Offer(
                discount: 10.0,
                rules: [] as Set<Rule>
            )].toSet()
        )

        def items = [ milk, apples ]
        def basket = Basket.placeItems(items)

        when: 'I purchase items'
        def service = new PurchaseService(new ProductUnitsValidator())
        def receipt = service.purchase basket

        then: 'discount of 10% is applied for apples'
        !receipt.discounts.empty

        and:
        receipt.total == 2.20

        and:
        receipt.subtotal == 2.30
    }
}
