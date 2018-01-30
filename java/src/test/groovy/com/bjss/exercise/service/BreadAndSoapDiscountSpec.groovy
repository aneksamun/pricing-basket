package com.bjss.exercise.service

import com.bjss.exercise.domain.Basket
import com.bjss.exercise.domain.Offer
import com.bjss.exercise.domain.Product
import com.bjss.exercise.domain.Rule
import com.bjss.exercise.validation.ProductUnitsValidator
import spock.lang.Specification

class BreadAndSoapDiscountSpec extends Specification {

    def 'Buying 2 tins of soup gives special discount for bread'() {
        given: 'I have items with special offer'
        def soap1 = new Product(
                name: 'Soup',
                price: 0.65,
                offers: [] as Set<Offer>
        )

        def soap2 = new Product(
                name: 'Soup',
                price: 0.65,
                offers: [] as Set<Offer>
        )

        def bread = new Product(
                name: 'Bread',
                price: 0.80,
                offers: [new Offer(discount: 50, rules: [new Rule(product: soap1, amount: 2)].toSet())].toSet()
        )

        def items = [soap1, soap2, bread]

        def basket = Basket.placeItems(items)

        when: 'I buy an items'
        def service = new PurchaseService(new ProductUnitsValidator())
        def receipt = service.purchase basket

        then: 'I should get half discount for bread'
        !receipt.discounts.empty

        and:
        receipt.total == 1.70

        and:
        receipt.subtotal == 2.10
    }
}
